using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class ClearSetting : Form
    {
        public sortObject[] sortedArray;
        private int type = 1;
        public ClearSetting()
        {
            InitializeComponent();
        }

        public ClearSetting(MainForm _mf)
        {
            InitializeComponent();
            mf = _mf;
            type = 1;
        }

        public ClearSetting(MainForm mf,string referenceImage)
        {
            InitializeComponent();
            this.mf = mf;
            this.referenceImage = referenceImage;
            type = 2;
        }

        private void clearRatioBar_Scroll(object sender, EventArgs e)
        {
            ratio.Text = clearRatioBar.Value.ToString() + "%";
            MainForm.clear_ratio = clearRatioBar.Value;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            Dispose();
            int tot = 0;
            for(int i = 0; i < MainForm.tot; i++)
            {
                if(MainForm.selected[i])
                {
                    tot++;
                }
            }
            sortObject[] sortedArray = new sortObject[tot];
            int index = 0;
            if (type == 1)
            {
                for (int i = 0; i < MainForm.tot; i++)
                {
                    if (MainForm.selected[i])
                    {
                        if (!MainForm.picInfo[MainForm.path_name[i]].state_none)
                        {
                            MainForm.picInfo[MainForm.path_name[i]].grade_none = MainForm.picInfo[MainForm.path_name[i]].tenengrad();
                            MainForm.picInfo[MainForm.path_name[i]].state_none = true;
                        }
                        sortedArray[index++] = new sortObject(MainForm.picInfo[MainForm.path_name[i]].grade_none, MainForm.path_name[i], MainForm.name[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < MainForm.tot; i++)
                {
                    if (MainForm.selected[i])
                    {
                        //图像全参考评分
                        if (SettingInfo.image_clean_full == "PSNR")
                        {
                            MainForm.picInfo[MainForm.path_name[i]].grade_full = MainForm.picInfo[MainForm.path_name[i]].psnr(MainForm.picInfo[referenceImage]);
                        }
                        else
                        {
                            MainForm.picInfo[MainForm.path_name[i]].grade_full = MainForm.picInfo[MainForm.path_name[i]].LBPdiffer(MainForm.picInfo[referenceImage]);
                        }
                        MainForm.picInfo[MainForm.path_name[i]].state_full = true;
                        sortedArray[index++] = new sortObject(MainForm.picInfo[MainForm.path_name[i]].grade_full, MainForm.path_name[i], MainForm.name[i]);
                    }
                }
                MainForm.previous_pic = referenceImage;
            }
            Array.Sort(sortedArray, new sortObjectComparer());
            ImageDeleteComfirmForm imageDeleteComfirmForm = new ImageDeleteComfirmForm(clearRatioBar.Value, mf, sortedArray);
            imageDeleteComfirmForm.Show();
        }
    }
}
