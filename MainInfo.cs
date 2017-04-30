using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVS
{
    public class MainInfo
    {
        public static int tot = 0; //图片数
        public static bool[] selected; //每张图片是否被选中，true表示被选中，false表示没被选中
        public static string[] name; //图片名字
        public static string[] path_name; //图片路径，记录第i张图片的地址
        public static Dictionary<string, Pic> picInfo; //图片信息，键值对<图片路径,Pic对象>，可以根据路径名得到图片信息，包括图片的bitmap类对象(封装在Pic类中)，可用于控件的图像展示
    }
}
