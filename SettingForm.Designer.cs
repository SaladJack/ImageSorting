namespace HVS
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clear = new System.Windows.Forms.Label();
            this.compress = new System.Windows.Forms.Label();
            this.sort = new System.Windows.Forms.Label();
            this.clear_fr = new System.Windows.Forms.Label();
            this.clear_nr = new System.Windows.Forms.Label();
            this.compress_fr = new System.Windows.Forms.Label();
            this.sort_nr = new System.Windows.Forms.Label();
            this.sort_fr = new System.Windows.Forms.Label();
            this.clear_fr_combobox = new System.Windows.Forms.ComboBox();
            this.clear_nr_combobox = new System.Windows.Forms.ComboBox();
            this.compress_fr_combobox = new System.Windows.Forms.ComboBox();
            this.sorting_fr_combobox = new System.Windows.Forms.ComboBox();
            this.sorting_nr_combobox = new System.Windows.Forms.ComboBox();
            this.confirm = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.compare_nr_combobox = new System.Windows.Forms.ComboBox();
            this.compare_nr = new System.Windows.Forms.Label();
            this.compare = new System.Windows.Forms.Label();
            this.outputFolder = new System.Windows.Forms.Label();
            this.folder = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.selection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clear
            // 
            this.clear.AutoSize = true;
            this.clear.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.clear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.clear.Location = new System.Drawing.Point(117, 40);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(123, 35);
            this.clear.TabIndex = 0;
            this.clear.Text = "图片清理";
            // 
            // compress
            // 
            this.compress.AutoSize = true;
            this.compress.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.compress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.compress.Location = new System.Drawing.Point(117, 130);
            this.compress.Name = "compress";
            this.compress.Size = new System.Drawing.Size(123, 35);
            this.compress.TabIndex = 1;
            this.compress.Text = "保质压缩";
            // 
            // sort
            // 
            this.sort.AutoSize = true;
            this.sort.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.sort.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sort.Location = new System.Drawing.Point(117, 180);
            this.sort.Name = "sort";
            this.sort.Size = new System.Drawing.Size(123, 35);
            this.sort.TabIndex = 2;
            this.sort.Text = "质量排序";
            // 
            // clear_fr
            // 
            this.clear_fr.AutoSize = true;
            this.clear_fr.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.clear_fr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.clear_fr.Location = new System.Drawing.Point(245, 40);
            this.clear_fr.Name = "clear_fr";
            this.clear_fr.Size = new System.Drawing.Size(96, 35);
            this.clear_fr.TabIndex = 3;
            this.clear_fr.Text = "全参考";
            // 
            // clear_nr
            // 
            this.clear_nr.AutoSize = true;
            this.clear_nr.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.clear_nr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.clear_nr.Location = new System.Drawing.Point(245, 85);
            this.clear_nr.Name = "clear_nr";
            this.clear_nr.Size = new System.Drawing.Size(96, 35);
            this.clear_nr.TabIndex = 4;
            this.clear_nr.Text = "无参考";
            // 
            // compress_fr
            // 
            this.compress_fr.AutoSize = true;
            this.compress_fr.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.compress_fr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.compress_fr.Location = new System.Drawing.Point(245, 130);
            this.compress_fr.Name = "compress_fr";
            this.compress_fr.Size = new System.Drawing.Size(96, 35);
            this.compress_fr.TabIndex = 5;
            this.compress_fr.Text = "全参考";
            // 
            // sort_nr
            // 
            this.sort_nr.AutoSize = true;
            this.sort_nr.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.sort_nr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sort_nr.Location = new System.Drawing.Point(245, 225);
            this.sort_nr.Name = "sort_nr";
            this.sort_nr.Size = new System.Drawing.Size(96, 35);
            this.sort_nr.TabIndex = 8;
            this.sort_nr.Text = "无参考";
            // 
            // sort_fr
            // 
            this.sort_fr.AutoSize = true;
            this.sort_fr.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.sort_fr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sort_fr.Location = new System.Drawing.Point(245, 180);
            this.sort_fr.Name = "sort_fr";
            this.sort_fr.Size = new System.Drawing.Size(96, 35);
            this.sort_fr.TabIndex = 7;
            this.sort_fr.Text = "全参考";
            // 
            // clear_fr_combobox
            // 
            this.clear_fr_combobox.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.clear_fr_combobox.FormattingEnabled = true;
            this.clear_fr_combobox.ItemHeight = 23;
            this.clear_fr_combobox.Items.AddRange(new object[] {
            "PSNR",
            "LBP"});
            this.clear_fr_combobox.Location = new System.Drawing.Point(398, 39);
            this.clear_fr_combobox.Name = "clear_fr_combobox";
            this.clear_fr_combobox.Size = new System.Drawing.Size(200, 31);
            this.clear_fr_combobox.TabIndex = 9;
            // 
            // clear_nr_combobox
            // 
            this.clear_nr_combobox.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.clear_nr_combobox.FormattingEnabled = true;
            this.clear_nr_combobox.ItemHeight = 23;
            this.clear_nr_combobox.Items.AddRange(new object[] {
            "Tenengrad",
            "Brenner"});
            this.clear_nr_combobox.Location = new System.Drawing.Point(398, 84);
            this.clear_nr_combobox.Name = "clear_nr_combobox";
            this.clear_nr_combobox.Size = new System.Drawing.Size(200, 31);
            this.clear_nr_combobox.TabIndex = 10;
            // 
            // compress_fr_combobox
            // 
            this.compress_fr_combobox.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.compress_fr_combobox.FormattingEnabled = true;
            this.compress_fr_combobox.ItemHeight = 23;
            this.compress_fr_combobox.Items.AddRange(new object[] {
            "PSNR",
            "LBP"});
            this.compress_fr_combobox.Location = new System.Drawing.Point(398, 129);
            this.compress_fr_combobox.Name = "compress_fr_combobox";
            this.compress_fr_combobox.Size = new System.Drawing.Size(200, 31);
            this.compress_fr_combobox.TabIndex = 11;
            // 
            // sorting_fr_combobox
            // 
            this.sorting_fr_combobox.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.sorting_fr_combobox.FormattingEnabled = true;
            this.sorting_fr_combobox.ItemHeight = 23;
            this.sorting_fr_combobox.Items.AddRange(new object[] {
            "PSNR",
            "LBP"});
            this.sorting_fr_combobox.Location = new System.Drawing.Point(398, 179);
            this.sorting_fr_combobox.Name = "sorting_fr_combobox";
            this.sorting_fr_combobox.Size = new System.Drawing.Size(200, 31);
            this.sorting_fr_combobox.TabIndex = 13;
            // 
            // sorting_nr_combobox
            // 
            this.sorting_nr_combobox.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.sorting_nr_combobox.FormattingEnabled = true;
            this.sorting_nr_combobox.ItemHeight = 23;
            this.sorting_nr_combobox.Items.AddRange(new object[] {
            "Tenengrad",
            "Brenner"});
            this.sorting_nr_combobox.Location = new System.Drawing.Point(398, 224);
            this.sorting_nr_combobox.Name = "sorting_nr_combobox";
            this.sorting_nr_combobox.Size = new System.Drawing.Size(200, 31);
            this.sorting_nr_combobox.TabIndex = 14;
            // 
            // confirm
            // 
            this.confirm.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.confirm.Location = new System.Drawing.Point(366, 390);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(85, 45);
            this.confirm.TabIndex = 15;
            this.confirm.Text = "确定";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            this.cancel.Location = new System.Drawing.Point(506, 390);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(85, 45);
            this.cancel.TabIndex = 16;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // compare_nr_combobox
            // 
            this.compare_nr_combobox.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.compare_nr_combobox.FormattingEnabled = true;
            this.compare_nr_combobox.ItemHeight = 23;
            this.compare_nr_combobox.Items.AddRange(new object[] {
            "Tenengrad",
            "Brenner"});
            this.compare_nr_combobox.Location = new System.Drawing.Point(398, 269);
            this.compare_nr_combobox.Name = "compare_nr_combobox";
            this.compare_nr_combobox.Size = new System.Drawing.Size(200, 31);
            this.compare_nr_combobox.TabIndex = 12;
            // 
            // compare_nr
            // 
            this.compare_nr.AutoSize = true;
            this.compare_nr.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.compare_nr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.compare_nr.Location = new System.Drawing.Point(245, 270);
            this.compare_nr.Name = "compare_nr";
            this.compare_nr.Size = new System.Drawing.Size(96, 35);
            this.compare_nr.TabIndex = 6;
            this.compare_nr.Text = "无参考";
            // 
            // compare
            // 
            this.compare.AutoSize = true;
            this.compare.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.compare.ForeColor = System.Drawing.SystemColors.ControlText;
            this.compare.Location = new System.Drawing.Point(114, 269);
            this.compare.Name = "compare";
            this.compare.Size = new System.Drawing.Size(123, 35);
            this.compare.TabIndex = 17;
            this.compare.Text = "质量比较";
            // 
            // outputFolder
            // 
            this.outputFolder.AutoSize = true;
            this.outputFolder.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.outputFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.outputFolder.Location = new System.Drawing.Point(150, 325);
            this.outputFolder.Name = "outputFolder";
            this.outputFolder.Size = new System.Drawing.Size(204, 35);
            this.outputFolder.TabIndex = 18;
            this.outputFolder.Text = "图像输出文件夹";
            // 
            // folder
            // 
            this.folder.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.folder.FormattingEnabled = true;
            this.folder.ItemHeight = 23;
            this.folder.Items.AddRange(new object[] {
            "default"});
            this.folder.Location = new System.Drawing.Point(398, 329);
            this.folder.Name = "folder";
            this.folder.Size = new System.Drawing.Size(200, 31);
            this.folder.TabIndex = 19;
            this.folder.Text = "default";
            // 
            // selection
            // 
            this.selection.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            this.selection.Location = new System.Drawing.Point(618, 329);
            this.selection.Name = "selection";
            this.selection.Size = new System.Drawing.Size(120, 40);
            this.selection.TabIndex = 20;
            this.selection.Text = "浏览文件夹";
            this.selection.UseVisualStyleBackColor = true;
            this.selection.Click += new System.EventHandler(this.selection_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 564);
            this.Controls.Add(this.selection);
            this.Controls.Add(this.folder);
            this.Controls.Add(this.outputFolder);
            this.Controls.Add(this.compare);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.sorting_nr_combobox);
            this.Controls.Add(this.sorting_fr_combobox);
            this.Controls.Add(this.compare_nr_combobox);
            this.Controls.Add(this.compress_fr_combobox);
            this.Controls.Add(this.clear_nr_combobox);
            this.Controls.Add(this.clear_fr_combobox);
            this.Controls.Add(this.sort_nr);
            this.Controls.Add(this.sort_fr);
            this.Controls.Add(this.compare_nr);
            this.Controls.Add(this.compress_fr);
            this.Controls.Add(this.clear_nr);
            this.Controls.Add(this.clear_fr);
            this.Controls.Add(this.sort);
            this.Controls.Add(this.compress);
            this.Controls.Add(this.clear);
            this.MaximizeBox = false;
            this.Name = "SettingForm";
            this.Text = "设置";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label clear;
        private System.Windows.Forms.Label compress;
        private System.Windows.Forms.Label sort;
        private System.Windows.Forms.Label clear_fr;
        private System.Windows.Forms.Label clear_nr;
        private System.Windows.Forms.Label compress_fr;
        private System.Windows.Forms.Label sort_nr;
        private System.Windows.Forms.Label sort_fr;
        private System.Windows.Forms.ComboBox clear_fr_combobox;
        private System.Windows.Forms.ComboBox clear_nr_combobox;
        private System.Windows.Forms.ComboBox compress_fr_combobox;
        private System.Windows.Forms.ComboBox sorting_fr_combobox;
        private System.Windows.Forms.ComboBox sorting_nr_combobox;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ComboBox compare_nr_combobox;
        private System.Windows.Forms.Label compare_nr;
        private System.Windows.Forms.Label compare;
        private System.Windows.Forms.Label outputFolder;
        private System.Windows.Forms.ComboBox folder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button selection;
    }
}