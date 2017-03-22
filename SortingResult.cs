using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using System.Threading;
using System.IO;
using System.Collections;
using demo1;
using Microsoft.VisualBasic.FileIO;

namespace UI
{
    public partial class SortingResult : Form
    {
        private string _path;
        private int picNum = 0;
        private sortObject[] originArray;
        private sortObject[] sortedArray;
        private string[] originPicList;
        private string[] sortedPicList;
        EventHandler origin_e1; //双击单元格打开图片查看器
        EventHandler origin_e2; //双击单元格打开图片查看器
        EventHandler origin_e3; //双击单元格打开图片查看器
        EventHandler sorted_e1; //双击单元格打开图片查看器
        EventHandler sorted_e2; //双击单元格打开图片查看器
        EventHandler sorted_e3; //双击单元格打开图片查看器
        public SortingResult(int picNum, sortObject[] originArray, sortObject[] sortedArray)
        {
            InitializeComponent();
            _path = null;
            this.originArray = originArray;
            this.picNum = picNum;
            this.sortedArray = sortedArray;
            origin_e1 = new EventHandler(origin_item_double_click);
            origin_e2 = new EventHandler(origin_pictureBox_double_click);
            origin_e3 = new EventHandler(origin_label_double_click);
            sorted_e1 = new EventHandler(sorted_item_double_click);
            sorted_e2 = new EventHandler(sorted_pictureBox_double_click);
            sorted_e3 = new EventHandler(sorted_label_double_click);
        }

        public SortingResult(string _path, int picNum, sortObject[] originArray, sortObject[] sortedArray)
        {
            InitializeComponent();
            this._path = _path;
            this.picNum = picNum;
            this.originArray = originArray;
            this.sortedArray = sortedArray;
            origin_e1 = new EventHandler(origin_item_double_click);
            origin_e2 = new EventHandler(origin_pictureBox_double_click);
            origin_e3 = new EventHandler(origin_label_double_click);
            sorted_e1 = new EventHandler(sorted_item_double_click);
            sorted_e2 = new EventHandler(sorted_pictureBox_double_click);
            sorted_e3 = new EventHandler(sorted_label_double_click);
        }

        private void SortingResult_Load(object sender, EventArgs e)
        {
            //this.Width = (int)(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width * 0.95);
            //this.Height = (int)(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height * 0.9);
            //this.Location = new Point((System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 3 * 2, (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 3 * 2);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            beforeSortingPanel.Height = afterSortingPanel.Height = (int)(this.Height * 0.34);
            beforeSortingPanel.Width = afterSortingPanel.Width = beforeSortingPanel.Height * 4;
            beforeSortingPanel.Location = new Point((int)(this.Width * 0.01), (int)(this.Height * 0.1));
            afterSortingPanel.Location = new Point((int)(this.Width * 0.01), (int)(this.Height * 0.57));
            beforeSortingHint.Location = new Point((int)((beforeSortingPanel.Width - beforeSortingHint.Width) / 2 + beforeSortingPanel.Location.X), (int)(this.Height * 0.05));
            afterSortingHint.Location = new Point((int)((beforeSortingPanel.Width - beforeSortingHint.Width) / 2 + beforeSortingPanel.Location.X), (int)(this.Height * 0.52));
            referenceImage.Height = referenceImage.Width = (int)(this.Width * 0.9575 - beforeSortingPanel.Width);
            referenceImage.Location = new Point((int)(this.Width * 0.03 + beforeSortingPanel.Width - 5), (int)(this.Height * 0.33));
            hint.Location = new Point((int)(this.Width * 0.83), (int)(this.Height * 0.3));
            TableLayoutColumnStyleCollection columnstyles = beforeSortingPanel.ColumnStyles;
            foreach (ColumnStyle style in columnstyles)
            {
                style.SizeType = SizeType.Absolute;
                style.Width = beforeSortingPanel.Height;
            }
            columnstyles = afterSortingPanel.ColumnStyles;
            foreach (ColumnStyle style in columnstyles)
            {
                style.SizeType = SizeType.Absolute;
                style.Width = afterSortingPanel.Height;
            }

            if(_path != null)
            {
                picturePanel p = new picturePanel();
                referenceImage.Controls.Add(p);
                p.init(MainForm.picInfo[_path].image, MainForm.picInfo[_path].name);
                p.image_name.Font = new Font("微软雅黑", 17);
                p.image_name.Height = 32;
                hint.Text = "全参考排序参考图";
            }
            originPicList = new string[picNum];
            for (int i = 0; i < picNum; i++)
            {
                picturePanel p = new picturePanel(i);
                beforeSortingPanel.ColumnStyles.Insert(beforeSortingPanel.ColumnCount++, new ColumnStyle(SizeType.Absolute, beforeSortingPanel.Height));
                beforeSortingPanel.Controls.Add(p, i, 0);
                p.init(MainForm.picInfo[originArray[i].path].image, originArray[i].name);
                p.image_name.Height = 25;
                p.image_name.Font = new Font("微软雅黑", 13);
                p.DoubleClick += origin_e1;
                ((PictureBox)(p.Controls[0])).DoubleClick += origin_e2;
                ((Label)(p.Controls[1])).DoubleClick += origin_e3;
                originPicList[i] = originArray[i].path;
            }

            sortedPicList = new string[picNum];
            for (int i = 0; i < picNum; i++)
            {
                picturePanel p = new picturePanel(i);
                afterSortingPanel.ColumnStyles.Insert(afterSortingPanel.ColumnCount++, new ColumnStyle(SizeType.Absolute, afterSortingPanel.Height));
                afterSortingPanel.Controls.Add(p, i, 0);
                p.init(MainForm.picInfo[sortedArray[i].path].image, sortedArray[i].name);
                p.image_name.Height = 25;
                p.image_name.Font = new Font("微软雅黑", 13);
                p.DoubleClick += sorted_e1;
                ((PictureBox)(p.Controls[0])).DoubleClick += sorted_e2;
                ((Label)(p.Controls[1])).DoubleClick += sorted_e3;
                sortedPicList[i] = sortedArray[i].path;
            }
        }

        //双击单元格
        private void origin_item_double_click(object sender, EventArgs e)
        {
            picturePanel p = (picturePanel)sender;
            int position = p.id;
            Form imageshow = new ImageView(originPicList, position);
            imageshow.Size = new Size(1024, 800);//新窗口界面大小和原窗口同样大
            imageshow.Show();
        }

        //双击图片
        private void origin_pictureBox_double_click(object sender, EventArgs e)
        {
            PictureBox curPicture = (PictureBox)(sender);
            picturePanel p = (picturePanel)(curPicture.Parent);
            int position = p.id;
            Form imageshow = new ImageView(originPicList, position);
            imageshow.Size = new Size(1024, 800);//新窗口界面大小和原窗口同样大
            imageshow.Show();
        }

        //双击文字
        private void origin_label_double_click(object sender, EventArgs e)
        {
            picturePanel p = (picturePanel)(((Label)sender).Parent);
            int position = p.id;
            Form imageshow = new ImageView(originPicList, position);
            imageshow.Size = new Size(1024, 800);//新窗口界面大小和原窗口同样大
            imageshow.Show();
        }

        //双击单元格
        private void sorted_item_double_click(object sender, EventArgs e)
        {
            picturePanel p = (picturePanel)sender;
            int position = p.id;
            Form imageshow = new ImageView(sortedPicList, position);
            imageshow.Size = new Size(1024, 800);//新窗口界面大小和原窗口同样大
            imageshow.Show();
        }

        //双击图片
        private void sorted_pictureBox_double_click(object sender, EventArgs e)
        {
            PictureBox curPicture = (PictureBox)(sender);
            picturePanel p = (picturePanel)(curPicture.Parent);
            int position = p.id;
            Form imageshow = new ImageView(sortedPicList, position);
            imageshow.Size = new Size(1024, 800);//新窗口界面大小和原窗口同样大
            imageshow.Show();
        }

        //双击文字
        private void sorted_label_double_click(object sender, EventArgs e)
        {
            picturePanel p = (picturePanel)(((Label)sender).Parent);
            int position = p.id;
            Form imageshow = new ImageView(sortedPicList, position);
            imageshow.Size = new Size(1024, 800);//新窗口界面大小和原窗口同样大
            imageshow.Show();
        }

        private void SortingResult_Resize(object sender, EventArgs e)
        {
            beforeSortingPanel.Height = afterSortingPanel.Height = (int)(this.Height * 0.36);
            beforeSortingPanel.Width = afterSortingPanel.Width = beforeSortingPanel.Height * 4;
            beforeSortingPanel.Location = new Point((int)(this.Width * 0.01), (int)(this.Height * 0.1));
            afterSortingPanel.Location = new Point((int)(this.Width * 0.01), (int)(this.Height * 0.57));
            beforeSortingHint.Location = new Point((int)(this.Width * 0.35), (int)(this.Height * 0.05));
            afterSortingHint.Location = new Point((int)(this.Width * 0.35), (int)(this.Height * 0.51));
            referenceImage.Height = referenceImage.Width = (int)(this.Width * 0.95 - beforeSortingPanel.Width);
            referenceImage.Location = new Point((int)(this.Width * 0.03 + beforeSortingPanel.Width), (int)(this.Height * 0.33));
            hint.Location = new Point((int)(this.Width * 0.83), (int)(this.Height * 0.28));
            TableLayoutColumnStyleCollection columnstyles = beforeSortingPanel.ColumnStyles;
            foreach (ColumnStyle style in columnstyles)
            {
                style.SizeType = SizeType.Absolute;
                style.Width = beforeSortingPanel.Height;
            }
            columnstyles = afterSortingPanel.ColumnStyles;
            foreach (ColumnStyle style in columnstyles)
            {
                style.SizeType = SizeType.Absolute;
                style.Width = afterSortingPanel.Height;
            }
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
