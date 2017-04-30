using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace HVS
{
    public partial class SortingProgress : Form
    {
        public SortingProgress()
        {
            InitializeComponent();
        }
        public SortingProgress(BackgroundWorker background_worker)
        {
            InitializeComponent();
        }
    }
}
