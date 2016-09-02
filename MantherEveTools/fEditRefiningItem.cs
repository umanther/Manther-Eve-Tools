using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MantherEveTools;
using METCommon;

namespace MantherEveTools
{
    public partial class fEditRefiningItem : Form
    {
        public fResearchTools.RefiningInput Input;
        // ---------------------------------------------------------------------------
        // ---Initilization Section
        public fEditRefiningItem(fResearchTools.RefiningInput InputOre)
        {
            InitializeComponent();
            Input = InputOre;
        }

        private void fEditRefiningItem_Load(object sender, EventArgs e)
        {
            this.Text = "Edit: " + Input.Ore.Name;
            odOreToEdit.OreImage = ResourceAccess.GetIcon("Black64", Input.Ore.Icon);
            odOreToEdit.OreName = Input.Ore.Name;
            odOreToEdit.OreAmount = Input.AmountToRefine;
        }

        // ---------------------------------------------------------------------------
        // ---Ok and Close button actions
        private void btOk_Click(object sender, EventArgs e)
        {
            this.Close();
            Input.AmountToRefine = Convert.ToUInt64(odOreToEdit.OreAmount);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void odOreToEdit_Load_1(object sender, EventArgs e)
        {

        }
    }
}