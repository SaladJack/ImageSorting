using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HVS
{
    public class SettingInfo
    {
        /*
            * 用户设置的方法
            * 赋值为默认值
        */
        public static string imageClear_FRmethod = "PSNR";
        public static string imageClear_NRmethod = "Tenengrad";
        public static string imageCompress_FRmethod = "PSNR";
        public static string imageCompare_NRmethod = "Tenengrad";
        public static string imageSort_FRmethod = "PSNR";
        public static string imageSort_NRmethod = "Tenengrad";
        public static string save_path = "default";

        public static string FR_dll_path = Directory.GetCurrentDirectory() + "\\FR_dll";
        public static string RR_dll_path = Directory.GetCurrentDirectory() + "\\RR_dll";
        public static string NR_dll_path = Directory.GetCurrentDirectory() + "\\NR_dll";
        public static dllHelper dllHelper = new dllHelper(FR_dll_path, RR_dll_path, NR_dll_path); //算法dll
    }
}
