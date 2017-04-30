namespace HVS
{
    partial class SortingResult
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
            this.beforeSortingHint = new System.Windows.Forms.Label();
            this.afterSortingHint = new System.Windows.Forms.Label();
            this.beforeSortingPanel = new System.Windows.Forms.TableLayoutPanel();
            this.afterSortingPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // beforeSortingHint
            // 
            this.beforeSortingHint.AutoSize = true;
            this.beforeSortingHint.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.beforeSortingHint.Location = new System.Drawing.Point(435, 30);
            this.beforeSortingHint.Name = "beforeSortingHint";
            this.beforeSortingHint.Size = new System.Drawing.Size(75, 28);
            this.beforeSortingHint.TabIndex = 0;
            this.beforeSortingHint.Text = "排序前";
            // 
            // afterSortingHint
            // 
            this.afterSortingHint.AutoSize = true;
            this.afterSortingHint.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.afterSortingHint.Location = new System.Drawing.Point(435, 320);
            this.afterSortingHint.Name = "afterSortingHint";
            this.afterSortingHint.Size = new System.Drawing.Size(75, 28);
            this.afterSortingHint.TabIndex = 1;
            this.afterSortingHint.Text = "排序后";
            // 
            // beforeSortingPanel
            // 
            this.beforeSortingPanel.AutoScroll = true;
            this.beforeSortingPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.beforeSortingPanel.ColumnCount = 1;
            this.beforeSortingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.beforeSortingPanel.Location = new System.Drawing.Point(25, 65);
            this.beforeSortingPanel.Name = "beforeSortingPanel";
            this.beforeSortingPanel.RowCount = 1;
            this.beforeSortingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.beforeSortingPanel.Size = new System.Drawing.Size(920, 230);
            this.beforeSortingPanel.TabIndex = 2;
            // 
            // afterSortingPanel
            // 
            this.afterSortingPanel.AutoScroll = true;
            this.afterSortingPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.afterSortingPanel.ColumnCount = 1;
            this.afterSortingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.afterSortingPanel.Location = new System.Drawing.Point(25, 355);
            this.afterSortingPanel.Name = "afterSortingPanel";
            this.afterSortingPanel.RowCount = 1;
            this.afterSortingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.afterSortingPanel.Size = new System.Drawing.Size(920, 230);
            this.afterSortingPanel.TabIndex = 3;
            // 
            // SortingResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1504, 735);
            this.Controls.Add(this.afterSortingPanel);
            this.Controls.Add(this.beforeSortingPanel);
            this.Controls.Add(this.afterSortingHint);
            this.Controls.Add(this.beforeSortingHint);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1520, 774);
            this.Name = "SortingResult";
            this.Text = "排序结果";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SortingResult_Load);
            this.Resize += new System.EventHandler(this.SortingResult_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label beforeSortingHint;
        private System.Windows.Forms.Label afterSortingHint;
        private System.Windows.Forms.TableLayoutPanel beforeSortingPanel;
        private System.Windows.Forms.TableLayoutPanel afterSortingPanel;
    }
}