using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Counter.Properties;

namespace Counter
{
    public partial class FormSettings : Form
    {
        public bool IsSaved = false;

        public FormSettings()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.IsSaved = false;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.IsSaved = true;
            Settings.Default.Save();
            Close();
        }
    }
}
