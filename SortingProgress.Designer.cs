namespace HVS
{
    partial class SortingProgress
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
            this.sortingProgressBar = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sortingProgressBar
            // 
            this.sortingProgressBar.Location = new System.Drawing.Point(116, 58);
            this.sortingProgressBar.MarqueeAnimationSpeed = 50;
            this.sortingProgressBar.Maximum = 1000;
            this.sortingProgressBar.Name = "sortingProgressBar";
            this.sortingProgressBar.Size = new System.Drawing.Size(226, 37);
            this.sortingProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.sortingProgressBar.TabIndex = 0;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Font = new System.Drawing.Font("宋体", 10F);
            this.progressLabel.Location = new System.Drawing.Point(25, 70);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(77, 14);
            this.progressLabel.TabIndex = 1;
            this.progressLabel.Text = "排序进度：";
            // 
            // SortingProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.sortingProgressBar);
            this.Name = "SortingProgress";
            this.Text = "排序中";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ProgressBar sortingProgressBar;
        public System.Windows.Forms.Label progressLabel;
    }
}