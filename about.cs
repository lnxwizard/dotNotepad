using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dotNotePad
{
    public partial class formAbout : Form
    {
        // About Form
        public formAbout()
        {
            InitializeComponent();
        }

        // About Form Load
        private void formAbout_Load(object sender, EventArgs e)
        {
            lblProductVersion.Text = string.Format("Version: {0}", Application.ProductVersion);
            lblLicense.Text =  "Open Source License: GNU General Public License v3.0";

            DateTime dt = DateTime.Now;
            label5.Text = dt.ToString();
        }

        // Button - OK
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Link Label
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://dotNotepad.github.io/");
        }
    }
}