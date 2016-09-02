using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using METCommon;
using MantherEveTools;

namespace MantherEveTools
{
    public partial class fAddRefiningItem : Form
    {
        public fResearchTools.RefiningInput Output;
        fResearchTools.OreType[] OreList;
        int OutputIndex = -1;
        public bool Cancled;
        // ----------------------------------------------------------------------------
        // ---Initilization Section
        public fAddRefiningItem(fResearchTools.OreType[] InputOreList)
        {
            InitializeComponent();

            OreList = InputOreList;

            foreach (fResearchTools.OreType Ore in InputOreList)
            {
                cbOreList.Items.Add(Ore.Name);
            }
        }

        private void fAddRefiningItem_Load(object sender, EventArgs e)
        {
            cbOreList.SelectedIndex = 0;
        }

        // ----------------------------------------------------------------------------
        // ---Data Manipulation Section
        private void cbOreList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Selected = cbOreList.SelectedIndex;
            OutputIndex = Selected;
            odOreToEdit.OreName = OreList[Selected].Name;
            odOreToEdit.OreImage = ResourceAccess.GetIcon("Black64", OreList[Selected].Icon);
        }

        // ----------------------------------------------------------------------------
        // ---Button Clicks
        private void btOk_Click(object sender, EventArgs e)
        {
            this.Close();
            Output.Ore = OreList[OutputIndex];
            Output.AmountToRefine = Convert.ToUInt64(odOreToEdit.OreAmount);
            Cancled = false;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Cancled = true;
        }
    }
}

