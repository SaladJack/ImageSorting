using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Microsoft.VisualBasic.FileIO;
using System.IO;

namespace HVS
{
    public partial class Compress_FR : Form
    {
        public string _path;
        public string _name;
        public string save_path;
        private const double size_rate = 0.85;
        private Dictionary<string, ImageFormat> imageformat = new Dictionary<string, ImageFormat>(); //图像格式字符串映射到c#库的图像格式的索引表
        Bitmap temp_image;
        picturePanel p1;
        picturePanel p2;

        //防止窗体闪烁
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public Compress_FR(string _path,string _name)
        {
            InitializeComponent();
            this._path = _path;
            this._name = _name;
            imageformat["JPEG"] = ImageFormat.Jpeg;
            imageformat["PNG"] = ImageFormat.Png;
            radioButton1.Checked = true;
            radioButton2.Checked = false;
        }

        private void compressForm_none_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            format_selection.DropDownStyle = ComboBoxStyle.DropDownList;
            uncompressed_image.Width = uncompressed_image.Height = compressed_image.Width = compressed_image.Height = (int)(this.Height * 0.65);
            uncompressed_image.Location = new Point((int)(this.Width * 0.1), (int)(this.Height * 0.02));
            compressed_image.Location = new Point((int)(this.Width * 0.55), (int)(this.Height * 0.02));
            image_format.Location = new Point((int)(this.Width * 0.352), (int)(this.Height * 0.7));
            format_selection.Location = new Point((int)(this.Width * 0.46), (int)(this.Height * 0.7));
            hint1.Location = new Point((int)(image_format.Location.X + image_format.Width - hint1.Width), (int)(this.Height * 0.76));
            hint2.Location = new Point((int)(image_format.Location.X + image_format.Width - hint2.Width), (int)(this.Height * 0.82));
            rate_bar1.Location = new Point((int)(format_selection.Location.X + (format_selection.Width - rate_bar1.Width) / 2), (int)(this.Height * 0.76));
            rate_bar2.Location = new Point((int)(format_selection.Location.X + (format_selection.Width - rate_bar2.Width) / 2), (int)(this.Height * 0.82));
            rate1.Location = new Point((int)(this.Width * 0.59), (int)(this.Height * 0.76));
            rate2.Location = new Point((int)(this.Width * 0.59), (int)(this.Height * 0.82));
            algorithm_value.Location = new Point((int)(this.Width * 0.65), (int)(this.Height * 0.82)); 
            radioButton1.Location = new Point((int)(this.Width * 0.625), (int)(this.Height * 0.769));
            radioButton2.Location = new Point((int)(this.Width * 0.625), (int)(this.Height * 0.829));
            save.Location = new Point((int)(this.Width * 0.42), (int)(this.Height * 0.89));
            cancel.Location = new Point((int)(this.Width * 0.55), (int)(this.Height * 0.89));

            if (SettingInfo.save_path == "default")
            {
                save_path = "default" + "\\" + _name + "(compressed)." + format_selection.Text;
                if (Directory.Exists("default") == false)
                {
                    Directory.CreateDirectory("default");
                }
            }
            else
            {
                save_path = SettingInfo.save_path + "\\" + _name + "(compressed)." + format_selection.Text;
            }

            p1 = new picturePanel();
            uncompressed_image.Controls.Add(p1);
            p1.init(MainInfo.picInfo[_path].image, "原图".ToString());
            p1.image_name.Font = new Font("微软雅黑", 17);
            p1.image_name.Height = 32;
            p1.image_name.Location = new Point((p1.image.Location.X), (p1.image.Location.Y + 20 + p1.image.Height));
            p1.image_name.Dock = DockStyle.None;

            p2 = new picturePanel();
            compressed_image.Controls.Add(p2);
            p2.image_name.Font = new Font("微软雅黑", 17);
            p2.image_name.Height = 32;
            p2.image_name.Location = new Point((p2.image.Location.X), (p2.image.Location.Y + 20 + p2.image.Height));
            p2.image_name.Dock = DockStyle.None;
            temp_image = new Bitmap(MainInfo.picInfo[_path].compress(50, imageformat[format_selection.Text]));
            ((picturePanel)(compressed_image.Controls[0])).init(temp_image, "预览".ToString());
            picturePanel tempP = (picturePanel)(compressed_image.Controls[0]);
            tempP.image_name.Font = new Font("微软雅黑", 17);
            tempP.image_name.Height = 32;
            tempP.image_name.Dock = DockStyle.None;
            tempP.image_name.Location = new Point((tempP.image.Location.X), tempP.image.Location.Y + tempP.image.Height + 20);

            temp_image = new Bitmap(MainInfo.picInfo[_path].compress(100 - (Int64)rate_bar1.Value, imageformat[format_selection.Text]));
            ((picturePanel)(compressed_image.Controls[0])).init(temp_image, "预览".ToString());
            tempP = (picturePanel)(compressed_image.Controls[0]);
            tempP.image_name.Font = new Font("微软雅黑", 17);
            tempP.image_name.Height = 32;
            tempP.image_name.Dock = DockStyle.None;
            tempP.image_name.Location = new Point((tempP.image.Location.X), tempP.image.Location.Y + tempP.image.Height + 20);
            Pic pic = new Pic(temp_image);
            double result = FR_algorithm.FR_method(SettingInfo.imageCompress_FRmethod, MainInfo.picInfo[_path].rgb, pic.rgb, pic.height, pic.width);
            int grade = FR_algorithm.FR_grade(SettingInfo.imageCompress_FRmethod, result);
            rate_bar2.Value = grade;
            rate2.Text = rate_bar2.Value.ToString();
            algorithm_value.Text = "(" + SettingInfo.imageCompress_FRmethod + "值：" + result.ToString("f4") + ")";
        }

        //更新压缩程度/质量分数进度条对应的数值
        private void rate_bar1_Scroll(object sender, EventArgs e)
        {
            rate1.Text = rate_bar1.Value.ToString();
            if(radioButton1.Checked)
            {
                temp_image = new Bitmap(MainInfo.picInfo[_path].compress(100 - (Int64)rate_bar1.Value, imageformat[format_selection.Text]));
                ((picturePanel)(compressed_image.Controls[0])).init(temp_image, "预览".ToString());

                picturePanel tempP = (picturePanel)(compressed_image.Controls[0]);
                tempP.image_name.Font = new Font("微软雅黑", 17);
                tempP.image_name.Height = 32;
                tempP.image_name.Dock = DockStyle.None;
                tempP.image_name.Location = new Point((tempP.image.Location.X), tempP.image.Location.Y + tempP.image.Height + 20);

                Pic pic = new Pic(temp_image);
                double result = FR_algorithm.FR_method(SettingInfo.imageCompress_FRmethod, MainInfo.picInfo[_path].rgb, pic.rgb, pic.height, pic.width);
                int grade = FR_algorithm.FR_grade(SettingInfo.imageCompress_FRmethod, result);
                rate_bar2.Value = grade;
                rate2.Text = rate_bar2.Value.ToString();
                algorithm_value.Text = "(" + SettingInfo.imageCompress_FRmethod + "值：" + result.ToString("f4") + ")";
            }
        }

        private void rate_bar2_Scroll(object sender, EventArgs e)
        {
            rate2.Text = rate_bar2.Value.ToString();
            double result = 0;
            int grade = 0;
            if (radioButton2.Checked)
            {
                int l = 0, r = 100, mid;
                while (l != r)
                {
                    mid = (l + r) >> 1;
                    temp_image = new Bitmap(MainInfo.picInfo[_path].compress((Int64)(mid + 1), imageformat[format_selection.Text]));
                    Pic pic = new Pic(temp_image);
                    result = FR_algorithm.FR_method(SettingInfo.imageCompress_FRmethod, MainInfo.picInfo[_path].rgb, pic.rgb, pic.height, pic.width);
                    grade = FR_algorithm.FR_grade(SettingInfo.imageCompress_FRmethod, result);
                    if (grade > rate_bar2.Value)
                    {
                        r = mid;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }
                ((picturePanel)(compressed_image.Controls[0])).init(temp_image, "预览".ToString());
                picturePanel tempP = (picturePanel)(compressed_image.Controls[0]);
                tempP.image_name.Font = new Font("微软雅黑", 17);
                tempP.image_name.Height = 32;
                tempP.image_name.Dock = DockStyle.None;
                tempP.image_name.Location = new Point((tempP.image.Location.X), tempP.image.Location.Y + tempP.image.Height + 20);

                rate_bar1.Value = 100 - l;
                rate1.Text = rate_bar1.Value.ToString();
                algorithm_value.Text = "(" + SettingInfo.imageCompress_FRmethod + "值：" + result.ToString("f4") + ")";
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            temp_image = new Bitmap(MainInfo.picInfo[_path].compress(100 - (Int64)rate_bar1.Value, imageformat[format_selection.Text]));
            ((picturePanel)(compressed_image.Controls[0])).init(temp_image, "预览".ToString());
            picturePanel tempP = (picturePanel)(compressed_image.Controls[0]);
            tempP.image_name.Font = new Font("微软雅黑", 17);
            tempP.image_name.Height = 32;
            tempP.image_name.Dock = DockStyle.None;
            tempP.image_name.Location = new Point((tempP.image.Location.X), tempP.image.Location.Y + tempP.image.Height + 20);

            Pic pic = new Pic(temp_image);
            double result = FR_algorithm.FR_method(SettingInfo.imageCompress_FRmethod, MainInfo.picInfo[_path].rgb, pic.rgb, pic.height, pic.width);
            int grade = FR_algorithm.FR_grade(SettingInfo.imageCompress_FRmethod, result);
            rate_bar2.Value = grade;
            rate2.Text = rate_bar2.Value.ToString();
            algorithm_value.Text = "(" + SettingInfo.imageCompress_FRmethod + "值：" + result.ToString("f4") + ")";
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = true;
            int l = 0, r = 100, mid;
            double result = 0;
            int grade = 0;
            while (l != r)
            {
                mid = (l + r) >> 1;
                temp_image = new Bitmap(MainInfo.picInfo[_path].compress((Int64)(mid + 1), imageformat[format_selection.Text]));
                Pic pic = new Pic(temp_image);
                result = FR_algorithm.FR_method(SettingInfo.imageCompress_FRmethod, MainInfo.picInfo[_path].rgb, pic.rgb, pic.height, pic.width);
                grade = FR_algorithm.FR_grade(SettingInfo.imageCompress_FRmethod, result);
                if (grade > rate_bar2.Value)
                {
                    r = mid;
                }
                else
                {
                    l = mid + 1;
                }
            }
            ((picturePanel)(compressed_image.Controls[0])).init(temp_image, "预览".ToString());
            picturePanel tempP = (picturePanel)(compressed_image.Controls[0]);
            tempP.image_name.Font = new Font("微软雅黑", 17);
            tempP.image_name.Height = 32;
            tempP.image_name.Dock = DockStyle.None;
            tempP.image_name.Location = new Point((tempP.image.Location.X), tempP.image.Location.Y + tempP.image.Height + 20);

            rate_bar1.Value = 100 - l;
            rate1.Text = rate_bar1.Value.ToString();
            algorithm_value.Text = "(" + SettingInfo.imageCompress_FRmethod + "值：" + result.ToString("f4") + ")";
        }

        private void save_Click(object sender, EventArgs e)
        {
            temp_image.Save(save_path, imageformat[format_selection.Text]);
            this.Close();
            this.Dispose();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x112 && (int)m.WParam == 0xf122)
            {
                m.WParam = IntPtr.Zero;
                return;
            }
            base.WndProc(ref m);
        }
    }
}