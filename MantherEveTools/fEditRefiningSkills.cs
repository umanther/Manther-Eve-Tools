using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

using METCommon;
using OreTypes = MantherEveTools.fResearchTools.OreTypesRoot;

namespace MantherEveTools
{
    public partial class fEditRefiningSkills : Form
    {
        public bool Cancled;

        string[,] RefinerySkillValues = { {"Refining: 0",    "00"},
                                          {"Refining: 1",    "10"},
                                          {"Refining: 2",    "20"},
                                          {"Refining: 3",    "30"},
                                          {"Refining: 4",    "40"},
                                          {"Refining: 5",    "50"},
                                          {"Refinery Eff: 1","51"},
                                          {"Refinery Eff: 2","52"},
                                          {"Refinery Eff: 3","53"},
                                          {"Refinery Eff: 4","54"},
                                          {"Refinery Eff: 5","55"}};

        int RefiningSkill;
        public int[] RefiningSkills;

        // ----------------------------------------------------------------------
        // ---Initialization Section

        public fEditRefiningSkills(ref int[] InputSkillsArray)
        {
            InitializeComponent();

            // ---Refinery Skills Group Settings
            for (int x = 0; x < RefinerySkillValues.GetLength(0); x++)
            {
                cbRefiningSkill.Items.Add(RefinerySkillValues[x, 0]);
            }

            RefiningSkills = InputSkillsArray;
        }

        private void fEditRefiningSkills_Load(object sender, EventArgs e)
        {
            cbRefiningSkill.SelectedIndex = Convert.ToInt16(Registry.GetValue(GlobalVariables.RegistryPath, "RefineSkill", 0));

            if (Convert.ToInt32(Registry.GetValue(GlobalVariables.RegistryPath, "RefineSkill", 0)) < 0 ||
                Convert.ToInt32(Registry.GetValue(GlobalVariables.RegistryPath, "RefineSkill", 0)) > 10)
                Registry.SetValue(GlobalVariables.RegistryPath, "RefineSkill", 0);

            cbRefiningSkill.SelectedIndex = Convert.ToInt32(Registry.GetValue(GlobalVariables.RegistryPath, "RefineSkill", 0));
            RefiningSkill = (int)cbRefiningSkill.SelectedIndex;

            RefiningSkillsParser(ref RefiningSkills);
            SetSkillsComboBoxes();
        }

        // ----------------------------------------------------------------------
        // ---Combo box parsers
        static public void RefiningSkillsParser(ref int[] InputRefiningSkills)
        {
            long StoredSkills = Convert.ToInt64(Registry.GetValue(GlobalVariables.RegistryPath, "RefiningSkills", 0));
            byte Flag = 7;
            long filter = 0;

            for (int LoopIndex = 0; LoopIndex < InputRefiningSkills.GetLength(0); LoopIndex++)
            {
                filter = Flag * (long)Math.Pow(2, LoopIndex * 3);
                InputRefiningSkills[LoopIndex] = (int)((StoredSkills & filter) / (long)Math.Pow(2, LoopIndex * 3));
                if (InputRefiningSkills[LoopIndex] > 5) InputRefiningSkills[LoopIndex] = 5;
            }
        }

        void SetSkillsComboBoxes()
        {
            rsVeldspar.SkillLevel = RefiningSkills[(int)OreTypes.Veldspar];
            rsScordite.SkillLevel = RefiningSkills[(int)OreTypes.Scordite];
            rsPyroxeres.SkillLevel = RefiningSkills[(int)OreTypes.Pyroxeres];
            rsPlagioclase.SkillLevel = RefiningSkills[(int)OreTypes.Plagioclase];
            rsOmber.SkillLevel = RefiningSkills[(int)OreTypes.Omber];
            rsKernite.SkillLevel = RefiningSkills[(int)OreTypes.Kernite];
            rsJaspet.SkillLevel = RefiningSkills[(int)OreTypes.Jaspet];
            rsHedbergite.SkillLevel = RefiningSkills[(int)OreTypes.Hedbergite];
            rsHemorphite.SkillLevel = RefiningSkills[(int)OreTypes.Hemorphite];
            rsGneiss.SkillLevel = RefiningSkills[(int)OreTypes.Gneiss];
            rsDarkOchre.SkillLevel = RefiningSkills[(int)OreTypes.DarkOchre];
            rsCrokite.SkillLevel = RefiningSkills[(int)OreTypes.Crokite];
            rsSpudomain.SkillLevel = RefiningSkills[(int)OreTypes.Spudomain];
            rsArkonor.SkillLevel = RefiningSkills[(int)OreTypes.Arkonor];
            rsBistot.SkillLevel = RefiningSkills[(int)OreTypes.Bistot];
            rsMercoxit.SkillLevel = RefiningSkills[(int)OreTypes.Mercoxit];
            rsIce.SkillLevel = RefiningSkills[(int)OreTypes.IceOre];
        }

        void GetSkillsComboBoxes()
        {
            RefiningSkills[(int)OreTypes.Veldspar] = rsVeldspar.SkillLevel;
            RefiningSkills[(int)OreTypes.Scordite] = rsScordite.SkillLevel;
            RefiningSkills[(int)OreTypes.Pyroxeres] = rsPyroxeres.SkillLevel;
            RefiningSkills[(int)OreTypes.Plagioclase] = rsPlagioclase.SkillLevel;
            RefiningSkills[(int)OreTypes.Omber] = rsOmber.SkillLevel;
            RefiningSkills[(int)OreTypes.Kernite] = rsKernite.SkillLevel;
            RefiningSkills[(int)OreTypes.Jaspet] = rsJaspet.SkillLevel;
            RefiningSkills[(int)OreTypes.Hedbergite] = rsHedbergite.SkillLevel;
            RefiningSkills[(int)OreTypes.Hemorphite] = rsHemorphite.SkillLevel;
            RefiningSkills[(int)OreTypes.Gneiss] = rsGneiss.SkillLevel;
            RefiningSkills[(int)OreTypes.DarkOchre] = rsDarkOchre.SkillLevel;
            RefiningSkills[(int)OreTypes.Crokite] = rsCrokite.SkillLevel;
            RefiningSkills[(int)OreTypes.Spudomain] = rsSpudomain.SkillLevel;
            RefiningSkills[(int)OreTypes.Arkonor] = rsArkonor.SkillLevel;
            RefiningSkills[(int)OreTypes.Bistot] = rsBistot.SkillLevel;
            RefiningSkills[(int)OreTypes.Mercoxit] = rsMercoxit.SkillLevel;
            RefiningSkills[(int)OreTypes.IceOre] = rsIce.SkillLevel;

            long ValueToSave = 0;
            for (int LoopIndex = 0; LoopIndex < RefiningSkills.GetLength(0); LoopIndex++)
            {
                ValueToSave += RefiningSkills[LoopIndex] * (long)Math.Pow(2, LoopIndex * 3);
            }
            Registry.SetValue(GlobalVariables.RegistryPath, "RefiningSkills", ValueToSave);

            RefiningSkill = (int)cbRefiningSkill.SelectedIndex;
            Registry.SetValue(GlobalVariables.RegistryPath, "RefineSkill", cbRefiningSkill.SelectedIndex);
        }

        // ----------------------------------------------------------------------
        // ---Button Click Section
        private void btOk_Click(object sender, EventArgs e)
        {
            this.Close();
            GetSkillsComboBoxes();
            Cancled = false;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Cancled = true;
        }
    }
}