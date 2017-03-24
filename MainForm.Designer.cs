
//主窗口，其他窗口还没写
namespace UI
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.skinToolTip1 = new CCWin.SkinToolTip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.setting = new LT.WinForm.ImageButton.ImageButton();
            this.aboutUs = new LT.WinForm.ImageButton.ImageButton();
            this.imageCompress = new LT.WinForm.ImageButton.ImageButton();
            this.imageSort = new LT.WinForm.ImageButton.ImageButton();
            this.imageClear = new LT.WinForm.ImageButton.ImageButton();
            this.imageCompare = new LT.WinForm.ImageButton.ImageButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.imageSortPanel = new System.Windows.Forms.TableLayoutPanel();
            this.imageSort_full = new LT.WinForm.ImageButton.ImageButton();
            this.imageSort_none = new LT.WinForm.ImageButton.ImageButton();
            this.imageClearPanel = new System.Windows.Forms.TableLayoutPanel();
            this.imageCompress_full = new LT.WinForm.ImageButton.ImageButton();
            this.imageCompress_none = new LT.WinForm.ImageButton.ImageButton();
            this.result_show = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.deleteImage = new LT.WinForm.ImageButton.ImageButton();
            this.addImageSet = new LT.WinForm.ImageButton.ImageButton();
            this.selectALL = new LT.WinForm.ImageButton.ImageButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.selectionMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.item1 = new System.Windows.Forms.ToolStripMenuItem();
            this.item2 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.imageSortPanel.SuspendLayout();
            this.imageClearPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.selectionMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinToolTip1
            // 
            this.skinToolTip1.AutoPopDelay = 5000;
            this.skinToolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(200)))), ((int)(((byte)(249)))));
            this.skinToolTip1.InitialDelay = 500;
            this.skinToolTip1.OwnerDraw = true;
            this.skinToolTip1.ReshowDelay = 800;
            // 
            // splitContainer1
            // 
            this.splitContainer1.AllowDrop = true;
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(200)))), ((int)(((byte)(249)))));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(4, 31);
            this.splitContainer1.MinimumSize = new System.Drawing.Size(1100, 600);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AllowDrop = true;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1189, 700);
            this.splitContainer1.SplitterDistance = 95;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(200)))), ((int)(((byte)(249)))));
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.setting, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.aboutUs, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.imageCompress, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.imageSort, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.imageClear, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.imageCompare, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1189, 95);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // setting
            // 
            this.setting.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.setting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.setting.ButtonImage = global::UI.Properties.Resources.settings;
            this.setting.ButtonText = "";
            this.setting.Location = new System.Drawing.Point(954, 10);
            this.setting.Margin = new System.Windows.Forms.Padding(4);
            this.setting.MouseClickImage = global::UI.Properties.Resources.settings;
            this.setting.MouseOverImage = global::UI.Properties.Resources.settings;
            this.setting.Name = "setting";
            this.setting.Size = new System.Drawing.Size(110, 75);
            this.setting.TabIndex = 6;
            this.setting.Click += new LT.WinForm.ImageButton.ImageButton.ClickEventHandler(this.settingButton_Click);
            // 
            // aboutUs
            // 
            this.aboutUs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.aboutUs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.aboutUs.ButtonImage = global::UI.Properties.Resources.person;
            this.aboutUs.ButtonText = "";
            this.aboutUs.Location = new System.Drawing.Point(1072, 5);
            this.aboutUs.Margin = new System.Windows.Forms.Padding(4);
            this.aboutUs.MouseClickImage = global::UI.Properties.Resources.person;
            this.aboutUs.MouseOverImage = global::UI.Properties.Resources.person;
            this.aboutUs.Name = "aboutUs";
            this.aboutUs.Size = new System.Drawing.Size(85, 85);
            this.aboutUs.TabIndex = 5;
            this.aboutUs.Click += new LT.WinForm.ImageButton.ImageButton.ClickEventHandler(this.aboutUs_Click);
            // 
            // imageCompress
            // 
            this.imageCompress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageCompress.ButtonImage = global::UI.Properties.Resources.compress_normal;
            this.imageCompress.ButtonText = "";
            this.imageCompress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageCompress.Location = new System.Drawing.Point(200, 4);
            this.imageCompress.Margin = new System.Windows.Forms.Padding(4);
            this.imageCompress.MouseClickImage = global::UI.Properties.Resources.compress_selected;
            this.imageCompress.MouseOverImage = global::UI.Properties.Resources.compress_selected;
            this.imageCompress.Name = "imageCompress";
            this.imageCompress.Size = new System.Drawing.Size(188, 87);
            this.imageCompress.TabIndex = 4;
            this.imageCompress.Click += new LT.WinForm.ImageButton.ImageButton.ClickEventHandler(this.imageCompress_Click);
            // 
            // imageSort
            // 
            this.imageSort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageSort.ButtonImage = global::UI.Properties.Resources.sort_normal2;
            this.imageSort.ButtonText = "";
            this.imageSort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageSort.Location = new System.Drawing.Point(4, 4);
            this.imageSort.Margin = new System.Windows.Forms.Padding(4);
            this.imageSort.MouseClickImage = global::UI.Properties.Resources.sort_selected;
            this.imageSort.MouseOverImage = global::UI.Properties.Resources.sort_selected;
            this.imageSort.Name = "imageSort";
            this.imageSort.Size = new System.Drawing.Size(188, 87);
            this.imageSort.TabIndex = 0;
            this.imageSort.Click += new LT.WinForm.ImageButton.ImageButton.ClickEventHandler(this.imageSort_Click);
            // 
            // imageClear
            // 
            this.imageClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageClear.ButtonImage = global::UI.Properties.Resources.clean_normal;
            this.imageClear.ButtonText = "";
            this.imageClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageClear.Location = new System.Drawing.Point(396, 4);
            this.imageClear.Margin = new System.Windows.Forms.Padding(4);
            this.imageClear.MouseClickImage = global::UI.Properties.Resources.clean_selected;
            this.imageClear.MouseOverImage = global::UI.Properties.Resources.clean_selected;
            this.imageClear.Name = "imageClear";
            this.imageClear.Size = new System.Drawing.Size(188, 87);
            this.imageClear.TabIndex = 1;
            this.imageClear.Click += new LT.WinForm.ImageButton.ImageButton.ClickEventHandler(this.imageClear_Click);
            // 
            // imageCompare
            // 
            this.imageCompare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageCompare.ButtonImage = global::UI.Properties.Resources.compare_normal;
            this.imageCompare.ButtonText = "";
            this.imageCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageCompare.Location = new System.Drawing.Point(592, 4);
            this.imageCompare.Margin = new System.Windows.Forms.Padding(4);
            this.imageCompare.MouseClickImage = global::UI.Properties.Resources.compare_selected;
            this.imageCompare.MouseOverImage = global::UI.Properties.Resources.compare_selected;
            this.imageCompare.Name = "imageCompare";
            this.imageCompare.Size = new System.Drawing.Size(188, 87);
            this.imageCompare.TabIndex = 2;
            this.imageCompare.Click += new LT.WinForm.ImageButton.ImageButton.ClickEventHandler(this.imageCompare_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.AllowDrop = true;
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(191)))), ((int)(((byte)(237)))));
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.splitContainer2.Panel1.AllowDrop = true;
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(200)))), ((int)(((byte)(249)))));
            this.splitContainer2.Panel1.Controls.Add(this.imageSortPanel);
            this.splitContainer2.Panel1.Controls.Add(this.imageClearPanel);
            this.splitContainer2.Panel1.Controls.Add(this.result_show);
            this.splitContainer2.Panel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AllowDrop = true;
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(211)))), ((int)(((byte)(255)))));
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer2.Size = new System.Drawing.Size(1189, 494);
            this.splitContainer2.SplitterDistance = 902;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // imageSortPanel
            // 
            this.imageSortPanel.ColumnCount = 1;
            this.imageSortPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.imageSortPanel.Controls.Add(this.imageSort_full, 0, 0);
            this.imageSortPanel.Controls.Add(this.imageSort_none, 0, 1);
            this.imageSortPanel.Location = new System.Drawing.Point(0, -3);
            this.imageSortPanel.Name = "imageSortPanel";
            this.imageSortPanel.RowCount = 2;
            this.imageSortPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.imageSortPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.imageSortPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.imageSortPanel.Size = new System.Drawing.Size(195, 165);
            this.imageSortPanel.TabIndex = 3;
            this.imageSortPanel.Visible = false;
            // 
            // imageSort_full
            // 
            this.imageSort_full.AllowDrop = true;
            this.imageSort_full.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageSort_full.ButtonImage = global::UI.Properties.Resources.full_normal1;
            this.imageSort_full.ButtonText = "";
            this.imageSort_full.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageSort_full.Location = new System.Drawing.Point(3, 3);
            this.imageSort_full.MouseClickImage = global::UI.Properties.Resources.full_selected;
            this.imageSort_full.MouseOverImage = global::UI.Properties.Resources.full_selected;
            this.imageSort_full.Name = "imageSort_full";
            this.imageSort_full.Size = new System.Drawing.Size(189, 76);
            this.imageSort_full.TabIndex = 0;
            this.imageSort_full.Click += new LT.WinForm.ImageButton.ImageButton.ClickEventHandler(this.imageSort_full_Click);
            // 
            // imageSort_none
            // 
            this.imageSort_none.AllowDrop = true;
            this.imageSort_none.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageSort_none.ButtonImage = global::UI.Properties.Resources.none_normal1;
            this.imageSort_none.ButtonText = "";
            this.imageSort_none.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageSort_none.Location = new System.Drawing.Point(3, 85);
            this.imageSort_none.MouseClickImage = global::UI.Properties.Resources.none_selected;
            this.imageSort_none.MouseOverImage = global::UI.Properties.Resources.none_selected;
            this.imageSort_none.Name = "imageSort_none";
            this.imageSort_none.Size = new System.Drawing.Size(189, 77);
            this.imageSort_none.TabIndex = 1;
            this.imageSort_none.Click += new LT.WinForm.ImageButton.ImageButton.ClickEventHandler(this.imageSort_none_Click);
            // 
            // imageClearPanel
            // 
            this.imageClearPanel.ColumnCount = 1;
            this.imageClearPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.imageClearPanel.Controls.Add(this.imageCompress_full, 0, 0);
            this.imageClearPanel.Controls.Add(this.imageCompress_none, 0, 1);
            this.imageClearPanel.Location = new System.Drawing.Point(388, -3);
            this.imageClearPanel.Name = "imageClearPanel";
            this.imageClearPanel.RowCount = 2;
            this.imageClearPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.imageClearPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.imageClearPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.imageClearPanel.Size = new System.Drawing.Size(195, 165);
            this.imageClearPanel.TabIndex = 2;
            this.imageClearPanel.Visible = false;
            // 
            // imageCompress_full
            // 
            this.imageCompress_full.AllowDrop = true;
            this.imageCompress_full.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageCompress_full.ButtonImage = global::UI.Properties.Resources.full_normal1;
            this.imageCompress_full.ButtonText = "";
            this.imageCompress_full.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageCompress_full.Location = new System.Drawing.Point(3, 3);
            this.imageCompress_full.MouseClickImage = global::UI.Properties.Resources.full_selected;
            this.imageCompress_full.MouseOverImage = global::UI.Properties.Resources.full_selected;
            this.imageCompress_full.Name = "imageCompress_full";
            this.imageCompress_full.Size = new System.Drawing.Size(189, 76);
            this.imageCompress_full.TabIndex = 0;
            this.imageCompress_full.Click += new LT.WinForm.ImageButton.ImageButton.ClickEventHandler(this.imageClear_full_Click);
            // 
            // imageCompress_none
            // 
            this.imageCompress_none.AllowDrop = true;
            this.imageCompress_none.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageCompress_none.ButtonImage = global::UI.Properties.Resources.none_normal1;
            this.imageCompress_none.ButtonText = "";
            this.imageCompress_none.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageCompress_none.Location = new System.Drawing.Point(3, 85);
            this.imageCompress_none.MouseClickImage = global::UI.Properties.Resources.none_selected;
            this.imageCompress_none.MouseOverImage = global::UI.Properties.Resources.none_selected;
            this.imageCompress_none.Name = "imageCompress_none";
            this.imageCompress_none.Size = new System.Drawing.Size(189, 77);
            this.imageCompress_none.TabIndex = 1;
            this.imageCompress_none.Click += new LT.WinForm.ImageButton.ImageButton.ClickEventHandler(this.imageClear_none_Click);
            // 
            // result_show
            // 
            this.result_show.AllowDrop = true;
            this.result_show.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.result_show.AutoScroll = true;
            this.result_show.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.result_show.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.result_show.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.result_show.ColumnCount = 5;
            this.result_show.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.result_show.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.result_show.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.result_show.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.result_show.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.result_show.Location = new System.Drawing.Point(0, 0);
            this.result_show.Margin = new System.Windows.Forms.Padding(0);
            this.result_show.Name = "result_show";
            this.result_show.RowCount = 1;
            this.result_show.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 536F));
            this.result_show.Size = new System.Drawing.Size(900, 514);
            this.result_show.TabIndex = 1;
            this.result_show.Click += new System.EventHandler(this.result_show_Click);
            this.result_show.DragDrop += new System.Windows.Forms.DragEventHandler(this.result_show_DragDrop);
            this.result_show.DragEnter += new System.Windows.Forms.DragEventHandler(this.result_show_DragEnter);
            this.result_show.Resize += new System.EventHandler(this.result_show_Resize);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(211)))), ((int)(((byte)(255)))));
            this.tableLayoutPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel2.Controls.Add(this.deleteImage, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.addImageSet, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.selectALL, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 437);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(286, 57);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // deleteImage
            // 
            this.deleteImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteImage.AutoSize = true;
            this.deleteImage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.deleteImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deleteImage.ButtonImage = ((System.Drawing.Image)(resources.GetObject("deleteImage.ButtonImage")));
            this.deleteImage.ButtonText = "";
            this.deleteImage.Location = new System.Drawing.Point(236, 3);
            this.deleteImage.MouseClickImage = null;
            this.deleteImage.MouseOverImage = ((System.Drawing.Image)(resources.GetObject("deleteImage.MouseOverImage")));
            this.deleteImage.Name = "deleteImage";
            this.deleteImage.Size = new System.Drawing.Size(47, 51);
            this.deleteImage.TabIndex = 2;
            this.deleteImage.Click += new LT.WinForm.ImageButton.ImageButton.ClickEventHandler(this.deleteImage_Click);
            // 
            // addImageSet
            // 
            this.addImageSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addImageSet.AutoSize = true;
            this.addImageSet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addImageSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addImageSet.ButtonImage = ((System.Drawing.Image)(resources.GetObject("addImageSet.ButtonImage")));
            this.addImageSet.ButtonText = "";
            this.addImageSet.Location = new System.Drawing.Point(134, 3);
            this.addImageSet.MouseClickImage = null;
            this.addImageSet.MouseOverImage = ((System.Drawing.Image)(resources.GetObject("addImageSet.MouseOverImage")));
            this.addImageSet.Name = "addImageSet";
            this.addImageSet.Size = new System.Drawing.Size(45, 51);
            this.addImageSet.TabIndex = 1;
            this.addImageSet.Click += new LT.WinForm.ImageButton.ImageButton.ClickEventHandler(this.addImageSet_Click);
            // 
            // selectALL
            // 
            this.selectALL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectALL.AutoSize = true;
            this.selectALL.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.selectALL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectALL.ButtonImage = ((System.Drawing.Image)(resources.GetObject("selectALL.ButtonImage")));
            this.selectALL.ButtonText = "";
            this.selectALL.Location = new System.Drawing.Point(185, 3);
            this.selectALL.MouseClickImage = null;
            this.selectALL.MouseOverImage = ((System.Drawing.Image)(resources.GetObject("selectALL.MouseOverImage")));
            this.selectALL.Name = "selectALL";
            this.selectALL.Size = new System.Drawing.Size(45, 51);
            this.selectALL.TabIndex = 0;
            this.selectALL.Click += new LT.WinForm.ImageButton.ImageButton.ClickEventHandler(this.selectAll_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.treeView1, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(441, 431);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(211)))), ((int)(((byte)(255)))));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.CheckBoxes = true;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.treeView1.FullRowSelect = true;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.ItemHeight = 20;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(441, 431);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
            this.treeView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "addFolder.png");
            this.imageList1.Images.SetKeyName(1, "addImage.png");
            this.imageList1.Images.SetKeyName(2, "addImage2.jpg");
            this.imageList1.Images.SetKeyName(3, "check.png");
            this.imageList1.Images.SetKeyName(4, "clear.png");
            this.imageList1.Images.SetKeyName(5, "close.png");
            this.imageList1.Images.SetKeyName(6, "comparison.png");
            this.imageList1.Images.SetKeyName(7, "compress.png");
            this.imageList1.Images.SetKeyName(8, "delete.png");
            this.imageList1.Images.SetKeyName(9, "folder.png");
            this.imageList1.Images.SetKeyName(10, "ImageSort.jpg");
            this.imageList1.Images.SetKeyName(11, "maximize.png");
            this.imageList1.Images.SetKeyName(12, "minimize.png");
            this.imageList1.Images.SetKeyName(13, "optimization.png");
            this.imageList1.Images.SetKeyName(14, "person.png");
            this.imageList1.Images.SetKeyName(15, "search.png");
            this.imageList1.Images.SetKeyName(16, "settings.png");
            this.imageList1.Images.SetKeyName(17, "MyComputer.png");
            this.imageList1.Images.SetKeyName(18, "FixedDrive.png");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "addImage2.jpg");
            // 
            // selectionMenu
            // 
            this.selectionMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item1,
            this.item2});
            this.selectionMenu.Name = "contextMenuStrip1";
            this.selectionMenu.Size = new System.Drawing.Size(173, 48);
            this.selectionMenu.Opening += new System.ComponentModel.CancelEventHandler(this.selectionMenu_Opening);
            // 
            // item1
            // 
            this.item1.Name = "item1";
            this.item1.Size = new System.Drawing.Size(172, 22);
            this.item1.Text = "选择作为参考图像";
            // 
            // item2
            // 
            this.item2.Name = "item2";
            this.item2.Size = new System.Drawing.Size(172, 22);
            this.item2.Text = "取消选择";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "图像质量排序系统";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 644);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitContainer1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1198, 600);
            this.Name = "MainForm";
            this.Text = "";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.imageSortPanel.ResumeLayout(false);
            this.imageClearPanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.selectionMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinToolTip skinToolTip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private LT.WinForm.ImageButton.ImageButton imageSort;
        private LT.WinForm.ImageButton.ImageButton imageClear;
        private LT.WinForm.ImageButton.ImageButton imageCompare;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private LT.WinForm.ImageButton.ImageButton deleteImage;
        private LT.WinForm.ImageButton.ImageButton selectALL;
        private LT.WinForm.ImageButton.ImageButton addImageSet;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TableLayoutPanel imageSortPanel;
        private LT.WinForm.ImageButton.ImageButton imageSort_full;
        private LT.WinForm.ImageButton.ImageButton imageSort_none;
        private System.Windows.Forms.TableLayoutPanel imageClearPanel;
        private LT.WinForm.ImageButton.ImageButton imageCompress_full;
        private LT.WinForm.ImageButton.ImageButton imageCompress_none;
        public System.Windows.Forms.TableLayoutPanel result_show;
        public System.Windows.Forms.SplitContainer splitContainer2;
        private LT.WinForm.ImageButton.ImageButton imageCompress;
        private System.Windows.Forms.ContextMenuStrip selectionMenu;
        private System.Windows.Forms.ToolStripMenuItem item1;
        private System.Windows.Forms.ToolStripMenuItem item2;
        private LT.WinForm.ImageButton.ImageButton setting;
        private LT.WinForm.ImageButton.ImageButton aboutUs;
        private System.Windows.Forms.Label label1;

    }
}

