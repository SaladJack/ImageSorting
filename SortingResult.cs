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
using HVS;
using Microsoft.VisualBasic.FileIO;

namespace HVS
{
    public partial class SortingResult : Form
    {
        private string _path = null;
        private int picNum = 0;
        private SortObject[] originArray;
        private SortObject[] sortedArray;
        private string[] originPicList;
        private string[] sortedPicList;
        private int progress;
        EventHandler origin_e1; //双击单元格打开图片查看器
        EventHandler origin_e2; //双击单元格打开图片查看器
        EventHandler origin_e3; //双击单元格打开图片查看器
        EventHandler sorted_e1; //双击单元格打开图片查看器
        EventHandler sorted_e2; //双击单元格打开图片查看器
        EventHandler sorted_e3; //双击单元格打开图片查看器

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

        //排序进度条更新线程
        public void progress_thread()
        {
            SortingProgress sp = new SortingProgress();
            sp.Show();
            sp.Refresh();
            while (true)
            {
                if (progress < 1000)
                {
                    sp.sortingProgressBar.Value = progress;
                }
                else
                {
                    sp.Dispose();
                    break;
                }
                Thread.Sleep(50);
            }
        }

        public SortingResult()
        {
            InitializeComponent();
            _path = null;
            picNum = 0;
            for(int i = 0; i < MainInfo.tot; i++)
            {
                if(MainInfo.selected[i])
                {
                    picNum++;
                }
            }
            progress = 0;
            int id = 0;
            Thread progressThread = new Thread(progress_thread);
            progressThread.IsBackground = true;
            progressThread.Start();
            originArray = new SortObject[picNum];
            sortedArray = new SortObject[picNum];
            for (int i = 0; i < MainInfo.tot; i++)
            {
                if (MainInfo.selected[i])
                {
                    double result = NR_algorithm.NR_method(
                        SettingInfo.imageSort_NRmethod,
                        MainInfo.picInfo[MainInfo.path_name[i]].rgb,
                        MainInfo.picInfo[MainInfo.path_name[i]].height,
                        MainInfo.picInfo[MainInfo.path_name[i]].width);
                    MainInfo.picInfo[MainInfo.path_name[i]].grade_none = NR_algorithm.NR_grade(SettingInfo.imageSort_NRmethod, result);
                    originArray[id] = new SortObject(MainInfo.picInfo[MainInfo.path_name[i]].grade_none, MainInfo.path_name[i], MainInfo.name[i]);
                    sortedArray[id++] = new SortObject(MainInfo.picInfo[MainInfo.path_name[i]].grade_none, MainInfo.path_name[i], MainInfo.name[i]);
                }
                progress = 1000 * id / picNum;
            }
            Array.Sort(sortedArray, new sortObjectComparer()); //图片排序调用
            origin_e1 = new EventHandler(origin_item_double_click);
            origin_e2 = new EventHandler(origin_pictureBox_double_click);
            origin_e3 = new EventHandler(origin_label_double_click);
            sorted_e1 = new EventHandler(sorted_item_double_click);
            sorted_e2 = new EventHandler(sorted_pictureBox_double_click);
            sorted_e3 = new EventHandler(sorted_label_double_click);
        }

        public SortingResult(string _path)
        {
            InitializeComponent();
            this._path = _path;
            picNum = 0;
            for (int i = 0; i < MainInfo.tot; i++)
            {
                if (MainInfo.selected[i])
                {
                    picNum++;
                }
            }
            progress = 0;
            int id = 0;
            Thread progressThread = new Thread(progress_thread);
            progressThread.IsBackground = true;
            progressThread.Start();
            originArray = new SortObject[picNum];
            sortedArray = new SortObject[picNum];
            for (int i = 0; i < MainInfo.tot; i++)
            {
                if (MainInfo.selected[i])
                {
                    MainInfo.picInfo[MainInfo.path_name[i]].grade_full = FR_algorithm.FR_method(
                        SettingInfo.imageSort_FRmethod,
                        MainInfo.picInfo[MainInfo.path_name[i]].rgb,
                        MainInfo.picInfo[_path].rgb,
                        MainInfo.picInfo[_path].height,
                        MainInfo.picInfo[_path].width);
                    originArray[id] = new SortObject(MainInfo.picInfo[MainInfo.path_name[i]].grade_full, MainInfo.path_name[i], MainInfo.name[i]);
                    sortedArray[id++] = new SortObject(MainInfo.picInfo[MainInfo.path_name[i]].grade_full, MainInfo.path_name[i], MainInfo.name[i]);
                    progress = 1000 * id / picNum;
                }
            }
            Array.Sort(sortedArray, new sortObjectComparer()); //图片排序调用
            origin_e1 = new EventHandler(origin_item_double_click);
            origin_e2 = new EventHandler(origin_pictureBox_double_click);
            origin_e3 = new EventHandler(origin_label_double_click);
            sorted_e1 = new EventHandler(sorted_item_double_click);
            sorted_e2 = new EventHandler(sorted_pictureBox_double_click);
            sorted_e3 = new EventHandler(sorted_label_double_click);
        }

        private void SortingResult_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            beforeSortingPanel.Height = afterSortingPanel.Height = (int)(this.Height * 0.34);
            beforeSortingPanel.Width = afterSortingPanel.Width = beforeSortingPanel.Height * 5;
            beforeSortingPanel.Location = new Point((int)(this.Width * 0.01), (int)(this.Height * 0.1));
            afterSortingPanel.Location = new Point((int)(this.Width * 0.01), (int)(this.Height * 0.57));
            beforeSortingHint.Location = new Point((int)((beforeSortingPanel.Width - beforeSortingHint.Width) / 2 + beforeSortingPanel.Location.X), (int)(this.Height * 0.05));
            afterSortingHint.Location = new Point((int)((beforeSortingPanel.Width - beforeSortingHint.Width) / 2 + beforeSortingPanel.Location.X), (int)(this.Height * 0.52));
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
                p.init(MainInfo.picInfo[_path].image, MainInfo.picInfo[_path].name);
                p.image_name.Font = new Font("微软雅黑", 17);
                p.image_name.Height = 32;
            }
            if (_path == null)
            {
                originPicList = new string[picNum];
                for (int i = 0; i < picNum; i++)
                {
                    picturePanel p = new picturePanel(i);
                    beforeSortingPanel.ColumnStyles.Insert(beforeSortingPanel.ColumnCount++, new ColumnStyle(SizeType.Absolute, beforeSortingPanel.Height));
                    beforeSortingPanel.Controls.Add(p, i, 0);
                    p.init(MainInfo.picInfo[originArray[i].path].image, originArray[i].name);
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
                    p.init(MainInfo.picInfo[sortedArray[i].path].image, sortedArray[i].name);
                    p.image_name.Height = 25;
                    p.image_name.Font = new Font("微软雅黑", 13);
                    p.DoubleClick += sorted_e1;
                    ((PictureBox)(p.Controls[0])).DoubleClick += sorted_e2;
                    ((Label)(p.Controls[1])).DoubleClick += sorted_e3;
                    sortedPicList[i] = sortedArray[i].path;
                }
            }
            else 
            {
                originPicList = new string[picNum + 1];
                picturePanel pp = new picturePanel(0);
                beforeSortingPanel.ColumnStyles.Insert(beforeSortingPanel.ColumnCount++, new ColumnStyle(SizeType.Absolute, beforeSortingPanel.Height));
                beforeSortingPanel.Controls.Add(pp, 0, 0);
                pp.init(MainInfo.picInfo[_path].image, "参考图像");
                pp.image_name.Height = 25;
                pp.image_name.Font = new Font("微软雅黑", 13);
                pp.DoubleClick += origin_e1;
                pp.BackColor = Color.Gray;
                ((PictureBox)(pp.Controls[0])).DoubleClick += origin_e2;
                ((Label)(pp.Controls[1])).DoubleClick += origin_e3;
                originPicList[0] = _path;
                for (int i = 0; i < picNum; i++)
                {
                    picturePanel p = new picturePanel(i + 1);
                    beforeSortingPanel.ColumnStyles.Insert(beforeSortingPanel.ColumnCount++, new ColumnStyle(SizeType.Absolute, beforeSortingPanel.Height));
                    beforeSortingPanel.Controls.Add(p, i + 1, 0);
                    p.init(MainInfo.picInfo[originArray[i].path].image, originArray[i].name);
                    p.image_name.Height = 25;
                    p.image_name.Font = new Font("微软雅黑", 13);
                    p.DoubleClick += origin_e1;
                    ((PictureBox)(p.Controls[0])).DoubleClick += origin_e2;
                    ((Label)(p.Controls[1])).DoubleClick += origin_e3;
                    originPicList[i + 1] = originArray[i].path;
                }

                sortedPicList = new string[picNum + 1];
                picturePanel ppp = new picturePanel(0);
                afterSortingPanel.ColumnStyles.Insert(afterSortingPanel.ColumnCount++, new ColumnStyle(SizeType.Absolute, afterSortingPanel.Height));
                afterSortingPanel.Controls.Add(ppp, 0, 0);
                ppp.init(MainInfo.picInfo[_path].image, "参考图像");
                ppp.image_name.Height = 25;
                ppp.image_name.Font = new Font("微软雅黑", 13);
                ppp.DoubleClick += sorted_e1;
                ppp.BackColor = Color.Gray;
                ((PictureBox)(ppp.Controls[0])).DoubleClick += sorted_e2;
                ((Label)(ppp.Controls[1])).DoubleClick += sorted_e3;
                sortedPicList[0] = _path;
                for (int i = 0; i < picNum; i++)
                {
                    picturePanel p = new picturePanel(i + 1);
                    afterSortingPanel.ColumnStyles.Insert(afterSortingPanel.ColumnCount++, new ColumnStyle(SizeType.Absolute, afterSortingPanel.Height));
                    afterSortingPanel.Controls.Add(p, i + 1, 0);
                    p.init(MainInfo.picInfo[sortedArray[i].path].image, sortedArray[i].name);
                    p.image_name.Height = 25;
                    p.image_name.Font = new Font("微软雅黑", 13);
                    p.DoubleClick += sorted_e1;
                    ((PictureBox)(p.Controls[0])).DoubleClick += sorted_e2;
                    ((Label)(p.Controls[1])).DoubleClick += sorted_e3;
                    sortedPicList[i + 1] = sortedArray[i].path;
                }
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
