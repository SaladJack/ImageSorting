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

namespace HVS
{
    //图片类，封装了bitmap和一些图片操作函数
    public class Pic
    {
        public Bitmap image;
        private BitmapData data;
        public String path; //图像路径
        public String name; //图片名字
        public int height = -1; //图像的高
        public int width = -1; //图像的宽
        public double grade_none; //图像无参考得分
        public double grade_full; //图像全参考得分
        public int[, ,] rgb; //图像rgb
        public double[,] gray; //图像灰度值

        public unsafe Pic(Bitmap image)
        {
            this.image = image;
            data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte* ptr = (byte*)(data.Scan0);
            height = data.Height;
            width = data.Width;
            int stribe = data.Stride;
            int extra = stribe - width * 3;
            rgb = new int[3, height, width];
            //指针操作图像，C#里处理图像最快的方法，将图像的rgb值先读入一个数组
            gray = new double[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < width; k++, ptr += 3)
                {
                    rgb[0, i, k] = *(ptr);
                    rgb[1, i, k] = *(ptr + 1);
                    rgb[2, i, k] = *(ptr + 2);
                    gray[i, k] = rgb[0, i, k] * 0.114 + rgb[1, i, k] * 0.587 + rgb[2, i, k] * 0.299;
                }
                ptr += extra;
            }
            image.UnlockBits(data);
        }

        //构造方法，对图像信息初始化
        public unsafe Pic(String _path, String _name)
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
            gray = new double[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < width; k++, ptr += 3)
                {
                    rgb[0, i, k] = *(ptr);
                    rgb[1, i, k] = *(ptr + 1);
                    rgb[2, i, k] = *(ptr + 2);
                    gray[i, k] = rgb[0, i, k] * 0.114 + rgb[1, i, k] * 0.587 + rgb[2, i, k] * 0.299;
                }
                ptr += extra;
            }
            image.UnlockBits(data);
        }

        public Image compress(Int64 quality, ImageFormat format)
        {
            if(quality == 100)
            {
                return this.image;
            }
            ImageCodecInfo jpgEncoder = GetEncoder(format);

            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;

            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, quality);
            myEncoderParameters.Param[0] = myEncoderParameter;
            MemoryStream stream = new MemoryStream();
            image.Save(stream, jpgEncoder, myEncoderParameters);
            return new Bitmap(stream);
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}
