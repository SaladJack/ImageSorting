using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class SettingForm : Form
    {
        public static bool flag = false;
        private double size_rate = 0.8;
        static string previous_image_clearance_full;
        static string previous_image_clearance_none;
        static string previous_image_compression_none;
        static string previous_image_comparation_none;
        static string previous_image_sorting_full;
        static string previous_image_sorting_none;
        public SettingForm()
        {
            flag = true;
            InitializeComponent();
            this.Width = (int)(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width * size_rate);
            this.Height = (int)(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height * size_rate);
            this.Location = new Point((System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            clearance.Location = new Point((int)(this.Width * 0.26), (int)(this.Height * 0.13));
            compression.Location = new Point((int)(this.Width * 0.26), (int)(this.Height * 0.33));
            sorting.Location = new Point((int)(this.Width * 0.26), (int)(this.Height * 0.45));
            comparation.Location = new Point((int)(this.Width * 0.26), (int)(this.Height * 0.64));
            clearance_full.Location = new Point((int)(this.Width * 0.37), (int)(this.Height * 0.13));
            clearance_none.Location = new Point((int)(this.Width * 0.37), (int)(this.Height * 0.215));
            compression_none.Location = new Point((int)(this.Width * 0.37), (int)(this.Height * 0.33));
            sorting_full.Location = new Point((int)(this.Width * 0.37), (int)(this.Height * 0.45));
            sorting_none.Location = new Point((int)(this.Width * 0.37), (int)(this.Height * 0.535));
            comparation_none.Location = new Point((int)(this.Width * 0.37), (int)(this.Height * 0.64));
            outputFolder.Location = new Point((int)(this.Width * 0.37 - outputFolder.Width + clearance_full.Width), (int)(this.Height * 0.76));
            folder.Location = new Point((int)(this.Width * 0.475), (int)(this.Height * 0.76));
            clearance_full_combobox.Location = new Point((int)(this.Width * 0.475), (int)(this.Height * 0.14));
            clearance_none_combobox.Location = new Point((int)(this.Width * 0.475), (int)(this.Height * 0.225));
            compression_none_combobox.Location = new Point((int)(this.Width * 0.475), (int)(this.Height * 0.34));
            sorting_full_combobox.Location = new Point((int)(this.Width * 0.475), (int)(this.Height * 0.45));
            sorting_none_combobox.Location = new Point((int)(this.Width * 0.475), (int)(this.Height * 0.545));
            comparation_none_combobox.Location = new Point((int)(this.Width * 0.475), (int)(this.Height * 0.64));
            selection.Location = new Point((int)(this.Width * 0.665), (int)(this.Height * 0.76));
            confirm.Location = new Point((int)(this.Width * 0.4), (int)(this.Height * 0.87));
            cancel.Location = new Point((int)(this.Width * 0.5), (int)(this.Height * 0.87));

            clearance_full_combobox.Text = previous_image_clearance_full;
            clearance_none_combobox.Text = previous_image_clearance_none;
            compression_none_combobox.Text = previous_image_compression_none;
            comparation_none_combobox.Text = previous_image_comparation_none;
            sorting_full_combobox.Text = previous_image_sorting_full;
            sorting_none_combobox.Text = previous_image_sorting_none;

            this.clearance_full_combobox.SelectedIndex = SettingInfo.image_clean_full_selected;
            this.clearance_none_combobox.SelectedIndex = SettingInfo.image_clean_none_selected;
            this.compression_none_combobox.SelectedIndex = SettingInfo.image_compress_full_selected;
            this.comparation_none_combobox.SelectedIndex = SettingInfo.image_compare_none_selected;
            this.sorting_full_combobox.SelectedIndex = SettingInfo.image_sort_full_selected;
            this.sorting_none_combobox.SelectedIndex = SettingInfo.image_sort_none_selected;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            SettingInfo.image_clean_full = clearance_full_combobox.Text;
            SettingInfo.image_clean_none = clearance_none_combobox.Text;
            SettingInfo.image_compress_full = compression_none_combobox.Text;
            SettingInfo.image_compare_none = comparation_none_combobox.Text;
            SettingInfo.image_sort_full = sorting_full_combobox.Text;
            SettingInfo.image_sort_none = sorting_none_combobox.Text;

            SettingInfo.image_clean_full_selected = this.clearance_full_combobox.SelectedIndex;
            SettingInfo.image_clean_none_selected = this.clearance_none_combobox.SelectedIndex;
            SettingInfo.image_compress_full_selected = this.compression_none_combobox.SelectedIndex;
            SettingInfo.image_compare_none_selected = this.comparation_none_combobox.SelectedIndex;
            SettingInfo.image_sort_full_selected = this.sorting_full_combobox.SelectedIndex;
            SettingInfo.image_sort_none_selected = this.sorting_none_combobox.SelectedIndex;
            Dispose();
            flag = false;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            previous_image_clearance_full = clearance_full_combobox.Text;
            previous_image_clearance_none = clearance_none_combobox.Text;
            previous_image_compression_none = compression_none_combobox.Text;
            previous_image_comparation_none = comparation_none_combobox.Text;
            previous_image_sorting_full = sorting_full_combobox.Text;
            previous_image_sorting_none = sorting_none_combobox.Text;
            Dispose();
            flag = false;
        }

        private void selection_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folder.Items.Add(folderBrowserDialog1.SelectedPath);
                folder.Text = folderBrowserDialog1.SelectedPath;
                SettingInfo.save_path = folderBrowserDialog1.SelectedPath;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            flag = false;
        }
    }
}
