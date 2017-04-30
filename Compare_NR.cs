using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HVS
{
    public partial class Compare_NR : Form
    {
        private const double image_size_rate = 0.48;
        private int id1;
        private int id2;

        public Compare_NR(int id1, int id2)
        {
            InitializeComponent();
            this.id1 = id1;
            this.id2 = id2;
        }

        private void comfirm_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void CompareForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            compare_image1.Width = compare_image1.Height = (int)(this.Width * image_size_rate);
            compare_image2.Width = compare_image2.Height = (int)(this.Width * image_size_rate);
            compare_image1.Location = new Point((int)(this.Width * 0.015), (int)(this.Height * 0.02));
            compare_image2.Location = new Point((int)(this.Width * 0.515), (int)(this.Height * 0.02));
            confirm.Location = new Point((int)(this.Width * 0.475), (int)(this.Height * 0.86));

            double result1 = NR_algorithm.NR_method(
                        SettingInfo.imageCompare_NRmethod,
                        MainInfo.picInfo[MainInfo.path_name[id1]].rgb,
                        MainInfo.picInfo[MainInfo.path_name[id1]].height,
                        MainInfo.picInfo[MainInfo.path_name[id1]].width);
            double result2 = NR_algorithm.NR_method(
                        SettingInfo.imageCompare_NRmethod,
                        MainInfo.picInfo[MainInfo.path_name[id2]].rgb,
                        MainInfo.picInfo[MainInfo.path_name[id2]].height,
                        MainInfo.picInfo[MainInfo.path_name[id2]].width);
            int score1 = NR_algorithm.NR_grade(SettingInfo.imageCompare_NRmethod, result1);
            int score2 = NR_algorithm.NR_grade(SettingInfo.imageCompare_NRmethod, result2);
            picturePanel p1 = new picturePanel();
            picturePanel p2 = new picturePanel();
            compare_image1.Controls.Add(p1);
            compare_image2.Controls.Add(p2);
            p1.init(MainInfo.picInfo[MainInfo.path_name[id1]].image, "得分：" +　score1.ToString());
            p2.init(MainInfo.picInfo[MainInfo.path_name[id2]].image, "得分："　+　score2.ToString());
 
            p1.image_name.Height = 33;
            p2.image_name.Height = 33;
            p1.image_name.Font = new Font("微软雅黑", 18);
            p2.image_name.Font = new Font("微软雅黑", 18);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            //绘制中线
            float x1 = (float)(this.Width * 0.475 + confirm.Width / 2);
            float y1 = (float)(this.Height * 0.02);
            float x2 = (float)(this.Width * 0.475 + confirm.Width / 2);
            float y2 = (float)(this.Height * 0.74);
            //注意坐标系的定义
            Pen pen = new Pen(Color.Black, 2);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            pen.DashPattern = new float[] { 5, 5 };
            graphics.DrawLine(pen, x1, y1, x2, y2);
            graphics.Dispose();
            base.OnPaint(e);
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
    }
}
