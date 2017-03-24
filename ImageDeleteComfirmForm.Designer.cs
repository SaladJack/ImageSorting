namespace UI
{
    partial class ImageDeleteComfirmForm
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
            this.result = new System.Windows.Forms.TableLayoutPanel();
            this.hint = new System.Windows.Forms.Label();
            this.confirm = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // result
            // 
            this.result.AutoScroll = true;
            this.result.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.result.ColumnCount = 4;
            this.result.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.result.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.result.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.result.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.result.Location = new System.Drawing.Point(40, 94);
            this.result.Name = "result";
            this.result.RowCount = 1;
            this.result.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.result.Size = new System.Drawing.Size(1040, 260);
            this.result.TabIndex = 3;
            // 
            // hint
            // 
            this.hint.AutoSize = true;
            this.hint.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hint.Location = new System.Drawing.Point(463, 22);
            this.hint.Name = "hint";
            this.hint.Size = new System.Drawing.Size(230, 31);
            this.hint.TabIndex = 4;
            this.hint.Text = "以下图片将要被删除";
            // 
            // confirm
            // 
            this.confirm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.confirm.Location = new System.Drawing.Point(390, 400);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(96, 48);
            this.confirm.TabIndex = 5;
            this.confirm.Text = "确认删除";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.comfirm_Click);
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancel.Location = new System.Drawing.Point(630, 400);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(96, 48);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "取消删除";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // ImageDeleteComfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 501);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.hint);
            this.Controls.Add(this.result);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1200, 540);
            this.Name = "ImageDeleteComfirmForm";
            this.Text = "图片清理";
            this.Load += new System.EventHandler(this.ImageDeleteComfirmForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel result;
        private System.Windows.Forms.Label hint;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button cancel;

    }
}