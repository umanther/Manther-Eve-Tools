using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

using METCommon;

namespace MantherEveTools
{
    public partial class fMLHelp : Form
    {
        private int m_MaterialResult = 0;

        public int MaterialResult
        {
            get
            {
                return m_MaterialResult;
            }
        }

        public fMLHelp()
        {
            InitializeComponent();
        }

        private void fMLHelp_Load(object sender, EventArgs e)
        {
            // Verify the registy entry is correct
            if (Convert.ToInt16(Registry.GetValue(GlobalVariables.RegistryPath, "MLSkill", 0)) < 0 ||
                Convert.ToInt16(Registry.GetValue(GlobalVariables.RegistryPath, "MLSkill", 0)) > 5)
                Registry.SetValue(GlobalVariables.RegistryPath, "MLSkill", 0);

            // Set the index of the skill combo box
            cbProductionEfficiencySkill.SelectedIndex = Convert.ToInt16(Registry.GetValue(GlobalVariables.RegistryPath, "MLSkill", 0));
        }

        /// <summary>
        /// Calculate the material value to return based on current inputs
        /// </summary>
        private void UpdateReturn()
        {
            double Update = 0;
            int CurrentAmmount = (int)nudRequiredMaterials.Value;
            int EfficiencySkill = cbProductionEfficiencySkill.SelectedIndex;
            int CurrentML = (int)nudCurrentML.Value;

            Update = (1 - (double)EfficiencySkill * 0.04);  // Calcultate Skill modifier
            Update *= 1 + (0.1 / (1 + (double)CurrentML));  // Calculate ML modifier and multiply in result
            Update = (double)CurrentAmmount / Update;  // Divide material ammount by final modifier

            Update = Math.Round(Update, 0);

            m_MaterialResult = (int)Update;
        }

        private void btHelp_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        private void cbProductionEfficiencySkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateReturn();
        }

        private void nudRequiredMaterials_ValueChanged(object sender, EventArgs e)
        {
            UpdateReturn();
        }

        private void nudCurrentML_ValueChanged(object sender, EventArgs e)
        {
            UpdateReturn();
        }
    }
}