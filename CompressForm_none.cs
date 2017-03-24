using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using demo1;
using Microsoft.VisualBasic.FileIO;
using System.IO;

namespace UI
{
    public partial class CompressForm_none : Form
    {
        public string _path;
        public string _name;
        public string save_path;
        private const double size_rate = 0.85;
        Dictionary<string, ImageFormat> imageformat = new Dictionary<string, ImageFormat>(); //图像格式字符串映射到c#库的图像格式的索引表
        Bitmap temp_image;
        picturePanel p1;
        picturePanel p2;
        public CompressForm_none(string _path,string _name)
        {
            InitializeComponent();
            this._path = _path;
            this._name = _name;
            imageformat["jpeg"] = ImageFormat.Jpeg;
            imageformat["png"] = ImageFormat.Png;
            imageformat["bmp"] = ImageFormat.Bmp;
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            SettingInfo.SELECT_COMPRESS_METHOD = SettingInfo.SELECT_COMPRESS_RATE;
        }

        //更新压缩程度/质量分数进度条对应的数值
        private void rate_bar1_Scroll(object sender, EventArgs e)
        {
            rate1.Text = rate_bar1.Value.ToString();
            if(radioButton1.Checked)
            {
                temp_image = new Bitmap(MainForm.picInfo[_path].compress(rate_bar1.Value, 100, format_selection.Text));
                ((picturePanel)(compressed_image.Controls[0])).init(temp_image, save_path);
            }
        }

        private void rate_bar2_Scroll(object sender, EventArgs e)
        {
            rate2.Text = rate_bar2.Value.ToString();
            if (radioButton2.Checked)
            {
                int T = 6;
                int l = 0, r = 100, mid = (l + r) >> 1;
                double baseGrade = MainForm.picInfo[_path].tenengrad();
                for (int i = 0; i < T; i++)
                {
                    mid = (l + r) >> 1;
                    temp_image = new Bitmap(MainForm.picInfo[_path].compress(mid, 100, format_selection.Text));
                    Pic pic = new Pic(temp_image);
                    double grade = pic.tenengrad();
                    if (grade / baseGrade * 100 > rate_bar2.Value)
                    {
                        r = mid;
                    }
                    else
                    {
                        l = mid;
                    }
                }
                ((picturePanel)(compressed_image.Controls[0])).init(temp_image, save_path);
            }
        }

        private void compressForm_none_Load(object sender, EventArgs e)
        {
            //this.Width = (int)(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width * size_rate);
            //this.Height = (int)(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height * size_rate);
            //this.Location = new Point((System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 3 * 2, (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 3 * 2);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            uncompressed_image.Width = uncompressed_image.Height = compressed_image.Width = compressed_image.Height = (int)(this.Height * 0.6);
            uncompressed_image.Location = new Point((int)(this.Width * 0.1), (int)(this.Height * 0.02));
            compressed_image.Location = new Point((int)(this.Width * 0.55), (int)(this.Height * 0.02));
            before_compress_hint.Location = new Point((int)(this.Width * 0.22), (int)(this.Height * 0.64));
            after_compress_hint.Location = new Point((int)(this.Width * 0.68), (int)(this.Height * 0.64));
            image_format.Location = new Point((int)(this.Width * 0.352), (int)(this.Height * 0.7));
            format_selection.Location = new Point((int)(this.Width * 0.46), (int)(this.Height * 0.7));
            hint1.Location = new Point((int)(image_format.Location.X + image_format.Width - hint1.Width), (int)(this.Height * 0.76));
            hint2.Location = new Point((int)(image_format.Location.X + image_format.Width - hint2.Width), (int)(this.Height * 0.82));
            rate_bar1.Location = new Point((int)(format_selection.Location.X + (format_selection.Width - rate_bar1.Width) / 2), (int)(this.Height * 0.76));
            rate_bar2.Location = new Point((int)(format_selection.Location.X + (format_selection.Width - rate_bar2.Width) / 2), (int)(this.Height * 0.82));
            rate1.Location = new Point((int)(this.Width * 0.59), (int)(this.Height * 0.76));
            rate2.Location = new Point((int)(this.Width * 0.59), (int)(this.Height * 0.82));
            radioButton1.Location = new Point((int)(this.Width * 0.62), (int)(this.Height * 0.766));
            radioButton2.Location = new Point((int)(this.Width * 0.62), (int)(this.Height * 0.826));
            save.Location = new Point((int)(this.Width * 0.42), (int)(this.Height * 0.89));
            cancel.Location = new Point((int)(this.Width * 0.55), (int)(this.Height * 0.89));

            if (SettingInfo.save_path == null)
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
            p1.init(MainForm.picInfo[_path].image, _path);
            p1.image_name.Font = new Font("微软雅黑", 17);
            p1.image_name.Height = 32;
            p2 = new picturePanel();
            compressed_image.Controls.Add(p2);
            p2.image_name.Font = new Font("微软雅黑", 17);
            p2.image_name.Height = 32;

            if (radioButton1.Checked)
            {
                temp_image = new Bitmap(MainForm.picInfo[_path].compress(rate_bar1.Value, 100, format_selection.Text));
                ((picturePanel)(compressed_image.Controls[0])).init(temp_image, save_path);
            }
            else
            {
                int T = 6;
                int l = 0, r = 100, mid = (l + r) >> 1;
                double baseGrade = MainForm.picInfo[_path].tenengrad();
                for (int i = 0; i < T; i++)
                {
                    mid = (l + r) >> 1;
                    temp_image = new Bitmap(MainForm.picInfo[_path].compress(mid, 100, format_selection.Text));
                    Pic pic = new Pic(temp_image);
                    double grade = pic.tenengrad();
                    if (grade / baseGrade * 100 > rate_bar2.Value)
                    {
                        r = mid;
                    }
                    else
                    {
                        l = mid;
                    }
                }
                ((picturePanel)(compressed_image.Controls[0])).init(temp_image, save_path);
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            /*
            if (SettingInfo.SELECT_COMPRESS_METHOD == SettingInfo.SELECT_COMPRESS_RATE)
            {
                if (rate_bar1.Value == 0)
                {
                    MessageBox.Show("压缩率不能为0!");
                    return;
                }
                Bitmap new_image = new Bitmap(MainForm.picInfo[_path].compress(rate_bar1.Value, 100, format_selection.Text));
                new_image.Save(SettingInfo.save_path + "\\" + _name + "compressed_image." + format_selection.Text, imageformat[format_selection.Text]);
                ((picturePanel)(compressed_image.Controls[0])).init(new_image, _name);
            }
            else if (SettingInfo.SELECT_COMPRESS_METHOD == SettingInfo.SELECT_COMPRESS_SCORE)
            {
                if (rate_bar2.Value == 0)
                {
                    MessageBox.Show("质量分数不能为0!");
                    return;
                }
                int T = 6;
                int l = 0, r = 100, mid = (l + r) >> 1;
                double baseGrade = MainForm.picInfo[_path].tenengrad();
                for(int i= 0 ; i < T; i++)
                {
                    mid = (l + r) >> 1;
                    temp_image = new Bitmap(MainForm.picInfo[_path].compress(mid, 100, format_selection.Text));
                    Pic pic = new Pic(temp_image);
                    double grade = pic.tenengrad();
                    if (grade / baseGrade * 100 > rate_bar2.Value)
                    {
                        r = mid;
                    }
                    else
                    {
                        l = mid;
                    }
                }
                ((picturePanel)(compressed_image.Controls[0])).init(temp_image, _name);
                temp_image.Save(SettingInfo.save_path + "\\" + _name + "compressed_image." + format_selection.Text, imageformat[format_selection.Text]);
            }
            */
            if (!imageformat.ContainsKey(format_selection.Text))
            {
                MessageBox.Show("不存在" + format_selection.Text + "的图片格式选项");
                return;
            }
            temp_image.Save(save_path, imageformat[format_selection.Text]);
            this.Close();
            this.Dispose();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            ((Button)sender).Parent.Dispose();
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            temp_image = new Bitmap(MainForm.picInfo[_path].compress(rate_bar1.Value, 100, format_selection.Text));
            ((picturePanel)(compressed_image.Controls[0])).init(temp_image, save_path);
            SettingInfo.SELECT_COMPRESS_METHOD = SettingInfo.SELECT_COMPRESS_RATE;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = true;
            int T = 6;
            int l = 0, r = 100, mid = (l + r) >> 1;
            double baseGrade = MainForm.picInfo[_path].tenengrad();
            for (int i = 0; i < T; i++)
            {
                mid = (l + r) >> 1;
                temp_image = new Bitmap(MainForm.picInfo[_path].compress(mid, 100, format_selection.Text));
                Pic pic = new Pic(temp_image);
                double grade = pic.tenengrad();
                if (grade / baseGrade * 100 > rate_bar2.Value)
                {
                    r = mid;
                }
                else
                {
                    l = mid;
                }
            }
            ((picturePanel)(compressed_image.Controls[0])).init(temp_image, save_path);
            SettingInfo.SELECT_COMPRESS_METHOD = SettingInfo.SELECT_COMPRESS_SCORE;
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