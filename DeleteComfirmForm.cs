using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.Threading.Tasks;
using CCWin;
using System.Threading;
using System.IO;
using System.Collections;

namespace HVS
{
    public partial class DeleteComfirmForm : Form
    {
        private int delete_rate;
        private const double size_rate = 0.9;
        private MainForm mf;
        private string imagePath = "";
        private SortObject[] sortedArray;
        private string[] picList;
        EventHandler e1; //双击单元格打开图片查看器
        EventHandler e2; //双击单元格打开图片查看器
        EventHandler e3; //双击单元格打开图片查看器

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

        public DeleteComfirmForm()
        {
            InitializeComponent();
            e1 = new EventHandler(item_double_click);
            e2 = new EventHandler(pictureBox_double_click);
            e3 = new EventHandler(label_double_click);
        }

        public DeleteComfirmForm(int delete_rate, MainForm mf, SortObject[] sortedArray)
        {
            InitializeComponent();
            this.delete_rate = delete_rate;
            this.mf = mf;
            this.sortedArray = sortedArray;
            e1 = new EventHandler(item_double_click);
            e2 = new EventHandler(pictureBox_double_click);
            e3 = new EventHandler(label_double_click);
        }


        private void comfirm_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < picList.Length; i++)
            {
                imagePath = picList[i];
                if (File.Exists(imagePath))
                {
                    MainInfo.picInfo[imagePath].image.Dispose();
                    FileSystem.DeleteFile(imagePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                }
                for (int j = 0; j < MainInfo.tot; j++)
                {
                    if (MainInfo.path_name[j] == imagePath)
                    {
                        MainForm.imageToDelete[j] = true;
                        break;
                    }
                }
            }
            mf.delete();
            Dispose();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void ImageDeleteComfirmForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            result.Width = (int)(this.Width * 0.9);
            result.Height = (int)(result.Width * 0.25);
            result.Location = new Point((int)(this.Width * 0.04), (int)(this.Height * 0.25));
            hint.Location = new Point((int)(result.Location.X + (result.Width - hint.Width) / 2), (int)(this.Height * 0.15));
            confirm.Location = new Point((int)(this.Width * 0.37), (int)(this.Height * 0.82));
            cancel.Location = new Point((int)(this.Width * 0.57), (int)(this.Height * 0.82));


            int n = sortedArray.Length;
            int i = n - (int)((double)n * delete_rate / 100);
            int tot = 0;
            picList = new string[n - i];
            for (; i < n; i++)
            {
                picturePanel p = new picturePanel(MainInfo.tot);
                if (tot % 4 == 0 && tot != 0)
                {
                    result.RowStyles.Insert(result.RowCount++, new RowStyle());
                }
                result.Controls.Add(p, tot % 4, tot / 4);
                p.init(MainInfo.picInfo[sortedArray[i].path].image, "质量分数：" + sortedArray[i].grade.ToString("f2"));
                p.image_name.Height = 28;
                p.image_name.Font = new Font("微软雅黑", 16);
                p.DoubleClick += e1;
                p.id = tot;
                ((PictureBox)(p.Controls[0])).DoubleClick += e2;
                ((Label)(p.Controls[1])).DoubleClick += e3;
                picList[tot++] = sortedArray[i].path;
            }
            TableLayoutRowStyleCollection rowstyles;
            rowstyles = result.RowStyles;
            foreach (RowStyle style in rowstyles)
            {
                style.SizeType = SizeType.Absolute;
                style.Height = result.Height - 4;
            }
            result.Width = result.Height * 4 + MainInfo.tot / 4 * 15;
            if(result.Width + result.Location.X + 20 > this.Width)
            {
                result.Width = this.Width - result.Location.X - 20;
            }
        }

        //双击单元格
        private void item_double_click(object sender, EventArgs e)
        {
            picturePanel p = (picturePanel)sender;
            Form imageshow = new ImageView(picList, p.id);
            imageshow.Size = new Size(1024, 800);//新窗口界面大小和原窗口同样大
            imageshow.Show();
        }

        //双击图片
        private void pictureBox_double_click(object sender, EventArgs e)
        {
            PictureBox curPicture = (PictureBox)(sender);
            picturePanel p = (picturePanel)(curPicture.Parent);
            Form imageshow = new ImageView(picList, p.id);
            imageshow.Size = new Size(1024, 800);//新窗口界面大小和原窗口同样大
            imageshow.Show();
        }

        //双击文字
        private void label_double_click(object sender, EventArgs e)
        {
            picturePanel p = (picturePanel)(((Label)sender).Parent);
            Form imageshow = new ImageView(picList, p.id);
            imageshow.Size = new Size(1024, 800);//新窗口界面大小和原窗口同样大
            imageshow.Show();
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
