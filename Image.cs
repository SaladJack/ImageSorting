using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Data;
using System.IO;

namespace demo1
{
    //图片类，封装了bitmap和一些图片操作函数
    public class Pic
    {
        public Bitmap image;
        private BitmapData data;
        public String path; //图像路径
        public String name; //图片名字
        public int height; //图像的高
        public int width; //图像的宽
        public double grade_none; //图像无参考得分
        public double grade_full; //图像全参考得分
        public int[, ,] rgb; //图像rgb
        public int[,] gray; //图像灰度值
        public int[,] lbp; //图像lbp值
        public bool state_none; //图片是否已经无参考评分
        public bool state_full; //图片是否已经全参考评分
        public int[] power;
        public int[] value;
        public int[] sum;

        public unsafe Pic(Bitmap image)
        {
            this.image = image;
        }

        //构造方法，对图像信息初始化
        public unsafe Pic(String _path,String _name)
        {
            path = _path;
            name = _name;
            image = new Bitmap(_path);
            data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte* ptr = (byte*)(data.Scan0);
            height = data.Height;
            width = data.Width;
            int stribe = data.Stride;
            int extra = stribe - width * 3;
            rgb = new int[3, height, width];
            //指针操作图像，C#里处理图像最快的方法，将图像的rgb值先读入一个数组
            gray = new int[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < width; k++, ptr += 3)
                {
                    rgb[0, i, k] = *(ptr);
                    rgb[1, i, k] = *(ptr + 1);
                    rgb[2, i, k] = *(ptr + 2);
                    gray[i, k] = (int)(rgb[0, i, k] * 0.114 + rgb[1, i, k] * 0.587 + rgb[2, i, k] * 0.299);
                }
                ptr += extra;
            }
            image.UnlockBits(data);
            state_none = false;
            state_full = false;
            power = new int[] { 1, 2, 4, 8, 16, 32, 64, 128, 256 };
            init();
        }

        public void init()
        {
            value = new int[256];
            sum = new int[59];
            int index = 0;
            int cnt;
            int s;
            int pre = -1;
            for (int i = 0; i < 256; i++)
            {
                s = 0;
                cnt = 0;
                for (int k = 0; k < 8; k++)
                {
                    if ((i & (1 << k)) != 0)
                    {
                        if (pre == 0)
                        {
                            cnt++;
                            if (cnt == 3)
                            {
                                break;
                            }
                        }
                        s += 1 << k;
                        pre = 1;
                    }
                    else
                    {
                        if (pre == 1)
                        {
                            cnt++;
                            if (cnt == 3)
                            {
                                break;
                            }
                        }
                        pre = 0;
                    }
                }
                if(cnt == 3)
                {
                    value[i] = 58;
                }
                else
                {
                    value[i] = index++;
                }
            }
            for(int i = 0; i < 58;i++)
            {
                sum[i] = 0;
            }
        }

        public void getLBP()
        {
            int tempHeight = height - 1;
            int tempWidth = width - 1;
            int tempValue;
            for (int i = 1; i < tempHeight; i++)
            {
                for (int k = 1; k < tempWidth; k++)
                {
                    tempValue = 0;
                    if (gray[i, k] > gray[i - 1, k - 1]) tempValue += 1;
                    if (gray[i, k] > gray[i - 1, k]) tempValue += 2;
                    if (gray[i, k] > gray[i - 1, k + 1]) tempValue += 4;
                    if (gray[i, k] > gray[i, k + 1]) tempValue += 8;
                    if (gray[i, k] > gray[i + 1, k + 1]) tempValue += 16;
                    if (gray[i, k] > gray[i + 1, k]) tempValue += 32;
                    if (gray[i, k] > gray[i + 1, k - 1]) tempValue += 64;
                    if (gray[i, k] > gray[i, k - 1]) tempValue += 128;
                    lbp[i, k] = value[tempValue];
                    sum[lbp[i, k]]++;
                }
            }
        }

        public int LBPdiffer(Pic image2)
        {
            int s = 0;
            for(int i = 0;i < 58;i++)
            {
                if(sum[i] != image2.sum[i])
                {
                    s++;
                }
            }
            return s;
        }

        //邻近点缩放，将缩放后的RGB放到一个数组中，缩放大小为height*width
        public int[, ,] resize(int height, int width)
        {
            int[, ,] result = new int[3, height, width];
            int posx, poxy;
            double rx = (double)this.height / height;
            double ry = (double)this.width / width;
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < width; k++)
                {
                    posx = (int)rx * i;
                    poxy = (int)ry * k;
                    result[0, i, k] = rgb[0, posx, poxy];
                    result[1, i, k] = rgb[1, posx, poxy];
                    result[2, i, k] = rgb[2, posx, poxy];
                }
            }
            return result;
        }

        //全参考比较两张图片的相似度，psnr值越小相差越大，两张图片一样时psnr为无穷
        public double psnr(Pic image2)
        {
            int mse = 0;
            int temp;
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < width; k++)
                {
                    temp = rgb[0, i, k] - image2.rgb[0, i, k];
                    mse += temp * temp;
                    temp = rgb[1, i, k] - image2.rgb[1, i, k];
                    mse += temp * temp;
                    temp = rgb[2, i, k] - image2.rgb[2, i, k];
                    mse += temp * temp;
                }
            }
            double MSE = mse;
            MSE /= height * width;
            return 10.0 * Math.Log10(65025 / MSE);
        }

        //无参考评价图片清晰度，返回值越大清晰度越高，使用了sobel算子
        public double tenengrad()
        {
            double result = 0;
            int h = height - 1;
            int w = width - 1;
            int gx, gy;
            double gxy;
            for (int i = 1; i<h;i++)
            {
                for(int k=1;k<w;k++)
                {
                    gx = rgb[0, i - 1, k + 1] + (rgb[0, i, k + 1] << 1) + rgb[0, i + 1, k + 1] - rgb[0, i - 1, k - 1] - (rgb[0, i, k - 1] << 1) - rgb[0, i + 1, k - 1];
                    gy = rgb[0, i - 1, k - 1] + (rgb[0, i - 1, k] << 1) + rgb[0, i - 1, k + 1] - rgb[0, i + 1, k - 1] - (rgb[0, i + 1, k] << 1) - rgb[0, i + 1, k + 1];
                    gxy = gx * gx + gy * gy;
                    if(gxy > 40000)
                    {
                        result += (int)Math.Sqrt((double)gxy);
                    }
                    gx = rgb[1, i - 1, k + 1] + (rgb[1, i, k + 1] << 1) + rgb[1, i + 1, k + 1] - rgb[1, i - 1, k - 1] - (rgb[1, i, k - 1] << 1) - rgb[1, i + 1, k - 1];
                    gy = rgb[1, i - 1, k - 1] + (rgb[1, i - 1, k] << 1) + rgb[1, i - 1, k + 1] - rgb[1, i + 1, k - 1] - (rgb[1, i + 1, k] << 1) - rgb[1, i + 1, k + 1];
                    gxy = gx * gx + gy * gy;
                    if (gxy > 40000)
                    {
                        result += (int)Math.Sqrt((double)gxy);
                    }
                    gx = rgb[2, i - 1, k + 1] + (rgb[2, i, k + 1] << 1) + rgb[2, i + 1, k + 1] - rgb[2, i - 1, k - 1] - (rgb[2, i, k - 1] << 1) - rgb[2, i + 1, k - 1];
                    gy = rgb[2, i - 1, k - 1] + (rgb[2, i - 1, k] << 1) + rgb[2, i - 1, k + 1] - rgb[2, i + 1, k - 1] - (rgb[2, i + 1, k] << 1) - rgb[2, i + 1, k + 1];
                    gxy = gx * gx + gy * gy;
                    if (gxy > 40000)
                    {
                        result += (int)Math.Sqrt((double)gxy);
                    }
                }
            }
            return result / height / width / 4;
        }

        //ImageCodecInfo类的作用是确定文件格式，返回值为格式编码
        private ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders(); //将所有格式的编码信息赋给CodecInfo数组
            foreach (ImageCodecInfo ici in CodecInfo) //定义一个编码器型参数ici，并建立循环
            {
                if (ici.MimeType == mimeType) return ici; //返回传递进来的格式的编码,传送进来的是jpeg格式，返回值为jpeg格式的编码器编码

            }
            return null;
        }

        //图像压缩，quality为质量分数，取值范围为[0,100]，size为压缩百分比，取值为(0，100]
        public Image compress(int quality, int size, string format)
        {
            int _height = height * size / 100; 
            int _witdh = width * size / 100;
            Bitmap bmb = new Bitmap(_witdh, _height); 
            Graphics grap = Graphics.FromImage(bmb); 
            grap.DrawImage(image, new Rectangle(0, 0, _witdh, _height)); 
            EncoderParameter p = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            //EncoderParameter用于存放所有关于当前图片的修改，
            //Quality为图片质量参数，Quality 类别指定图像的压缩级别，在用于构造 EncoderParameter 时，质量类别的有用值范围为从 0 到 100。 
            //指定的数值越低，压缩越高，因此图像的质量越低。 值为 0 时，图像的质量最差；值为 100 时，图像的质量最佳
            EncoderParameters ps = new EncoderParameters(1);
            //EncoderParameters是EncoderParameter类的集合数组
            ps.Param[0] = p;
            //将EncoderParameter中的值传递给EncoderParameters
            System.IO.MemoryStream me = new MemoryStream();
            //定义一个数据流
            string str = "image/" + format;
            bmb.Save(me, GetCodecInfo(str), ps);
            //将bmb图像用指定格式按照指定质量参数重新编码，实现质量压缩
            Image pic = System.Drawing.Image.FromStream(me);
            return bmb;
        }
    }
}
