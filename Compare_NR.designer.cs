namespace HVS
{
    partial class Compare_NR
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
            this.compare_image1 = new System.Windows.Forms.Panel();
            this.compare_image2 = new System.Windows.Forms.Panel();
            this.score_text1 = new System.Windows.Forms.Label();
            this.confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // compare_image1
            // 
            this.compare_image1.AutoSize = true;
            this.compare_image1.Location = new System.Drawing.Point(120, 30);
            this.compare_image1.Name = "compare_image1";
            this.compare_image1.Size = new System.Drawing.Size(320, 320);
            this.compare_image1.TabIndex = 16;
            // 
            // compare_image2
            // 
            this.compare_image2.AutoSize = true;
            this.compare_image2.Location = new System.Drawing.Point(560, 30);
            this.compare_image2.Name = "compare_image2";
            this.compare_image2.Size = new System.Drawing.Size(320, 320);
            this.compare_image2.TabIndex = 17;
            // 
            // score_text1
            // 
            this.score_text1.AutoSize = true;
            this.score_text1.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.score_text1.Location = new System.Drawing.Point(345, 425);
            this.score_text1.Name = "score_text1";
            this.score_text1.Size = new System.Drawing.Size(0, 31);
            this.score_text1.TabIndex = 34;
            // 
            // confirm
            // 
            this.confirm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.confirm.Location = new System.Drawing.Point(460, 480);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(80, 40);
            this.confirm.TabIndex = 37;
            this.confirm.Text = "确定";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.comfirm_Click);
            // 
            // CompareForm_none
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 750);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.score_text1);
            this.Controls.Add(this.compare_image2);
            this.Controls.Add(this.compare_image1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1024, 640);
            this.Name = "CompareForm_none";
            this.Text = "图片比较";
            this.Load += new System.EventHandler(this.CompareForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel compare_image1;
        private System.Windows.Forms.Panel compare_image2;
        private System.Windows.Forms.Label score_text1;
        private System.Windows.Forms.Button confirm;
    }
}