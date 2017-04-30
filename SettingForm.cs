using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HVS
{
    public partial class SettingForm : Form
    {
        public static bool flag = false;
        private double size_rate = 0.8;
        public static string imageClear_FRmethod = "PSNR";
        public static string imageClear_NRmethod = "Tenengrad";
        public static string imageCompress_FRmethod = "PSNR";
        public static string imageCompare_NRmethod = "Tenengrad";
        public static string imageSort_FRmethod = "PSNR";
        public static string imageSort_NRmethod = "Tenengrad";
        public static string save_path = "default";
        public static SortedSet<string> item_name = new SortedSet<string>();


        public void ui_init()
        {
            flag = true;
            this.Width = (int)(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width * size_rate);
            this.Height = (int)(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height * size_rate);
            this.Location = new Point((System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            clear.Location = new Point((int)(this.Width * 0.26), (int)(this.Height * 0.07));
            compress.Location = new Point((int)(this.Width * 0.26), (int)(this.Height * 0.27));
            sort.Location = new Point((int)(this.Width * 0.26), (int)(this.Height * 0.39));
            compare.Location = new Point((int)(this.Width * 0.26), (int)(this.Height * 0.58));
            clear_fr.Location = new Point((int)(this.Width * 0.37), (int)(this.Height * 0.07));
            clear_nr.Location = new Point((int)(this.Width * 0.37), (int)(this.Height * 0.155));
            compress_fr.Location = new Point((int)(this.Width * 0.37), (int)(this.Height * 0.27));
            sort_fr.Location = new Point((int)(this.Width * 0.37), (int)(this.Height * 0.39));
            sort_nr.Location = new Point((int)(this.Width * 0.37), (int)(this.Height * 0.475));
            compare_nr.Location = new Point((int)(this.Width * 0.37), (int)(this.Height * 0.58));
            outputFolder.Location = new Point((int)(this.Width * 0.37 - outputFolder.Width + clear_fr.Width), (int)(this.Height * 0.7));
            folder.Location = new Point((int)(this.Width * 0.475), (int)(this.Height * 0.7));
            clear_fr_combobox.Location = new Point((int)(this.Width * 0.475), (int)(this.Height * 0.08));
            clear_nr_combobox.Location = new Point((int)(this.Width * 0.475), (int)(this.Height * 0.165));
            compress_fr_combobox.Location = new Point((int)(this.Width * 0.475), (int)(this.Height * 0.28));
            sorting_fr_combobox.Location = new Point((int)(this.Width * 0.475), (int)(this.Height * 0.39));
            sorting_nr_combobox.Location = new Point((int)(this.Width * 0.475), (int)(this.Height * 0.485));
            compare_nr_combobox.Location = new Point((int)(this.Width * 0.475), (int)(this.Height * 0.58));
            selection.Location = new Point((int)(this.Width * 0.665), (int)(this.Height * 0.695));
            confirm.Location = new Point((int)(this.Width * 0.36), (int)(this.Height * 0.84));
            cancel.Location = new Point((int)(this.Width * 0.54), (int)(this.Height * 0.84));

            clear_fr_combobox.Text = imageClear_FRmethod;
            clear_nr_combobox.Text = imageClear_NRmethod;
            compress_fr_combobox.Text = imageCompress_FRmethod;
            compare_nr_combobox.Text = imageCompare_NRmethod;
            sorting_fr_combobox.Text = imageSort_FRmethod;
            sorting_nr_combobox.Text = imageSort_NRmethod;
            clear_fr_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            clear_nr_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            compress_fr_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            compare_nr_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            sorting_fr_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            sorting_nr_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            folder.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (string str in item_name)
            {
                folder.Items.Add(str);
            }
            folder.Text = save_path;
        }

        //初始化算法列表
        public void algorithm_list_init()
        {
            Dictionary<string, Type> FR_methods = SettingInfo.dllHelper.FR_methods;
            Dictionary<string, Type> RR_methods = SettingInfo.dllHelper.RR_methods;
            Dictionary<string, Type> NR_methods = SettingInfo.dllHelper.NR_methods;

            foreach (KeyValuePair<string, Type> pair in FR_methods)
            {
                if(!clear_fr_combobox.Items.Contains(pair.Key))
                {
                    clear_fr_combobox.Items.Add(pair.Key);
                    compress_fr_combobox.Items.Add(pair.Key);
                    sorting_fr_combobox.Items.Add(pair.Key);
                }
            }

            foreach (KeyValuePair<string, Type> pair in NR_methods)
            {
                if (!clear_nr_combobox.Items.Contains(pair.Key))
                {
                    clear_nr_combobox.Items.Add(pair.Key);
                    compare_nr_combobox.Items.Add(pair.Key);
                    sorting_nr_combobox.Items.Add(pair.Key);
                }
            }
        }

        public SettingForm()
        {
            InitializeComponent();
            algorithm_list_init();
            ui_init();
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            imageClear_FRmethod = clear_fr_combobox.Text;
            imageClear_NRmethod = clear_nr_combobox.Text;
            imageCompress_FRmethod = compress_fr_combobox.Text;
            imageCompare_NRmethod = compare_nr_combobox.Text;
            imageSort_FRmethod = sorting_fr_combobox.Text;
            imageSort_NRmethod = sorting_nr_combobox.Text;
            save_path = folder.Text;

            SettingInfo.imageClear_FRmethod = imageClear_FRmethod;
            SettingInfo.imageClear_NRmethod = imageClear_NRmethod;
            SettingInfo.imageCompress_FRmethod = imageCompress_FRmethod;
            SettingInfo.imageCompare_NRmethod = imageCompare_NRmethod;
            SettingInfo.imageSort_FRmethod = imageSort_FRmethod;
            SettingInfo.imageSort_NRmethod = imageSort_NRmethod;
            SettingInfo.save_path = save_path;

            Dispose();
            flag = false;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            imageClear_FRmethod = SettingInfo.imageClear_FRmethod;
            imageClear_NRmethod = SettingInfo.imageClear_NRmethod;
            imageCompress_FRmethod = SettingInfo.imageCompress_FRmethod;
            imageCompare_NRmethod = SettingInfo.imageCompare_NRmethod;
            imageSort_FRmethod = SettingInfo.imageSort_FRmethod;
            imageSort_NRmethod = SettingInfo.imageSort_NRmethod;
            save_path = SettingInfo.save_path;

            Dispose();
            flag = false;
        }

        private void selection_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folder.Items.Add(folderBrowserDialog1.SelectedPath);
                save_path = folderBrowserDialog1.SelectedPath;
                if (!item_name.Contains(save_path))
                {
                    item_name.Add(save_path);
                }
                folder.Text = save_path;
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
