using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace HVS
{
    public class FR_algorithm
    {
        public static double PSNR(int[, ,] image1, int[, ,] image2, int height, int width)
        {
            int mse0 = 0;
            int mse1 = 0;
            int mse2 = 0;
            int temp;
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < width; k++)
                {
                    temp = image1[0, i, k] - image2[0, i, k];
                    mse0 += temp * temp;
                    temp = image1[1, i, k] - image2[1, i, k];
                    mse1 += temp * temp;
                    temp = image1[2, i, k] - image2[2, i, k];
                    mse2 += temp * temp;
                }
            }
            double MSE = (mse0 + mse1 + mse2) / 3.0;
            MSE /= height * width;
            return 10.0 * Math.Log10(65025 / MSE);
        }

        public static int PSNR_grade(int[, ,] image1, int[, ,] image2, int height, int width)
        {
            double result = PSNR(image1, image2, height, width);
            if(result<=19.0)
            {
                return 0;
            }
            else if(result>=51.0)
            {
                return 100;
            }
            else
            {
                return (int)((result - 19) * 3.125);
            }
        }

        public static int PSNR_grade(double result)
        {
            if (result <= 19.0)
            {
                return 0;
            }
            else if (result >= 51.0)
            {
                return 100;
            }
            else
            {
                return (int)((result - 19) * 3.125);
            }
        }

        public static double LBP(int[, ,] image1, int[, ,] image2, int height, int width)
        {
            int[] value;
            value = new int[256];
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
                if (cnt == 3)
                {
                    value[i] = 58;
                }
                else
                {
                    value[i] = index++;
                }
            }

            int[] lbp1 = new int[59];
            int[] lbp2 = new int[59];
            double[,] gray1 = new double[height, width];
            double[,] gray2 = new double[height, width];
            for (int i = 0; i < 59; i++)
            {
                lbp1[i] = lbp2[i] = 0;
            }

            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < width; k++)
                {
                    gray1[i, k] = image1[0, i, k] * 0.114 + image1[1, i, k] * 0.587 + image1[2, i, k] * 0.299;
                    gray2[i, k] = image2[0, i, k] * 0.114 + image2[1, i, k] * 0.587 + image2[2, i, k] * 0.299;
                }
            }
            int tempHeight = height - 1;
            int tempWidth = width - 1;
            int pattern1;
            int pattern2;
            int result = 0;
            for (int i = 1; i < tempHeight; i++)
            {
                for (int k = 1; k < tempWidth; k++)
                {
                    pattern1 = 0;
                    if (gray1[i, k] > gray1[i - 1, k - 1]) pattern1 += 1;
                    if (gray1[i, k] > gray1[i - 1, k]) pattern1 += 2;
                    if (gray1[i, k] > gray1[i - 1, k + 1]) pattern1 += 4;
                    if (gray1[i, k] > gray1[i, k + 1]) pattern1 += 8;
                    if (gray1[i, k] > gray1[i + 1, k + 1]) pattern1 += 16;
                    if (gray1[i, k] > gray1[i + 1, k]) pattern1 += 32;
                    if (gray1[i, k] > gray1[i + 1, k - 1]) pattern1 += 64;
                    if (gray1[i, k] > gray1[i, k - 1]) pattern1 += 128;
                    lbp1[value[pattern1]]++;

                    pattern2 = 0;
                    if (gray2[i, k] > gray2[i - 1, k - 1]) pattern2 += 1;
                    if (gray2[i, k] > gray2[i - 1, k]) pattern2 += 2;
                    if (gray2[i, k] > gray2[i - 1, k + 1]) pattern2 += 4;
                    if (gray2[i, k] > gray2[i, k + 1]) pattern2 += 8;
                    if (gray2[i, k] > gray2[i + 1, k + 1]) pattern2 += 16;
                    if (gray2[i, k] > gray2[i + 1, k]) pattern2 += 32;
                    if (gray2[i, k] > gray2[i + 1, k - 1]) pattern2 += 64;
                    if (gray2[i, k] > gray2[i, k - 1]) pattern2 += 128;
                    lbp2[value[pattern2]]++;

                    if (pattern1 == pattern2)
                    {
                        result++;
                    }
                }
            }

            int sum = 0;
            for (int i = 0; i < 59; i++)
            {
                if (lbp1[i] == lbp2[i])
                {
                    sum++;
                }
            }
            return (double)result / ((height - 2) * (width - 2));
        }

        public static int LBP_grade(int[, ,] image1, int[, ,] image2, int height, int width)
        {
            double result = LBP(image1, image2, height, width);
            return (int)(result * 100);
        }

        public static int LBP_grade(double result)
        {
            return (int)(result * 100);
        }

        public static double FR_method(string algorithm, int[, ,] image1, int[, ,] image2, int height, int width)
        {
            switch (algorithm)
            {
                case "PSNR":
                    {
                        return FR_algorithm.PSNR(image1, image2, height, width);
                    }
                case "LBP":
                    {
                        return FR_algorithm.LBP(image1, image2, height, width);
                    }
                default:
                    {
                        if (SettingInfo.dllHelper.FR_methods.ContainsKey(algorithm))
                        {
                            object reflectInstance = Activator.CreateInstance(SettingInfo.dllHelper.FR_methods[algorithm]);
                            MethodInfo methodInfo = SettingInfo.dllHelper.FR_methods[algorithm].GetMethod("FR_method",
                                new Type[] { typeof(int[, ,]), typeof(int[, ,]), typeof(int), typeof(int) });
                            return (double)methodInfo.Invoke(reflectInstance,
                                new object[] { image1, image2, height, width });
                        }
                        return -1;
                    }
            }
        }

        public static int FR_grade(string algorithm, double result)
        {
            switch (algorithm)
            {
                case "PSNR":
                    {
                        return FR_algorithm.PSNR_grade(result);
                    }
                case "LBP":
                    {
                        return FR_algorithm.LBP_grade(result);
                    }
                default:
                    {
                        if (SettingInfo.dllHelper.FR_methods.ContainsKey(algorithm))
                        {
                            object reflectInstance = Activator.CreateInstance(SettingInfo.dllHelper.FR_methods[algorithm]);
                            MethodInfo methodInfo = SettingInfo.dllHelper.FR_methods[algorithm].GetMethod("FR_grade",
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