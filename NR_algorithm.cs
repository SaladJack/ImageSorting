using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace HVS
{
    public class NR_algorithm
    {
        //无参考评价图片清晰度，返回值越大清晰度越高，使用了sobel算子
        public static double Tenengrad(int[,,] image,int height,int width)
        {
            double result = 0;
            int h = height - 1;
            int w = width - 1;
            double gx, gy;
            double gxy;
            double[,] gray = new double[height, width];
            for(int i = 0; i < height; i++)
            {
                for(int k = 0; k < width; k++)
                {
                    gray[i, k] = image[0, i, k] * 0.144 + image[1, i, k] * 0.587 + image[2, i, k] * 0.299;
                }
            }
            for (int i = 1; i < h; i++)
            {
                for (int k = 1; k < w; k++)
                {
                    gx = (gray[i - 1, k + 1] + gray[i, k + 1] * 2 + gray[i + 1, k + 1] - gray[i - 1, k - 1] - gray[i, k - 1] * 2 - gray[i + 1, k - 1]) / 4;
                    gy = (gray[i - 1, k - 1] + gray[i - 1, k] * 2 + gray[i - 1, k + 1] - gray[i + 1, k - 1] - gray[i + 1, k] * 2 - gray[i + 1, k + 1]) / 4;
                    gxy = gx * gx + gy * gy;
                    result += Math.Sqrt(gxy);
                }
            }
            return result / ((height - 2) * (width - 2));
        }

        public static int Tenengrad_grade(double result)
        {
            if (result >= 16)
            {
                return 100;
            }
            else
            {
                return (int)(result * 6.25);
            }
        }

        public static double Brenner(int[, ,] image, int height, int width)
        {
            double result = 0;
            int h = height - 1;
            int w = width - 1;
            double[,] gray = new double[height, width];
            double min, max;
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < width; k++)
                {
                    gray[i, k] = image[0, i, k] * 0.144 + image[1, i, k] * 0.587 + image[2, i, k] * 0.299;
                }
            }
            for(int i = 1; i < h; i++)
            {
                for (int k = 1; k < w; k++)
                {
                    if (gray[i, k + 1] > gray[i, k - 1] && gray[i, k + 1] > gray[i - 1, k] && gray[i, k + 1] > gray[i + 1, k])
                    {
                        max = gray[i, k + 1];
                    }
                    else if (gray[i, k - 1] > gray[i, k + 1] && gray[i, k - 1] > gray[i - 1, k] && gray[i, k - 1] > gray[i + 1, k])
                    {
                        max = gray[i, k - 1];
                    }
                    else if (gray[i + 1, k] > gray[i - 1, k] && gray[i + 1, k] > gray[i, k + 1] && gray[i + 1, k] > gray[i, k - 1])
                    {
                        max = gray[i + 1, k];
                    }
                    else
                    {
                        max = gray[i - 1, k];
                    }
                    if (gray[i, k + 1] < gray[i, k - 1] && gray[i, k + 1] < gray[i - 1, k] && gray[i, k + 1] < gray[i + 1, k])
                    {
                        min = gray[i, k + 1];
                    }
                    else if (gray[i, k - 1] < gray[i, k + 1] && gray[i, k - 1] < gray[i - 1, k] && gray[i, k - 1] < gray[i + 1, k])
                    {
                        min = gray[i, k - 1];
                    }
                    else if (gray[i + 1, k] < gray[i - 1, k] && gray[i + 1, k] < gray[i, k + 1] && gray[i + 1, k] < gray[i, k - 1])
                    {
                        min = gray[i + 1, k];
                    }
                    else
                    {
                        min = gray[i - 1, k];
                    }
                    result += (max - min)*(max - min);
                }
            }
            return result / ((height - 2) * (width - 2));
        }

        public static int Brenner_grade(double result)
        {
            return Math.Min((int)(Math.Sqrt(result) * 5), 100);
        }

        public static double NR_method(string algorithm, int[, ,] image, int height, int width)
        {
            switch (algorithm)
            {
                case "Tenengrad":
                    {
                        return NR_algorithm.Tenengrad(image, height, width);
                    }
                case "Brenner":
                    {
                        return NR_algorithm.Brenner(image, height, width);
                    }
                default:
                    {
                        if (SettingInfo.dllHelper.NR_methods.ContainsKey(algorithm))
                        {
                            object reflectInstance = Activator.CreateInstance(SettingInfo.dllHelper.NR_methods[algorithm]);
                            MethodInfo methodInfo = SettingInfo.dllHelper.NR_methods[algorithm].GetMethod("NR_method",
                                new Type[] { typeof(int[, ,]), typeof(int), typeof(int) });
                            return (double)methodInfo.Invoke(reflectInstance,
                                new object[] { image, height, width });
                        }
                        return -1;
                    }
            }
        }

        public static int NR_grade(string algorithm, double result)
        {
            switch (algorithm)
            {
                case "Tenengrad":
                    {
                        return Tenengrad_grade(result);
                    }
                case "Brenner":
                    {
                        return Brenner_grade(result);
                    }
                default:
                    {
                        if (SettingInfo.dllHelper.NR_methods.ContainsKey(algorithm))
                        {
                            object reflectInstance = Activator.CreateInstance(SettingInfo.dllHelper.NR_methods[algorithm]);
                            MethodInfo methodInfo = SettingInfo.dllHelper.NR_methods[algorithm].GetMethod("NR_grade",
                                new Type[] { typeof(double) });
                            return (int)methodInfo.Invoke(reflectInstance,
                                new object[] { result });
                        }
                        return -1;
                    }
            }
        }
    }
}