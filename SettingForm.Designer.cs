namespace UI
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
            this.clearance = new System.Windows.Forms.Label();
            this.compression = new System.Windows.Forms.Label();
            this.sorting = new System.Windows.Forms.Label();
            this.clearance_full = new System.Windows.Forms.Label();
            this.clearance_none = new System.Windows.Forms.Label();
            this.compression_none = new System.Windows.Forms.Label();
            this.sorting_none = new System.Windows.Forms.Label();
            this.sorting_full = new System.Windows.Forms.Label();
            this.clearance_full_combobox = new System.Windows.Forms.ComboBox();
            this.clearance_none_combobox = new System.Windows.Forms.ComboBox();
            this.compression_none_combobox = new System.Windows.Forms.ComboBox();
            this.sorting_full_combobox = new System.Windows.Forms.ComboBox();
            this.sorting_none_combobox = new System.Windows.Forms.ComboBox();
            this.confirm = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.comparation_none_combobox = new System.Windows.Forms.ComboBox();
            this.comparation_none = new System.Windows.Forms.Label();
            this.comparation = new System.Windows.Forms.Label();
            this.outputFolder = new System.Windows.Forms.Label();
            this.folder = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.selection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clearance
            // 
            this.clearance.AutoSize = true;
            this.clearance.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.clearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.clearance.Location = new System.Drawing.Point(117, 40);
            this.clearance.Name = "clearance";
            this.clearance.Size = new System.Drawing.Size(123, 35);
            this.clearance.TabIndex = 0;
            this.clearance.Text = "图片清理";
            // 
            // compression
            // 
            this.compression.AutoSize = true;
            this.compression.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.compression.ForeColor = System.Drawing.SystemColors.ControlText;
            this.compression.Location = new System.Drawing.Point(117, 130);
            this.compression.Name = "compression";
            this.compression.Size = new System.Drawing.Size(123, 35);
            this.compression.TabIndex = 1;
            this.compression.Text = "保质压缩";
            // 
            // sorting
            // 
            this.sorting.AutoSize = true;
            this.sorting.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.sorting.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sorting.Location = new System.Drawing.Point(117, 180);
            this.sorting.Name = "sorting";
            this.sorting.Size = new System.Drawing.Size(123, 35);
            this.sorting.TabIndex = 2;
            this.sorting.Text = "质量排序";
            // 
            // clearance_full
            // 
            this.clearance_full.AutoSize = true;
            this.clearance_full.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.clearance_full.ForeColor = System.Drawing.SystemColors.ControlText;
            this.clearance_full.Location = new System.Drawing.Point(245, 40);
            this.clearance_full.Name = "clearance_full";
            this.clearance_full.Size = new System.Drawing.Size(96, 35);
            this.clearance_full.TabIndex = 3;
            this.clearance_full.Text = "全参考";
            // 
            // clearance_none
            // 
            this.clearance_none.AutoSize = true;
            this.clearance_none.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.clearance_none.ForeColor = System.Drawing.SystemColors.ControlText;
            this.clearance_none.Location = new System.Drawing.Point(245, 85);
            this.clearance_none.Name = "clearance_none";
            this.clearance_none.Size = new System.Drawing.Size(96, 35);
            this.clearance_none.TabIndex = 4;
            this.clearance_none.Text = "无参考";
            // 
            // compression_none
            // 
            this.compression_none.AutoSize = true;
            this.compression_none.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.compression_none.ForeColor = System.Drawing.SystemColors.ControlText;
            this.compression_none.Location = new System.Drawing.Point(245, 130);
            this.compression_none.Name = "compression_none";
            this.compression_none.Size = new System.Drawing.Size(96, 35);
            this.compression_none.TabIndex = 5;
            this.compression_none.Text = "无参考";
            // 
            // sorting_none
            // 
            this.sorting_none.AutoSize = true;
            this.sorting_none.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.sorting_none.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sorting_none.Location = new System.Drawing.Point(245, 225);
            this.sorting_none.Name = "sorting_none";
            this.sorting_none.Size = new System.Drawing.Size(96, 35);
            this.sorting_none.TabIndex = 8;
            this.sorting_none.Text = "无参考";
            // 
            // sorting_full
            // 
            this.sorting_full.AutoSize = true;
            this.sorting_full.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.sorting_full.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sorting_full.Location = new System.Drawing.Point(245, 180);
            this.sorting_full.Name = "sorting_full";
            this.sorting_full.Size = new System.Drawing.Size(96, 35);
            this.sorting_full.TabIndex = 7;
            this.sorting_full.Text = "全参考";
            // 
            // clearance_full_combobox
            // 
            this.clearance_full_combobox.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.clearance_full_combobox.FormattingEnabled = true;
            this.clearance_full_combobox.ItemHeight = 23;
            this.clearance_full_combobox.Items.AddRange(new object[] {
            "PSNR",
            "LBP"});
            this.clearance_full_combobox.Location = new System.Drawing.Point(398, 39);
            this.clearance_full_combobox.Name = "clearance_full_combobox";
            this.clearance_full_combobox.Size = new System.Drawing.Size(200, 31);
            this.clearance_full_combobox.TabIndex = 9;
            // 
            // clearance_none_combobox
            // 
            this.clearance_none_combobox.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.clearance_none_combobox.FormattingEnabled = true;
            this.clearance_none_combobox.ItemHeight = 23;
            this.clearance_none_combobox.Items.AddRange(new object[] {
            "tenengrad"});
            this.clearance_none_combobox.Location = new System.Drawing.Point(398, 84);
            this.clearance_none_combobox.Name = "clearance_none_combobox";
            this.clearance_none_combobox.Size = new System.Drawing.Size(200, 31);
            this.clearance_none_combobox.TabIndex = 10;
            // 
            // compression_none_combobox
            // 
            this.compression_none_combobox.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.compression_none_combobox.FormattingEnabled = true;
            this.compression_none_combobox.ItemHeight = 23;
            this.compression_none_combobox.Items.AddRange(new object[] {
            "tenengrad"});
            this.compression_none_combobox.Location = new System.Drawing.Point(398, 129);
            this.compression_none_combobox.Name = "compression_none_combobox";
            this.compression_none_combobox.Size = new System.Drawing.Size(200, 31);
            this.compression_none_combobox.TabIndex = 11;
            // 
            // sorting_full_combobox
            // 
            this.sorting_full_combobox.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.sorting_full_combobox.FormattingEnabled = true;
            this.sorting_full_combobox.ItemHeight = 23;
            this.sorting_full_combobox.Items.AddRange(new object[] {
            "PSNR",
            "LBP"});
            this.sorting_full_combobox.Location = new System.Drawing.Point(398, 179);
            this.sorting_full_combobox.Name = "sorting_full_combobox";
            this.sorting_full_combobox.Size = new System.Drawing.Size(200, 31);
            this.sorting_full_combobox.TabIndex = 13;
            // 
            // sorting_none_combobox
            // 
            this.sorting_none_combobox.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.sorting_none_combobox.FormattingEnabled = true;
            this.sorting_none_combobox.ItemHeight = 23;
            this.sorting_none_combobox.Items.AddRange(new object[] {
            "tenengrad"});
            this.sorting_none_combobox.Location = new System.Drawing.Point(398, 224);
            this.sorting_none_combobox.Name = "sorting_none_combobox";
            this.sorting_none_combobox.Size = new System.Drawing.Size(200, 31);
            this.sorting_none_combobox.TabIndex = 14;
            // 
            // confirm
            // 
            this.confirm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.confirm.Location = new System.Drawing.Point(366, 390);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(75, 30);
            this.confirm.TabIndex = 15;
            this.confirm.Text = "确定";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancel.Location = new System.Drawing.Point(506, 390);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 30);
            this.cancel.TabIndex = 16;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // comparation_none_combobox
            // 
            this.comparation_none_combobox.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.comparation_none_combobox.FormattingEnabled = true;
            this.comparation_none_combobox.ItemHeight = 23;
            this.comparation_none_combobox.Items.AddRange(new object[] {
            "tenengrad"});
            this.comparation_none_combobox.Location = new System.Drawing.Point(398, 269);
            this.comparation_none_combobox.Name = "comparation_none_combobox";
            this.comparation_none_combobox.Size = new System.Drawing.Size(200, 31);
            this.comparation_none_combobox.TabIndex = 12;
            // 
            // comparation_none
            // 
            this.comparation_none.AutoSize = true;
            this.comparation_none.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.comparation_none.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comparation_none.Location = new System.Drawing.Point(245, 270);
            this.comparation_none.Name = "comparation_none";
            this.comparation_none.Size = new System.Drawing.Size(96, 35);
            this.comparation_none.TabIndex = 6;
            this.comparation_none.Text = "无参考";
            // 
            // comparation
            // 
            this.comparation.AutoSize = true;
            this.comparation.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.comparation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comparation.Location = new System.Drawing.Point(114, 269);
            this.comparation.Name = "comparation";
            this.comparation.Size = new System.Drawing.Size(123, 35);
            this.comparation.TabIndex = 17;
            this.comparation.Text = "质量比较";
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
            this.selection.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.selection.Location = new System.Drawing.Point(618, 329);
            this.selection.Name = "selection";
            this.selection.Size = new System.Drawing.Size(75, 30);
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
            this.Controls.Add(this.comparation);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.sorting_none_combobox);
            this.Controls.Add(this.sorting_full_combobox);
            this.Controls.Add(this.comparation_none_combobox);
            this.Controls.Add(this.compression_none_combobox);
            this.Controls.Add(this.clearance_none_combobox);
            this.Controls.Add(this.clearance_full_combobox);
            this.Controls.Add(this.sorting_none);
            this.Controls.Add(this.sorting_full);
            this.Controls.Add(this.comparation_none);
            this.Controls.Add(this.compression_none);
            this.Controls.Add(this.clearance_none);
            this.Controls.Add(this.clearance_full);
            this.Controls.Add(this.sorting);
            this.Controls.Add(this.compression);
            this.Controls.Add(this.clearance);
            this.MaximizeBox = false;
            this.Name = "SettingForm";
            this.Text = "设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label clearance;
        private System.Windows.Forms.Label compression;
        private System.Windows.Forms.Label sorting;
        private System.Windows.Forms.Label clearance_full;
        private System.Windows.Forms.Label clearance_none;
        private System.Windows.Forms.Label compression_none;
        private System.Windows.Forms.Label sorting_none;
        private System.Windows.Forms.Label sorting_full;
        private System.Windows.Forms.ComboBox clearance_full_combobox;
        private System.Windows.Forms.ComboBox clearance_none_combobox;
        private System.Windows.Forms.ComboBox compression_none_combobox;
        private System.Windows.Forms.ComboBox sorting_full_combobox;
        private System.Windows.Forms.ComboBox sorting_none_combobox;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ComboBox comparation_none_combobox;
        private System.Windows.Forms.Label comparation_none;
        private System.Windows.Forms.Label comparation;
        private System.Windows.Forms.Label outputFolder;
        private System.Windows.Forms.ComboBox folder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button selection;
    }
}