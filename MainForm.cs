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
using Microsoft.VisualBasic.FileIO;
using demo1;

namespace UI
{
    public partial class MainForm :CCSkinMain
    {
        public static int tot = 0; //图片数
        public static bool[] selected; //每张图片是否被选中，true表示被选中，false表示没被选中
        public static string[] name; //图片名字
        public static string[] path_name; //图片路径，记录第i张图片的地址
        public static bool[] imageToDelete; //图片状态
        public static int progress; //排序进度
        public static int clear_ratio = 50; //图片清理率，也就是清除图片评分后百分之几的图片
        public static Dictionary<string, Pic> picInfo; //图片信息，键值对<图片路径,Pic对象>，可以根据路径名得到图片信息，包括图片的bitmap类对象(封装在Pic类中)，可用于控件的图像展示
        private const int SIZE = 10000; //初始化常量
        private const double size_rate = 0.85;
        public static string previous_pic = null; //上一次全参考选择的图像
        public static string referenceImage = null; //参考图像
        public static string referenceImage_temp = null;
        public static int panel_temp = -1;
        public static int previous_panel_temp = -1;
        public static int previous_select = -1; //上一次选中的图像序号 

        TreeViewEventArgs ee; //用于右侧目录树缩略图加载函数中获取treeview控件
        string tag = "True"; //Tag标签，用于检测被check的结点（每个被check的结点的tag属性被设置为true）
        TreeNode rootNode; //用于设置目录树根节点（我的电脑）
        bool select_all = false; //是否全选
        public static Color unselected_color = Color.FromArgb(128, 208, 255); //图片未选择时背景颜色
        public static Color selected_color = Color.FromArgb(92, 199, 249); //图片选择时背景颜色
        int sizeF = 5; //缩放等级，缩放等级越小图片越大
        bool control_flag = false; //记录ctrl键是否键下，用于图片缩放
        bool shift_flag = false; //记录shift键是否键下，用于连续选择
        PictureBox referenceMark;

        MouseEventHandler e1; //点击单元格panel改变选择状态的事件
        MouseEventHandler e2; //点击单元格panel改变选择状态的事件
        MouseEventHandler e3; //点击单元格panel改变选择状态的事件
        EventHandler de1; //双击单元格打开图片查看器
        EventHandler de2; //双击单元格打开图片查看器
        EventHandler de3; //双击单元格打开图片查看器

        //主窗口初始化变量
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Control.CheckForIllegalCrossThreadCalls = false;
            selected = new bool[SIZE];
            imageToDelete = new bool[SIZE];
            name = new string[SIZE];
            path_name = new string[SIZE];
            picInfo = new Dictionary<string, Pic>();
            for (int i = 0; i < SIZE; i++)
            {
                selected[i] = false;
                imageToDelete[i] = false;
            }
            e1 = new MouseEventHandler(item_click);
            e2 = new MouseEventHandler(pictureBox_click);
            e3 = new MouseEventHandler(label_click);
            de1 = new EventHandler(item_double_click);
            de2 = new EventHandler(pictureBox_double_click);
            de3 = new EventHandler(label_double_click);
            result_show.Width = splitContainer2.Panel1.Width / sizeF * 5;
            if (sizeF != 5)
            {
                result_show.Width += sizeF * 5;
            }
            result_show.MouseWheel += new System.Windows.Forms.MouseEventHandler(changeSize);
            referenceMark = new PictureBox();
            referenceMark.Width = 25;
            referenceMark.Height = 25;
            referenceMark.Image = Properties.Resources.done;
            referenceMark.SizeMode = PictureBoxSizeMode.StretchImage;
            result_show.HorizontalScroll.Enabled = true;
            result_show.HorizontalScroll.Visible = true;
            this.Width = (int)(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width * size_rate);
            this.Height = (int)(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height * size_rate);
            this.Location = new Point((System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 3 * 2, (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 3 * 2);
          
            this.FormBorderStyle = FormBorderStyle.None;
            result_show.ColumnCount = 1;
        }

        //窗口加载
        private void Form1_Load(object sender, EventArgs e)
        {
            //加载目录树
            directoryTree();
        }
        
        //主界面窗口变化事件，相应的调整控件位置及大小
        private void MainForm_Resize(object sender, EventArgs e) 
        {
           
            result_show.Width = splitContainer2.Panel1.Width / sizeF * 5;
            if(sizeF!=5)
            {
                result_show.Width += sizeF * 5;
            }
            int width;
            int height;
            Point temp;
            //控制左侧图片显示框位置及大小
            {
                temp = this.imageSort.Location;
                width = this.imageSort.Width;
                height = this.imageSort.Height;
                this.imageSortPanel.Location = new Point(temp.X, 0);
                this.imageSortPanel.Width = width;
                this.imageSortPanel.Height = width * 165 / 195;
                temp = this.imageClear.Location;
                width = this.imageClear.Width;
                height = this.imageClear.Height;
                this.imageClearPanel.Location = new Point(temp.X, 0);
                this.imageClearPanel.Width = width;
                this.imageClearPanel.Height = width * 165 / 195;
                this.setting.Height = width * 165 / 195;
                
            }
        }
        
        //生成目录树，根节点是"我的电脑",几个直接子节点是相应盘
        private void directoryTree()
        {
            rootNode = new TreeNode("我的电脑", IconIndexes.MyComputer, IconIndexes.MyComputer);  //载入显示 
            rootNode.Text = "我的电脑";                           //树节点标签内容
            rootNode.Name = "我的电脑";                         //结点name用于记录结点所在路径
            this.treeView1.Nodes.Add(rootNode);               //树中添加根目录

            //为根节点"我的电脑"添加几个子节点--相应盘
            foreach (string drive in Environment.GetLogicalDrives())
            {
                //实例化DriveInfo对象 命名空间System.IO
                var dir = new DriveInfo(drive);
                switch (dir.DriveType)           //判断驱动器类型
                {
                    case DriveType.Fixed:        //仅取固定磁盘盘符 Removable-U盘 
                        {
                            TreeNode tNode = new TreeNode(dir.Name.Split(':')[0]);//Split仅获取盘符字母
                            tNode.Name = dir.Name;
                            tNode.ImageIndex = IconIndexes.FixedDrive;         //获取结点显示图片
                            tNode.SelectedImageIndex = IconIndexes.FixedDrive; //选择显示图片
                            rootNode.Nodes.Add(tNode);                    //加载驱动节点
                            tNode.Nodes.Add("");                //给该盘结点添加一个空结点以便显示一个+号表示可以展开盘
                        }
                        break;
                }
            }
            rootNode.Expand();                  //展开我的电脑
        }

        //图片排序面板
        private void imageSort_Click(object sender, EventArgs e)
        {
            imageSortPanel.Visible = !imageSortPanel.Visible;
            imageClearPanel.Visible = false;
        }

        //图片压缩面板
        private void imageCompress_Click(object sender, EventArgs e)
        {
            imageClearPanel.Visible = false;
            imageSortPanel.Visible = false;
            int cnt = 0;
            string _path = null;
            string _name = null;
            for (int i = 0; i < tot; i++)
            {
                if (selected[i])
                {
                    cnt++;
                    _path = path_name[i];
                    _name = name[i];
                }
            }
            if (cnt == 0)
            {
                MessageBox.Show("请选一张需要进行压缩的图片");
                return;
            }
            else if (cnt > 1)
            {
                MessageBox.Show("压缩图片只能为一张");
                return;
            }
            CompressForm_none cn = new CompressForm_none(_path, _name);
            cn.Show();
        }

        //图片清理面板
        private void imageClear_Click(object sender, EventArgs e)
        {
            imageClearPanel.Visible = !imageClearPanel.Visible;
            imageSortPanel.Visible = false;
        }

        //图片比较面板
        private void imageCompare_Click(object sender, EventArgs e)
        {
            imageClearPanel.Visible = false;
            imageSortPanel.Visible = false;
            int cnt = 0;
            int id1 = -1;
            int id2 = -1;
            for (int i = 0; i < tot; i++)
            {
                if (selected[i])
                {
                    cnt++;
                    if(id1 == -1)
                    {
                        id1 = i;
                    }
                    else
                    {
                        id2 = i;
                    }
                }
            }
            if (cnt != 2)
            {
                MessageBox.Show("请选择两张图片!");
                return;
            }
            CompareForm_none compareForm_none = new CompareForm_none(id1, id2);
            compareForm_none.Show();
        }

        //用户设置面板
        private void aboutUs_Click(object sender, EventArgs e)
        {
            imageSortPanel.Visible = false;
            imageClearPanel.Visible = false;
            groupStatement gs = new groupStatement();
            gs.Show();
        } 

        //点击图片改变选择状态
        private void item_click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Panel p = (Panel)sender;
                int id = int.Parse(p.Name);
                selected[id] = !selected[id];
                if (p.BackColor == unselected_color)
                {
                    if(previous_panel_temp == id)
                    {
                        selected[id] = false;
                        return;
                    }
                    p.BackColor = selected_color;
                    selected[id] = true;
                    if (previous_select == -1)
                    {
                        previous_select = id;
                    }
                    else
                    {
                       if (shift_flag)
                       {
                           int start, end;
                           if (previous_select < id)
                           {
                               start = previous_select;
                               end = id;
                           }
                           else
                           {
                               start = id;
                               end = previous_select;
                           }
                           for (int i = start; i <= end; i++)
                           {
                               if (i == previous_panel_temp)
                               {
                                   continue;
                               }
                               selected[i] = true;
                               ((Panel)result_show.Controls[i]).BackColor = selected_color;
                           }
                       }
                       else
                       {
                           previous_select = id;
                       }
                    }
                }
                else
                {
                    p.BackColor = unselected_color;
                    selected[id] = false;
                    previous_select = -1;
                }
            }
            else if(e.Clicks == 1)
            {
                selectionMenu.Show(Cursor.Position);
                Panel p = (Panel)sender;
                int id = int.Parse(p.Name);
                referenceImage_temp = path_name[id];
                panel_temp = id;
                if(selected[id])
                {
                    selectionMenu.Items[0].Enabled = false;
                    selectionMenu.Items[1].Enabled = false;
                }
                else if(referenceImage == referenceImage_temp)
                {
                    selectionMenu.Items[0].Enabled = false;
                    selectionMenu.Items[1].Enabled = true;
                }
                else 
                {
                    selectionMenu.Items[0].Enabled = true;
                    selectionMenu.Items[1].Enabled = false;
                }
            }
        }

        //双击单元格
        private void item_double_click(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            PictureBox curPicture = (PictureBox)(p.Controls[0]);
            int position = int.Parse(curPicture.Name);
            string[] picList = new string[tot];
            for (int i = 0; i < tot; i++)
            {
                picList[i] = path_name[i];
            }
            Form imageshow = new ImageView(picList, position);
            imageshow.Size = new Size(1024, 800);
            imageshow.Show();
        }

        //点击图片改变选择状态
        private void pictureBox_click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Panel p = (Panel)(((PictureBox)sender).Parent);
                int id = int.Parse(p.Name);
                selected[id] = !selected[id];
                if (p.BackColor == unselected_color)
                {
                    if (previous_panel_temp == id)
                    {
                        selected[id] = false;
                        return;
                    }
                    p.BackColor = selected_color;
                    selected[id] = true;
                    if (previous_select == -1)
                    {
                        previous_select = id;
                    }
                    else
                    {
                        if (shift_flag)
                        {
                            int start, end;
                            if (previous_select < id)
                            {
                                start = previous_select;
                                end = id;
                            }
                            else
                            {
                                start = id;
                                end = previous_select;
                            }
                            for (int i = start; i <= end; i++)
                            {
                                if (i == previous_panel_temp)
                                {
                                    continue;
                                }
                                selected[i] = true;
                                ((Panel)result_show.Controls[i]).BackColor = selected_color;
                            }
                        }
                        else
                        {
                            previous_select = id;
                        }
                    }
                }
                else
                {
                    p.BackColor = unselected_color;
                    selected[id] = false;
                    previous_select = -1;
                }
            }
            else if (e.Clicks == 1)
            {
                selectionMenu.Show(Cursor.Position);
                Panel p = (Panel)(((PictureBox)sender).Parent);
                int id = int.Parse(p.Name);
                referenceImage_temp = path_name[id];
                panel_temp = id;
                if (selected[id])
                {
                    selectionMenu.Items[0].Enabled = false;
                    selectionMenu.Items[1].Enabled = false;
                }
                else if (referenceImage == referenceImage_temp)
                {
                    selectionMenu.Items[0].Enabled = false;
                    selectionMenu.Items[1].Enabled = true;
                }
                else
                {
                    selectionMenu.Items[0].Enabled = true;
                    selectionMenu.Items[1].Enabled = false;
                }
            }
        }

        //双击图片
        private void pictureBox_double_click(object sender, EventArgs e)
        {
            PictureBox curPicture = (PictureBox)(sender);
            int position = int.Parse(curPicture.Name);
            string[] picList = new string[tot];
            for (int i = 0; i < tot; i++)
            {
                picList[i] = path_name[i];
            }
            Form imageshow = new ImageView(picList, position);
            imageshow.Size = new Size(1024, 800);
            imageshow.Show();
        }

        //点击图片改变选择状态
        private void label_click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Panel p = (Panel)(((Label)sender).Parent);
                int id = int.Parse(p.Name);
                selected[id] = !selected[id];
                if (p.BackColor == unselected_color)
                {
                    if (previous_panel_temp == id)
                    {
                        selected[id] = false;
                        return;
                    }
                    p.BackColor = selected_color;
                    selected[id] = true;
                    if (previous_select == -1)
                    {
                        previous_select = id;
                    }
                    else
                    {
                        if (shift_flag)
                        {
                            int start, end;
                            if (previous_select < id)
                            {
                                start = previous_select;
                                end = id;
                            }
                            else
                            {
                                start = id;
                                end = previous_select;
                            }
                            for (int i = start; i <= end; i++)
                            {
                                if (i == previous_panel_temp)
                                {
                                    continue;
                                }
                                selected[i] = true;
                                ((Panel)result_show.Controls[i]).BackColor = selected_color;
                            }
                        }
                        else
                        {
                            previous_select = id;
                        }
                    }
                }
                else
                {
                    p.BackColor = unselected_color;
                    selected[id] = false;
                    previous_select = -1;
                }
            }
            else if (e.Clicks == 1)
            {
                selectionMenu.Show(Cursor.Position);
                Panel p = (Panel)(((Label)sender).Parent);
                int id = int.Parse(p.Name);
                referenceImage_temp = path_name[id];
                panel_temp = id;
                if (selected[id])
                {
                    selectionMenu.Items[0].Enabled = false;
                    selectionMenu.Items[1].Enabled = false;
                }
                else if (referenceImage == referenceImage_temp)
                {
                    selectionMenu.Items[0].Enabled = false;
                    selectionMenu.Items[1].Enabled = true;
                }
                else
                {
                    selectionMenu.Items[0].Enabled = true;
                    selectionMenu.Items[1].Enabled = false;
                }
            }
        }

        //双击文字
        private void label_double_click(object sender, EventArgs e)
        {
            Panel p = (Panel)(((Label)sender).Parent);
            PictureBox curPicture = (PictureBox)(p.Controls[0]);
            int position = int.Parse(curPicture.Name);
            string[] picList = new string[tot];
            for(int i = 0 ; i < tot; i++)
            {
                picList[i] = path_name[i];
            }
            Form imageshow = new ImageView(picList, position);
            imageshow.Size = new Size(1024, 800);
            imageshow.Show();
        }

        //添加图片到左边工作区
        bool add_image(string path, string _name)
        {
            if (picInfo.ContainsKey(path))
            {
                return false; //图片已经存在，添加失败
            }
            Pic pic = new Pic(path, _name);
            picInfo.Add(path, pic);
            if(tot == 0)
            {
                result_show.ColumnCount = 5;
            }
            //添加新的图片单元格
            if (tot % 5 == 0)
            {
                result_show.RowStyles.Insert(result_show.RowCount++, new RowStyle());
                TableLayoutRowStyleCollection rowstyles;
                rowstyles = result_show.RowStyles;
                foreach (RowStyle style in rowstyles)
                {
                    style.SizeType = SizeType.Absolute;
                    style.Height = result_show.Width / 5;
                }
            }
            name[tot] = _name;

            picturePanel p = new picturePanel();
            p.Name = tot.ToString();
            p.BackColor = unselected_color;
            p.image_name.Height = 25;
            p.image_name.Font = new Font("微软雅黑", 12);
            //p.image.MouseDoubleClick += new MouseEventHandler(image_MouseDoubleClick);
            p.image.Name = tot.ToString();
            result_show.Controls.Add(p, tot % 5, tot / 5);
            p.init(MainForm.picInfo[path].image, _name);
            path_name[tot] = path;
            result_show.Refresh();
            tot++;
            return true; //成功添加图片
        }

        #region //线程，用于加快左侧目录树缩略图的显示,当展开事件发生时被激活
        public delegate void MyInvoke();

        public void loadthread() 
        {
            MyInvoke mi = new MyInvoke(loadjiedian);
            BeginInvoke(mi);
        }

        public void loadjiedian()
        {
            TreeViewItems.Add(ee.Node, this.treeView1);
        }
        #endregion

        //目录树结点展开事件：显示相应文件夹子文件夹以及图片和缩略图
        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
           
            //开启线程加载待展开结点
            ee = e;
            Thread t = new Thread(new ThreadStart(loadthread));
            t.IsBackground = true;
            t.Start();
        }

        //目录树子节点被双击事件，将被点击的图片添加到右侧result_show
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            string path = e.Node.Name;
            if (path.IndexOf(".") != -1)
            {
                string name= "";
                name = path;
                string[] sArray =path.Split(new char[2] { '\\', '.' });
                if(sArray.Length < 2)
                {
                    return;
                }
                name = sArray[sArray.Length - 2];
                if (add_image(path, name))
                {
                    Panel pa = (Panel)result_show.GetControlFromPosition((tot - 1) % 5, (tot - 1) / 5);
                    PictureBox pb = (PictureBox)pa.Controls[0];
                    Label l = (Label)pa.Controls[1];
                    pa.MouseClick += e1;
                    pb.MouseClick += e2;
                    l.MouseClick += e3;
                    pa.DoubleClick += de1;
                    pb.DoubleClick += de2;
                    l.DoubleClick += de3;
                    e.Node.Tag = null;
                    e.Node.Checked = false;
                }
            }
        }

        //目录树结点拖拽事件
        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //将被拖拽结点的check设置为true并设置tag为true以便将其加入到result_show
            TreeNode hi = (TreeNode)e.Item;
            hi.Checked = true;
            hi.Tag = tag;
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        //result_show控件拖入事件
        private void result_show_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        //result_show控件转入释放事件：遍历目录树所有结点，将其中被check的图片添加到result_show中
        private void result_show_DragDrop(object sender, DragEventArgs e)
        {
            int i = tot;
            TreeNode topnode = rootNode;//得到TreeView的根结点，注意根结点只有一个
            TraversNodes(topnode);//遍历根结点
            picturePanel pa;
            PictureBox pb;
            Label l;
            for (; i < tot; i++)
            {
                pa = (picturePanel)result_show.GetControlFromPosition(i % 5, i / 5);
                pb = (PictureBox)pa.Controls[0];
                l = (Label)pa.Controls[1];
                pa.MouseClick += e1;
                pb.MouseClick += e2;
                l.MouseClick += e3;
                pa.DoubleClick += de1;
                pb.DoubleClick += de2;
                l.DoubleClick += de3;
            }
        }

        //目录树结点被check事件：检查当前被check结点是否有子结点，若有将所有子节点设置为checked；检查是否有父节点，若有，判断该父节点所有子节点是否都被checked，若是，将父节点设置为checked
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                TreeNode node = e.Node;
                //对结点check状态反转
                if (node.Tag == null)
                {
                    node.Tag = tag;//附加结点信息
                }
                else
                {
                    node.Tag = null;
                }

                //将所有子节点check状态反转
                CheckAllChildNodes(e.Node, e.Node.Checked);

                //选中父节点 
                bool bol = true;
                if (e.Node.Parent != null)
                {
                    for (int i = 0; i < e.Node.Parent.Nodes.Count; i++)
                    {
                        if (!e.Node.Parent.Nodes[i].Checked)
                        {
                            bol = false;
                        }
                    }
                    e.Node.Parent.Checked = bol;
                    ////记得如果父节点被选中或取消，记得设置它的tag哦
                    if (bol)
                    {
                        e.Node.Parent.Tag = tag;
                    }
                    else
                    {
                        e.Node.Parent.Tag = null;
                    }
                }
            }
        }

        //将所有子节点check状态设置为父节点check状态
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                if (node.Tag == null)
                {
                    node.Tag = tag;//附加结点信息
                }
                else
                {
                    node.Tag = null;
                }
                node.Checked = nodeChecked;
              
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        //遍历所有结点，将被check的结点添加到result_show
        private void TraversNodes(TreeNode parent)
        {
            TreeNode node = parent;
            if (node != null)
            {
                if (node.Tag != null && node.Tag.ToString() == tag&&node.Nodes.Count==0)
                {
                    string path = node.Name;
                    string name = path;
                    string[] sArray = path.Split(new char[2] { '\\', '.' });
                    
                    if(sArray.Length < 2)
                    {
                        return;
                    }
                    name = sArray[sArray.Length - 2];
                    if(!add_image(path, name))
                    {
                        return;
                    }
                    node.Tag = null;
                    node.Checked = false;
                }
                //    nodesTag.AppendFormat("node:{0} has checked\n", node.Text);

                if (node.FirstNode != null)////如果node节点还有子节点则进入遍历
                {
                    TraversNodes(node.FirstNode);
                }
                if (node.NextNode != null)////如果node节点后面有同级节点则进入遍历
                {
                    TraversNodes(node.NextNode);
                }
            }
        }

        private void addImageSet_Click(object sender, EventArgs e)
        {
            int i = tot;
            TreeNode topNode = rootNode;
            TraversNodes(topNode);
            picturePanel pa;
            PictureBox pb;
            Label l;
            for (; i < tot; i++)
            {
                pa = (picturePanel)result_show.GetControlFromPosition(i % 5, i / 5);
                pb = (PictureBox)pa.Controls[0];
                l = (Label)pa.Controls[1];
                pa.MouseClick += e1;
                pb.MouseClick += e2;
                l.MouseClick += e3;
                pa.DoubleClick += de1;
                pb.DoubleClick += de2;
                l.DoubleClick += de3;
            }
        }

        //排序进度条更新线程
        public void progress_thread()
        {
            SortingProgress sp = new SortingProgress();
            sp.Show();
            sp.Refresh();
            while(true)
            {
                if(progress<1000)
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

        //点击工作区隐藏图片清理、图片压缩、图片排序的面板
        private void result_show_Click(object sender, EventArgs e)
        {
            imageClearPanel.Visible = false;
            imageSortPanel.Visible = false;
        }

        //图片无参考排序
        private void imageSort_none_Click(object sender, EventArgs e)
        {
            resetSortPanel();
            this.Refresh();
            int picNum = 0;
            for (int i = 0; i<tot;i++ )
            {
                if(selected[i])
                {
                    picNum++;
                }
            }
            if (picNum == 0)
            {
                MessageBox.Show("请选择至少一张图片");
                return;
            }

            progress = 0;
            int id = 0;
            Thread progressThread = new Thread(progress_thread);
            progressThread.IsBackground = true;
            progressThread.Start();
            sortObject[] originArray = new sortObject[picNum];
            sortObject[] sortedArray = new sortObject[picNum];
            for (int i = 0; i < tot; i++)
            {
                if (selected[i])
                {
                    if (!picInfo[path_name[i]].state_none)
                    {
                        picInfo[path_name[i]].grade_none = picInfo[path_name[i]].tenengrad();
                        picInfo[path_name[i]].state_none = true;
                    }
                    originArray[id] = new sortObject(picInfo[path_name[i]].grade_none, path_name[i], name[i]);
                    sortedArray[id++] = new sortObject(picInfo[path_name[i]].grade_none, path_name[i], name[i]);
                }
                progress = 1000 * id / picNum;
            }
            Array.Sort(sortedArray, new sortObjectComparer()); //图片排序调用

            SortingResult sr = new SortingResult(picNum, originArray, sortedArray);
            sr.Show();
        }

        //图片全参考排序
        private void imageSort_full_Click(object sender, EventArgs e)
        {
            resetSortPanel();
            this.Refresh();
            int picNum = 0;
            for (int i = 0; i < tot; i++)
            {
                if (selected[i])
                {
                    picNum++;
                }
            }
            if (picNum == 0)
            {
                MessageBox.Show("请选择至少一张图片");
                return;
            }
            if(referenceImage==null)
            {
                MessageBox.Show("请至少选择一张图片作为参考图像");
                return;
            }
            int standard_width = picInfo[referenceImage].width;
            int standard_height = picInfo[referenceImage].height;
            for (int i = 0; i < tot; i++)
            {
                if (selected[i])
                {
                    if(picInfo[path_name[i]].width!=standard_width||picInfo[path_name[i]].height!=standard_height)
                    {
                        MessageBox.Show("所选图像与参考图像尺寸不一致，无法进行全参考排序");
                        return;
                    }
                }
            }

            progress = 0;
            int id = 0;
            Thread progressThread = new Thread(progress_thread);
            progressThread.IsBackground = true;
            progressThread.Start();
            sortObject[] originArray = new sortObject[picNum];
            sortObject[] sortedArray = new sortObject[picNum];
            for (int i = 0; i < tot; i++)
            {
                if (selected[i])
                {
                    //图像全参考评分
                    if (!picInfo[path_name[i]].state_full || previous_pic != referenceImage)
                    {
                        if (SettingInfo.image_sort_full == "PSNR")
                        {
                            picInfo[path_name[i]].grade_full = picInfo[path_name[i]].psnr(picInfo[referenceImage]);
                        }
                        else
                        {
                            picInfo[path_name[i]].grade_full = picInfo[path_name[i]].LBPdiffer(picInfo[referenceImage]);
                        }
                        picInfo[path_name[i]].state_full = true;
                    }
                    originArray[id] = new sortObject(picInfo[path_name[i]].grade_full, path_name[i], name[i]);
                    sortedArray[id++] = new sortObject(picInfo[path_name[i]].grade_full, path_name[i], name[i]);
                    progress = 1000 * id / picNum;
                }
            }
            previous_pic = referenceImage;
            Array.Sort(sortedArray, new sortObjectComparer()); //图片排序调用

            SortingResult sr = new SortingResult(referenceImage, picNum, originArray, sortedArray);
            sr.Show();
        }

        //图片无参考清理
        private void imageClear_none_Click(object sender, EventArgs e)
        {
            imageClearPanel.Visible = false;
            if (tot == 0)
            {
                MessageBox.Show("请添加至少一张图片");
                return;
            }
            ClearSetting cs = new ClearSetting(this);
            cs.Show();
        }

        //图片全参考清理
        private void imageClear_full_Click(object sender, EventArgs e) 
        {
            imageClearPanel.Visible = false;
            int picNum = 0;
            for (int i = 0; i < tot; i++)
            {
                if (selected[i])
                {
                    picNum++;
                }
            }
            if (picNum == 0)
            {
                MessageBox.Show("请选择至少一张图片");
                return;
            }
            if (referenceImage == null)
            {
                MessageBox.Show("请至少选择一张图片作为参考图像");
                return;
            }
            int standard_width = picInfo[referenceImage].width;
            int standard_height = picInfo[referenceImage].height;
            for (int i = 0; i < tot; i++)
            {
                if (selected[i])
                {
                    if (picInfo[path_name[i]].width != standard_width || picInfo[path_name[i]].height != standard_height)
                    {
                        MessageBox.Show("所选图像与参考图像尺寸不一致，无法进行全参考排序");
                        return;
                    }
                }
            }
            ClearSetting cs = new ClearSetting(this, referenceImage);
            cs.Show();
        }

        //删除工作区中的图片
        public void delete()
        {
            picturePanel p;
            int i = 0, k = tot - 1;
            for (; i <= k; i++)
            {
                if (imageToDelete[i])
                {
                    picInfo.Remove(path_name[i]);
                    if (previous_panel_temp == i)
                    {
                        previous_panel_temp = -1;
                        referenceImage = null;
                        delete_mark(i);
                    }
                    for (; k > i; k--)
                    {
                        if (!imageToDelete[k])
                        {
                            break;
                        }
                        else
                        {
                            picInfo.Remove(path_name[k]);
                            if(previous_panel_temp == k)
                            {
                                previous_panel_temp = -1;
                                referenceImage = null;
                                delete_mark(k);
                            }
                        }
                    }
                    if (k == i)
                    {
                        break;
                    }
                    else
                    {
                        imageToDelete[i] = false;
                        imageToDelete[k] = true;
                        path_name[i] = path_name[k];
                        selected[i] = selected[k];
                        if(selected[i])
                        {
                            ((Panel)result_show.GetControlFromPosition(i % 5, i / 5)).BackColor = selected_color;
                        }
                        else
                        {
                            ((Panel)result_show.GetControlFromPosition(i % 5, i / 5)).BackColor = unselected_color;
                        }
                        if (previous_panel_temp == k)
                        {
                            delete_mark(k);
                            previous_panel_temp = i;
                            add_mark(i);
                        }
                        path_name[k--] = null;

                        p = (picturePanel)result_show.GetControlFromPosition(i % 5, i / 5);
                        p.init(picInfo[path_name[i]].image, picInfo[path_name[i]].name);
                    }
                }
            }
            while (tot > 0 && imageToDelete[tot - 1])
            {
                result_show.Controls[tot - 1].Dispose();
                tot--;
            }
            while (result_show.RowCount > 1 && (result_show.RowCount - 2) * 5 >= tot)
            {
                result_show.RowStyles.RemoveAt(result_show.RowCount - 1);
                result_show.RowCount--;
            }
            if(tot == 0)
            {
                result_show.ColumnCount = 1;
            }
        }

        //删除图片按钮点击事件
        private void deleteImage_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tot; i++)
            {
                imageToDelete[i] = selected[i];
                if (selected[i])
                {
                    selected[i] = false;
                    ((Panel)result_show.GetControlFromPosition(i % 5, i / 5)).BackColor = unselected_color;
                }
            }
            delete();
        }

        //添加图片按钮点击事件
        private void selectAll_Click(object sender, EventArgs e)
        {
            if (!select_all)
            {
                select_all = true;
                for (int i = 0; i < tot; i++)
                {
                    if(i == previous_panel_temp)
                    {
                        continue;
                    }
                    selected[i] = true;
                    ((Panel)result_show.GetControlFromPosition(i % 5, i / 5)).BackColor = selected_color;
                }
            }
            else
            {
                select_all = false;
                for (int i = 0; i < tot; i++)
                {
                    selected[i] = false;
                    ((Panel)result_show.GetControlFromPosition(i % 5, i / 5)).BackColor = unselected_color;
                }
            }
        }

        //设置按钮点击事件
        private void settingButton_Click(object sender, EventArgs e)
        {
            if (SettingForm.flag)
            {
                return;
            }
            SettingForm settingForm = new SettingForm();
            settingForm.Show();
        }

        private void resetClearPanel()
        {
            imageSortPanel.Visible = !imageSortPanel.Visible;
            imageClearPanel.Visible = false;
        }

        private void resetComparePanel()
        {
            imageClearPanel.Visible = false;
            imageSortPanel.Visible = false;
        }

        private void resetCompressPanel()
        {
            imageClearPanel.Visible = !imageClearPanel.Visible;
            imageSortPanel.Visible = false;
        }

        private void resetSortPanel()
        {
            imageClearPanel.Visible = false;
            imageSortPanel.Visible = false;
        }

        private void result_show_Resize(object sender, EventArgs e)
        {
            TableLayoutRowStyleCollection rowstyles;
            rowstyles = result_show.RowStyles;
            foreach (RowStyle style in rowstyles)
            {
                style.SizeType = SizeType.Absolute;
                style.Height = result_show.Width / 5;
            }
            if (previous_panel_temp != -1)
            {
                int x = result_show.Controls[previous_panel_temp].Size.Width;
                int y = result_show.Controls[previous_panel_temp].Size.Height;
                referenceMark.Location = new Point(x - 25, y - 25);
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers.CompareTo(Keys.Control) == 0)
            {
                control_flag = true;
            }
            if (e.Modifiers.CompareTo(Keys.Shift) == 0)
            {
                shift_flag = true;
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.ControlKey)
            {
                control_flag = false;
            }
            if (e.KeyData == Keys.ShiftKey)
            {
                shift_flag = false;
                previous_select = -1;
            }
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (tot > 0)
                {
                    select_all = true;
                }
                for (int i = 0; i < tot; i++)
                {
                    if(i == previous_panel_temp)
                    {
                        continue;
                    }
                    selected[i] = true;
                    ((Panel)result_show.GetControlFromPosition(i % 5, i / 5)).BackColor = selected_color;
                }
            }
        }

        private void changeSize(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (control_flag && result_show.Bounds.Contains(e.X,e.Y))
            {
                if(e.Delta<0)
                {
                    if(sizeF==5)
                    {
                        return;
                    }
                    sizeF++;
                }
                else
                {
                    if(sizeF==3)
                    {
                        return;
                    }
                    sizeF--;
                }
                result_show.Width = splitContainer2.Panel1.Width / sizeF * 5;
                if (sizeF != 5)
                {
                    result_show.Width += sizeF * 5;
                }
                TableLayoutRowStyleCollection rowstyles;
                rowstyles = result_show.RowStyles;
                foreach (RowStyle style in rowstyles)
                {
                    style.SizeType = SizeType.Absolute;
                    style.Height = result_show.Width / 5;
                }
                if (previous_panel_temp != -1)
                {
                    int x = result_show.Controls[previous_panel_temp].Size.Width;
                    int y = result_show.Controls[previous_panel_temp].Size.Height;
                    referenceMark.Location = new Point(x - 25, y - 25);
                }
            }
        }

        private void selectionMenu_Opening(object sender, CancelEventArgs e)
        {
            this.item1.MouseDown += item1_Click;
            this.item2.MouseDown += item2_Click;
        }

        private void item1_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                referenceImage = referenceImage_temp;
                previous_panel_temp = panel_temp;
                add_mark(panel_temp);
            }
        }

        private void item2_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                referenceImage = null;
                delete_mark(panel_temp);
                previous_panel_temp = -1;
            }
        }

        private void add_mark(int i)
        {
            result_show.Controls[i].Controls.Add(referenceMark);
            result_show.Controls[i].Controls[2].BringToFront();
            int x = result_show.Controls[i].Size.Width;
            int y = result_show.Controls[i].Size.Height;
            referenceMark.Location = new Point(x - 25, y - 25);
        }

        private void delete_mark(int i)
        {
            result_show.Controls[i].Controls.Remove(referenceMark);
        }
    }
}