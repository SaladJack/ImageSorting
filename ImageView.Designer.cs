namespace UI
{
    partial class ImageView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageView));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rightButton = new LT.WinForm.ImageButton.ImageButton();
            this.leftButton = new LT.WinForm.ImageButton.ImageButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.rightButton, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.leftButton, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-7, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(318, 244);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(63, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pictureBox1.Size = new System.Drawing.Size(192, 238);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // rightButton
            // 
            this.rightButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rightButton.ButtonImage = global::UI.Properties.Resources.right_arrow;
            this.rightButton.ButtonText = "";
            this.rightButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.rightButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rightButton.Location = new System.Drawing.Point(258, 20);
            this.rightButton.Margin = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.rightButton.MouseClickImage = ((System.Drawing.Image)(resources.GetObject("rightButton.MouseClickImage")));
            this.rightButton.MouseOverImage = ((System.Drawing.Image)(resources.GetObject("rightButton.MouseOverImage")));
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(44, 138);
            this.rightButton.TabIndex = 2;
            this.rightButton.Click += new LT.WinForm.ImageButton.ImageButton.ClickEventHandler(this.imageButton2_Click);
            // 
            // leftButton
            // 
            this.leftButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.leftButton.ButtonImage = global::UI.Properties.Resources.left_arrow;
            this.leftButton.ButtonText = "";
            this.leftButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.leftButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.leftButton.Location = new System.Drawing.Point(10, 20);
            this.leftButton.Margin = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.leftButton.MouseClickImage = ((System.Drawing.Image)(resources.GetObject("leftButton.MouseClickImage")));
            this.leftButton.MouseOverImage = ((System.Drawing.Image)(resources.GetObject("leftButton.MouseOverImage")));
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(44, 138);
            this.leftButton.TabIndex = 3;
            this.leftButton.Click += new LT.WinForm.ImageButton.ImageButton.ClickEventHandler(this.imageButton1_Click);
            // 
            // ImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 268);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ImageView";
            this.Text = "ImageView";
            this.Load += new System.EventHandler(this.ImageView_Load);
            this.Resize += new System.EventHandler(this.ImageView_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        protected LT.WinForm.ImageButton.ImageButton rightButton;
        protected LT.WinForm.ImageButton.ImageButton leftButton;
    }
}