﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace UI
{
    //自定义封装控件picturePanel，调用时先new picturePanel，将控件添加到父控件后，再调用init函数进行picturePanel的图片和文字显示(如果不需要显示文字参数传入null)
    class picturePanel : Panel
    {
        public PictureBox image;
        public Label image_name;
        int w;
        int h;
        public picturePanel()
        {
            this.Dock = DockStyle.Fill;
            image = new PictureBox();
            image_name = new Label();
            image.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Resize += resize;
        }

        public void init(Bitmap bitmap,string name)
        {
            if(bitmap==null)
            {
                return;
            }

            h = bitmap.Height;
            w = bitmap.Width;
            double F = (((double)this.Width - 15) / w) < ((double)(this.Height - 25) / h) ? ((double)this.Width - 15) / w : (double)(this.Height - 25) / h;
            image.Height = (int)(h * F);
            image.Width = (int)(w * F);

            image.Image = bitmap;
            image_name.Height = 15;
            image_name.Width = image.Width;
            image_name.TextAlign = ContentAlignment.MiddleCenter;
            image_name.Font = new Font("宋体", 10);
            image_name.Text = name;
            image.Anchor = AnchorStyles.None;
            image_name.Anchor = AnchorStyles.None;

            image.Location = new Point((this.Width - image.Width) / 2, (this.Height - 15 - image.Height) / 2);
            image_name.Location = new Point(image.Location.X, image.Location.Y + image.Height + 5);
            this.Controls.Add(image);
            this.Controls.Add(image_name);
        }

        private void resize(object sender, EventArgs e)
        {
            double F = (((double)this.Width - 15) / w) < ((double)(this.Height - 25) / h) ? ((double)this.Width - 15) / w : (double)(this.Height - 25) / h;
            image.Height = (int)(h * F);
            image.Width = (int)(w * F);
            image_name.Height = 15;
            image_name.Width = image.Width;
            image_name.TextAlign = ContentAlignment.MiddleCenter;
            image.Location = new Point((this.Width - image.Width) / 2, (this.Height - 15 - image.Height) / 2);
            image_name.Location = new Point(image.Location.X, image.Location.Y + image.Height + 5);
        }
    }
}
