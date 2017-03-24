using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using demo1;

namespace UI
{
    public partial class CompareForm_none : Form
    {
        private const double size_rate = 1;
        private const double image_size_rate = 0.4;
        private int id1;
        private int id2;
        public CompareForm_none(int id1, int id2)
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
            //this.Width = (int)(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width * size_rate);
            //this.Height = (int)(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height * size_rate);
            //this.Location = new Point((System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 3 * 2, (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 3 * 2);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            compare_image1.Width = compare_image1.Height = (int)(this.Width * image_size_rate);
            compare_image2.Width = compare_image2.Height = (int)(this.Width * image_size_rate);
            compare_image1.Location = new Point((int)(this.Width * 0.05), (int)(this.Height * 0.02));
            compare_image2.Location = new Point((int)(this.Width * 0.55), (int)(this.Height * 0.02));
           // hint.Location = new Point((int)(this.Width * 0.46), (int)(this.Height * 0.74));
           // score_text1.Location = new Point((int)(this.Width * 0.38), (int)(this.Height * 0.70));
          //  score_text2.Location = new Point((int)(this.Width * 0.55), (int)(this.Height * 0.70));
          //  op.Location = new Point((int)(this.Width * 0.49), (int)(this.Height * 0.8));
            confirm.Location = new Point((int)(this.Width * 0.475), (int)(this.Height * 0.86));

            int score1 = (int)(new Pic(MainForm.path_name[id1], null)).tenengrad();
            int score2 = (int)(new Pic(MainForm.path_name[id2], null)).tenengrad();
            picturePanel p1 = new picturePanel();
            picturePanel p2 = new picturePanel();
            compare_image1.Controls.Add(p1);
            compare_image2.Controls.Add(p2);
            p1.init(MainForm.picInfo[MainForm.path_name[id1]].image, "得分：" +　score1.ToString());
            p2.init(MainForm.picInfo[MainForm.path_name[id2]].image, "得分："　+　score2.ToString());
           // p1.init(MainForm.picInfo[MainForm.path_name[id1]].image, MainForm.name[id1]);
           // p2.init(MainForm.picInfo[MainForm.path_name[id2]].image, MainForm.name[id2]);
            p1.image_name.Height = 33;
            p2.image_name.Height = 33;
            p1.image_name.Font = new Font("微软雅黑", 18);
            p2.image_name.Font = new Font("微软雅黑", 18);

            Graphics graphics = this.CreateGraphics();
            //绘制中线
            float x1 = (float)(this.Width * 0.475+this.confirm.Width/2);
            float y1 = (float)(this.Height * 0.02);
            float x2 = (float)(this.Width * 0.475 + this.confirm.Width / 2);
            float y2 = (float)(this.Height * 0.74);
            //注意坐标系的定义
            Pen pen = new Pen(Color.Black, 2);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            pen.DashPattern = new float[] { 5, 5 };
            graphics.DrawLine(pen, x1, y1, x2, y2);

//             int score1 = (int)(new Pic(MainForm.path_name[id1], null)).tenengrad();
//             int score2 = (int)(new Pic(MainForm.path_name[id2], null)).tenengrad();
//             score_text1.Text = "得分：" +　score1.ToString();
//             score_text2.Text = "得分："　+　score2.ToString();
//             if (score1 > score2) 
//             {
//                 op.Text = ">";
//             }
//             else if (score1 < score2)
//             {
//                 op.Text = "<";
//             }
//             else
//             {
//                 op.Text = "=";
//             }
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
