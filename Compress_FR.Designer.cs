namespace HVS
{
    partial class Compress_FR
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
            this.rate_bar1 = new System.Windows.Forms.TrackBar();
            this.format_selection = new System.Windows.Forms.ComboBox();
            this.image_format = new System.Windows.Forms.Label();
            this.hint1 = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.rate1 = new System.Windows.Forms.Label();
            this.uncompressed_image = new System.Windows.Forms.Panel();
            this.compressed_image = new System.Windows.Forms.Panel();
            this.hint2 = new System.Windows.Forms.Label();
            this.rate_bar2 = new System.Windows.Forms.TrackBar();
            this.rate2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.algorithm_value = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rate_bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rate_bar2)).BeginInit();
            this.SuspendLayout();
            // 
            // rate_bar1
            // 
            this.rate_bar1.Location = new System.Drawing.Point(407, 462);
            this.rate_bar1.Maximum = 100;
            this.rate_bar1.Name = "rate_bar1";
            this.rate_bar1.Size = new System.Drawing.Size(191, 45);
            this.rate_bar1.TabIndex = 4;
            this.rate_bar1.Value = 50;
            this.rate_bar1.Scroll += new System.EventHandler(this.rate_bar1_Scroll);
            // 
            // format_selection
            // 
            this.format_selection.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.format_selection.FormattingEnabled = true;
            this.format_selection.Items.AddRange(new object[] {
            "JPEG",
            "PNG"});
            this.format_selection.Location = new System.Drawing.Point(426, 422);
            this.format_selection.Name = "format_selection";
            this.format_selection.Size = new System.Drawing.Size(157, 29);
            this.format_selection.TabIndex = 7;
            this.format_selection.Text = "JPEG";
            // 
            // image_format
            // 
            this.image_format.AutoSize = true;
            this.image_format.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.image_format.Location = new System.Drawing.Point(279, 422);
            this.image_format.Name = "image_format";
            this.image_format.Size = new System.Drawing.Size(110, 31);
            this.image_format.TabIndex = 8;
            this.image_format.Text = "图片格式";
            // 
            // hint1
            // 
            this.hint1.AutoSize = true;
            this.hint1.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.hint1.Location = new System.Drawing.Point(241, 467);
            this.hint1.Name = "hint1";
            this.hint1.Size = new System.Drawing.Size(158, 31);
            this.hint1.TabIndex = 9;
            this.hint1.Text = "按压缩率压缩";
            // 
            // save
            // 
            this.save.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.save.Location = new System.Drawing.Point(347, 562);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(80, 35);
            this.save.TabIndex = 11;
            this.save.Text = "保存";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.cancel.Location = new System.Drawing.Point(567, 562);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(80, 35);
            this.cancel.TabIndex = 12;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // rate1
            // 
            this.rate1.AutoSize = true;
            this.rate1.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rate1.Location = new System.Drawing.Point(592, 462);
            this.rate1.Name = "rate1";
            this.rate1.Size = new System.Drawing.Size(39, 30);
            this.rate1.TabIndex = 13;
            this.rate1.Text = "50";
            // 
            // uncompressed_image
            // 
            this.uncompressed_image.AutoSize = true;
            this.uncompressed_image.Location = new System.Drawing.Point(34, 25);
            this.uncompressed_image.Name = "uncompressed_image";
            this.uncompressed_image.Size = new System.Drawing.Size(366, 378);
            this.uncompressed_image.TabIndex = 15;
            // 
            // compressed_image
            // 
            this.compressed_image.AutoSize = true;
            this.compressed_image.Location = new System.Drawing.Point(500, 25);
            this.compressed_image.Name = "compressed_image";
            this.compressed_image.Size = new System.Drawing.Size(366, 378);
            this.compressed_image.TabIndex = 16;
            // 
            // hint2
            // 
            this.hint2.AutoSize = true;
            this.hint2.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.hint2.Location = new System.Drawing.Point(222, 513);
            this.hint2.Name = "hint2";
            this.hint2.Size = new System.Drawing.Size(182, 31);
            this.hint2.TabIndex = 17;
            this.hint2.Text = "按质量分数压缩";
            // 
            // rate_bar2
            // 
            this.rate_bar2.Location = new System.Drawing.Point(407, 507);
            this.rate_bar2.Maximum = 100;
            this.rate_bar2.Name = "rate_bar2";
            this.rate_bar2.Size = new System.Drawing.Size(191, 45);
            this.rate_bar2.TabIndex = 18;
            this.rate_bar2.Value = 50;
            this.rate_bar2.Scroll += new System.EventHandler(this.rate_bar2_Scroll);
            // 
            // rate2
            // 
            this.rate2.AutoSize = true;
            this.rate2.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.rate2.Location = new System.Drawing.Point(592, 513);
            this.rate2.Name = "rate2";
            this.rate2.Size = new System.Drawing.Size(39, 30);
            this.rate2.TabIndex = 19;
            this.rate2.Text = "50";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(637, 474);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 20;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(637, 522);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(14, 13);
            this.radioButton2.TabIndex = 21;
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // algorithm_value
            // 
            this.algorithm_value.AutoSize = true;
            this.algorithm_value.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.algorithm_value.Location = new System.Drawing.Point(695, 513);
            this.algorithm_value.Name = "algorithm_value";
            this.algorithm_value.Size = new System.Drawing.Size(171, 28);
            this.algorithm_value.TabIndex = 22;
            this.algorithm_value.Text = "algorithm value";
            // 
            // Compress_FR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 602);
            this.Controls.Add(this.algorithm_value);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.rate2);
            this.Controls.Add(this.rate_bar2);
            this.Controls.Add(this.hint2);
            this.Controls.Add(this.compressed_image);
            this.Controls.Add(this.uncompressed_image);
            this.Controls.Add(this.rate1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.save);
            this.Controls.Add(this.hint1);
            this.Controls.Add(this.image_format);
            this.Controls.Add(this.format_selection);
            this.Controls.Add(this.rate_bar1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1024, 640);
            this.Name = "Compress_FR";
            this.Text = "无参考图像压缩";
            this.Load += new System.EventHandler(this.compressForm_none_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rate_bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rate_bar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar rate_bar1;
        private System.Windows.Forms.ComboBox format_selection;
        private System.Windows.Forms.Label image_format;
        private System.Windows.Forms.Label hint1;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label rate1;
        private System.Windows.Forms.Panel uncompressed_image;
        private System.Windows.Forms.Panel compressed_image;
        private System.Windows.Forms.Label hint2;
        private System.Windows.Forms.TrackBar rate_bar2;
        private System.Windows.Forms.Label rate2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label algorithm_value;
    }
}