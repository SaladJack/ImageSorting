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
using HVS;
using Microsoft.VisualBasic.FileIO;

namespace HVS
{
    partial class ClearSetting_NR
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.threadsoldButton = new System.Windows.Forms.RadioButton();
            this.ratioButton = new System.Windows.Forms.RadioButton();
            this.clearRatio = new System.Windows.Forms.Label();
            this.clearRatioHint = new System.Windows.Forms.Label();
            this.clearingRatioBar = new System.Windows.Forms.TrackBar();
            this.cancel = new System.Windows.Forms.Button();
            this.confirm = new System.Windows.Forms.Button();
            this.clearThreadsold = new System.Windows.Forms.Label();
            this.threadsoldBar = new System.Windows.Forms.TrackBar();
            this.clearThreadsoldHint = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.clearingRatioBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadsoldBar)).BeginInit();
            this.SuspendLayout();
            // 
            // threadsoldButton
            // 
            this.threadsoldButton.AutoSize = true;
            this.threadsoldButton.Location = new System.Drawing.Point(485, 170);
            this.threadsoldButton.Name = "threadsoldButton";
            this.threadsoldButton.Size = new System.Drawing.Size(14, 13);
            this.threadsoldButton.TabIndex = 29;
            this.threadsoldButton.TabStop = true;
            this.threadsoldButton.UseVisualStyleBackColor = true;
            this.threadsoldButton.Click += new System.EventHandler(this.thresholdButton_Click);
            // 
            // ratioButton
            // 
            this.ratioButton.AutoSize = true;
            this.ratioButton.Checked = true;
            this.ratioButton.Location = new System.Drawing.Point(485, 110);
            this.ratioButton.Name = "ratioButton";
            this.ratioButton.Size = new System.Drawing.Size(14, 13);
            this.ratioButton.TabIndex = 28;
            this.ratioButton.TabStop = true;
            this.ratioButton.UseVisualStyleBackColor = true;
            this.ratioButton.Click += new System.EventHandler(this.ratioButton_Click);
            // 
            // clearRatio
            // 
            this.clearRatio.AutoSize = true;
            this.clearRatio.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.clearRatio.Location = new System.Drawing.Point(515, 100);
            this.clearRatio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.clearRatio.Name = "clearRatio";
            this.clearRatio.Size = new System.Drawing.Size(55, 28);
            this.clearRatio.TabIndex = 27;
            this.clearRatio.Text = "50%";
            // 
            // clearRatioHint
            // 
            this.clearRatioHint.AutoSize = true;
            this.clearRatioHint.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.clearRatioHint.Location = new System.Drawing.Point(150, 100);
            this.clearRatioHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.clearRatioHint.Name = "clearRatioHint";
            this.clearRatioHint.Size = new System.Drawing.Size(159, 28);
            this.clearRatioHint.TabIndex = 26;
            this.clearRatioHint.Text = "图像清理百分比";
            // 
            // clearingRatioBar
            // 
            this.clearingRatioBar.Location = new System.Drawing.Point(330, 100);
            this.clearingRatioBar.Margin = new System.Windows.Forms.Padding(4);
            this.clearingRatioBar.Maximum = 100;
            this.clearingRatioBar.Name = "clearingRatioBar";
            this.clearingRatioBar.Size = new System.Drawing.Size(141, 45);
            this.clearingRatioBar.TabIndex = 25;
            this.clearingRatioBar.Value = 50;
            this.clearingRatioBar.Scroll += new System.EventHandler(this.ratioBar_Scroll);
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancel.Location = new System.Drawing.Point(400, 240);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(80, 40);
            this.cancel.TabIndex = 24;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // confirm
            // 
            this.confirm.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.confirm.Location = new System.Drawing.Point(220, 240);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(80, 40);
            this.confirm.TabIndex = 23;
            this.confirm.Text = "确定";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // clearThreadsold
            // 
            this.clearThreadsold.AutoSize = true;
            this.clearThreadsold.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clearThreadsold.Location = new System.Drawing.Point(515, 160);
            this.clearThreadsold.Name = "clearThreadsold";
            this.clearThreadsold.Size = new System.Drawing.Size(36, 28);
            this.clearThreadsold.TabIndex = 22;
            this.clearThreadsold.Text = "50";
            // 
            // threadsoldBar
            // 
            this.threadsoldBar.Location = new System.Drawing.Point(330, 160);
            this.threadsoldBar.Maximum = 100;
            this.threadsoldBar.Name = "threadsoldBar";
            this.threadsoldBar.Size = new System.Drawing.Size(141, 45);
            this.threadsoldBar.TabIndex = 21;
            this.threadsoldBar.Value = 50;
            this.threadsoldBar.Scroll += new System.EventHandler(this.threadsoldBar_Scroll);
            // 
            // clearThreadsoldHint
            // 
            this.clearThreadsoldHint.AutoSize = true;
            this.clearThreadsoldHint.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clearThreadsoldHint.Location = new System.Drawing.Point(87, 160);
            this.clearThreadsoldHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.clearThreadsoldHint.Name = "clearThreadsoldHint";
            this.clearThreadsoldHint.Size = new System.Drawing.Size(222, 28);
            this.clearThreadsoldHint.TabIndex = 20;
            this.clearThreadsoldHint.Text = "图像清理质量分数阈值";
            // 
            // ClearSetting_NR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 321);
            this.Controls.Add(this.threadsoldButton);
            this.Controls.Add(this.ratioButton);
            this.Controls.Add(this.clearRatio);
            this.Controls.Add(this.clearRatioHint);
            this.Controls.Add(this.clearingRatioBar);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.clearThreadsold);
            this.Controls.Add(this.threadsoldBar);
            this.Controls.Add(this.clearThreadsoldHint);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClearSetting_NR";
            this.Text = "无参考图像清理设置";
            ((System.ComponentModel.ISupportInitialize)(this.clearingRatioBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadsoldBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RadioButton threadsoldButton;
        private RadioButton ratioButton;
        private Label clearRatio;
        private Label clearRatioHint;
        private TrackBar clearingRatioBar;
        private Button cancel;
        private Button confirm;
        private Label clearThreadsold;
        private TrackBar threadsoldBar;
        private Label clearThreadsoldHint;


    }
}