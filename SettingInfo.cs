using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI
{
    public class SettingInfo
    {
        /*
         *
         * 用户设置的方法
         * 赋值为默认值
         */
        public static string image_clean_full = "PSNR";
        public static string image_clean_none = "tenengrad";
        public static string image_compress_full = "PSNR";
        public static string image_compare_none = "tenengrad";
        public static string image_sort_full = "PSNR";
        public static string image_sort_none = "tenengrad";

        public static int image_clean_full_selected = 0;
        public static int image_clean_none_selected = 0;
        public static int image_compress_full_selected = 0;
        public static int image_compare_none_selected = 0;
        public static int image_sort_full_selected = 0;
        public static int image_sort_none_selected = 0;

        public static string save_path = null;

        public static int SELECT_COMPRESS_FULL = 1;
        public static int SELECT_COMPRESS_NONE = 2;
        public static int SELECT_COMPRESS_METHOD;
        public static int SELECT_COMPRESS_SCORE = 4;
        public static int SELECT_COMPRESS_RATE = 5;
    }
}
