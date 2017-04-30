using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.IO;
namespace HVS
{
    public partial class ImageView : Form
    {
        private string[] picList;
        private int position;
        public ImageView(string[] picList,int position)
        {
            this.WindowState = FormWindowState.Maximized;
            this.picList = picList;
            this.position = position;
            InitializeComponent();
        }
        
        //显示双击的图片
        private void ImageView_Load(object sender, EventArgs e)
        {
            //控制图片大小以及按钮大小
           
            int formWidth=this.Width;
            int formHeight=this.Height;
            int height = (int)(((double)formHeight - 50) / 2-25);
            string path = picList[position];
            this.tableLayoutPanel1.Width = formWidth;
            this.tableLayoutPanel1.Height = formHeight;
            this.leftButton.Margin = new Padding(0, height, 0, 0);
            this.leftButton.Height = 50;
            this.rightButton.Margin = new Padding(0, height, 0, 0);
            this.rightButton.Height = 50;
            this.TopMost = true;
          //  this.imageButton1.Height = formHeight;
          //  this.imageButton2.Height= formHeight;
            

            //窗口名称是当前图片名称
            this.Text = "图片浏览器 - " + MainInfo.picInfo[path].name;
            
            //将所点击的图片添加到picturebox
            PictureBox image = this.pictureBox1;
            image.Image = MainInfo.picInfo[path].image;
            //左右图片按钮显示
            if (position == 0)
            {
                this.leftButton.Visible = false;
            }
            else
            {
                this.leftButton.Visible = true;
            }
            if (position == picList.Length - 1)
            {
                this.rightButton.Visible = false;
            }
            else
            {
                this.rightButton.Visible = true;
            }
        }

        //窗口大小自适应
        private void ImageView_Resize(object sender, EventArgs e) 
        {
            int formWidth = this.Width;
            int formHeight = this.Height;
            int height=(int)(((double)formHeight - 50) / 2 - 25);
            //设置左部整个pannel与窗体大小一致，并设置两个上下按钮高度与窗口高度一致
            this.tableLayoutPanel1.Location = new Point(0, 0);
            this.tableLayoutPanel1.Width = formWidth;
            this.tableLayoutPanel1.Height = formHeight;
            
            this.leftButton.Margin = new Padding(0, height, 0, 0);
            this.leftButton.Height = 50;
            this.rightButton.Margin = new Padding(0, height, 0, 0);
            this.rightButton.Height = 50;
            //this.imageButton2.Height = formHeight;
 
        }

        //上一张图片
        private void imageButton1_Click(object sender, EventArgs e)
        {
            left_shift();
        }

        //下一张图片
        private void imageButton2_Click(object sender, EventArgs e)
        {
            right_shift();
        }

        public void left_shift()
        {
            //position指第几张图片，0~length-1
            if (position <= 0)
            {
                this.leftButton.Visible = false;
            }
            else
            {
                position--;
                if (position < picList.Length - 1)
                {
                    this.rightButton.Visible = true;
                }
                string path = picList[position];
                this.Text = "图片浏览器 - " + MainInfo.picInfo[path].name;
                PictureBox image = this.pictureBox1;

                image.Image = MainInfo.picInfo[path].image;
                if (position <= 0)
                {
                    this.leftButton.Visible = false;
                }
            }
        }

        public void right_shift()
        {
            if (position >= picList.Length - 1)
            {
                this.rightButton.Visible = false;
            }
            else
            {
                position++;
                if (position >= 0)
                {
                    this.leftButton.Visible = true;
                }
                string path = picList[position];
                this.Text = "图片浏览器 - " + MainInfo.picInfo[path].name;
                PictureBox image = this.pictureBox1;

                image.Image = MainInfo.picInfo[path].image;
                if (position >= picList.Length - 1)
                {
                    this.rightButton.Visible = false;
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                left_shift();
            }
            else if (keyData == Keys.Right)
            {
                right_shift();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
