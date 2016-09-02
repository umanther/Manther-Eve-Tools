using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MantherEveTools
{
    public partial class fPLHelp : Form
    {

        public fPLHelp()
        {
            InitializeComponent();

        }

        private void btHelpButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}