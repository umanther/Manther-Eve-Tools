using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

using METCommon;

namespace MantherEveTools
{
    public partial class fResearchTools : Form
    {
        //--------------------------------------------------------------------------------------------
        // ----------------Initialization Section----------------

        // ---Designate all time storage variables
        /// <summary>Stores total tieme in seconds</summary>
        private uint m_TotalSeconds = 0;
        /// <summary>Stores seconds from NUD control</summary>
        private uint m_Seconds = 0;
        /// <summary>Stores minutes from NUD control</summary>
        private uint m_Minutes = 0;
        /// <summary>Stores hours from NUD control</summary>
        private uint m_Hours = 0;
        /// <summary>Stores days from NUD control</summary>
        private uint m_Days = 0;
        /// <summary>Stores weeks from NUD control</summary>
        private uint m_Weeks = 0;

        // ---Define constants
        /// <summary>Maximum PL loops to run  (Max PL to test for)</summary>
        private const int MaxPLLoops = 500000;
        /// <summary>Maximum ML loops to run  (Max ML to test for)</summary>
        private const int MaxMLLoops = 500000;

        // ---Define containers to hold refining data
        /// <summary>ArrayList to store refining inputs</summary>
        public ArrayList RefiningInputs = new ArrayList();
        /// <summary>ArrayList to store refining outputs</summary>
        public ArrayList RefiningOutputs = new ArrayList();
        /// <summary>Array to hold refining skill levels</summary>
        public int[] RefiningSkills = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        /// <summary>Stores the currenty RefinerySkill</summary>
        public int RefinerySkill = 0;

        // ---Refining Variables
        /// <summary>List of station base equipment percents</summary>
        double[] StationPercents = { 0.50, 0.40, 0.35, 0.30, 0.25 };

        /// <summary>Sets the values of the time NumberUpDown controlls on the PL Calculator</summary>
        public void SetPLVariables(int Seconds, int Minutes, int Hours, int Days, int Weeks)
        {
            // ---Function used to set all PL variables at once
            nudSeconds.Value = Seconds;
            nudMinutes.Value = Minutes;
            nudHours.Value = Hours;
            nudDays.Value = Days;
            nudWeeks.Value = Weeks;
        }

        private void ManufactureTools_Load(object sender, EventArgs e)
        {
            
            
            // ---Verify Registry entries are all valid
            if (Convert.ToInt16(Registry.GetValue(GlobalVariables.RegistryPath, "LastFunction", 0)) < 0 ||
                Convert.ToInt16(Registry.GetValue(GlobalVariables.RegistryPath, "LastFunction", 0)) > 3)
                Registry.SetValue(GlobalVariables.RegistryPath, "LastFunction", 0);

            if (Convert.ToInt16(Registry.GetValue(GlobalVariables.RegistryPath, "PLSkill", 0)) < 0 ||
                Convert.ToInt16(Registry.GetValue(GlobalVariables.RegistryPath, "PLSkill", 0)) > 5)
                Registry.SetValue(GlobalVariables.RegistryPath, "PLSkill", 0);

            if (Convert.ToInt16(Registry.GetValue(GlobalVariables.RegistryPath, "MLSkill", 0)) < 0 ||
                Convert.ToInt16(Registry.GetValue(GlobalVariables.RegistryPath, "MLSkill", 0)) > 5)
                Registry.SetValue(GlobalVariables.RegistryPath, "MLSkill", 0);

            if (Convert.ToInt16(Registry.GetValue(GlobalVariables.RegistryPath, "StationPercent", 0)) < 0 ||
                Convert.ToInt16(Registry.GetValue(GlobalVariables.RegistryPath, "StationPercent", 0)) > 4)
                Registry.SetValue(GlobalVariables.RegistryPath, "StationPercent", 0);

            if (Convert.ToInt16(Registry.GetValue(GlobalVariables.RegistryPath, "RefineSkill", 0)) < 0 ||
                Convert.ToInt16(Registry.GetValue(GlobalVariables.RegistryPath, "RefineSkill", 0)) > 10)
                Registry.SetValue(GlobalVariables.RegistryPath, "RefineSkill", 0);

            if (Convert.ToDecimal(Registry.GetValue(GlobalVariables.RegistryPath, "StationStanding", 0)) < -10 ||
                Convert.ToDecimal(Registry.GetValue(GlobalVariables.RegistryPath, "StationStanding", 0)) > 10)
                Registry.SetValue(GlobalVariables.RegistryPath, "StationStanding", 0);

            RefinerySkill = Convert.ToInt32(Registry.GetValue(GlobalVariables.RegistryPath, "RefineSkill", 0));
            nudStatoinStanding.Value = Convert.ToDecimal(Registry.GetValue(GlobalVariables.RegistryPath, "StationStanding", 0));

            fEditRefiningSkills.RefiningSkillsParser(ref RefiningSkills);

            // ---Productivity Level Group Settings
            cbInustrySkill.SelectedIndex = Convert.ToInt16(Registry.GetValue(GlobalVariables.RegistryPath, "PLSkill", 0));
            SetPLVariables(0, 0, 0, 0, 0);

            // ---Material Level Group Settings
            cbProductionEfficiencySkill.SelectedIndex = Convert.ToInt16(Registry.GetValue(GlobalVariables.RegistryPath, "MLSkill", 0));

            // ---Locate the PLGroup over the MLGroup and resize window
            gbPLGroup.Location = gbMLGroup.Location;
            gbOreCalc.Location = gbMLGroup.Location;
            Width = gbMLGroup.Right + gbMLGroup.Left + 5;

            // ---Setup Refining section
            foreach (double Percent in StationPercents)
            {
                cbEquipmentPercent.Items.Add(Percent.ToString("## %"));
            }

            // ---Select Combo Boxes Default Values
            cbFunctionSelect.SelectedIndex = Convert.ToInt16(Registry.GetValue(GlobalVariables.RegistryPath, "LastFunction", 0));
            cbEquipmentPercent.SelectedIndex = Convert.ToInt16(Registry.GetValue(GlobalVariables.RegistryPath, "StationPercent", 0));

            InitializeData();
        }

        //--------------------------------------------------------------------------------------------
        // ----------------Utility Functions----------------

        public fResearchTools()
        {
            InitializeComponent();

            nudWeeks.Maximum = (decimal)MaxTimeConstants.Weeks;
            nudDays.Maximum = (decimal)MaxTimeConstants.Days;
            nudHours.Maximum = (decimal)MaxTimeConstants.Hours;
            nudMinutes.Maximum = (decimal)MaxTimeConstants.Minutes;
            nudSeconds.Maximum = (decimal)MaxTimeConstants.Seconds;
        }

        private void cbFunctionSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ---Used to control Group visibility
            gbMLGroup.Visible = (cbFunctionSelect.SelectedIndex == 0);
            gbPLGroup.Visible = (cbFunctionSelect.SelectedIndex == 1);
            gbOreCalc.Visible = (cbFunctionSelect.SelectedIndex == 2);

            // ---Store the value in the registry
            Registry.SetValue(GlobalVariables.RegistryPath, "LastFunction", cbFunctionSelect.SelectedIndex);
        }

        /// <summary>Takes store time variables and calculate total time (in seconds)</summary>
        private void CalcSeconds()
        {
            // ---Use all time variables to calculate TotalSeconds
            m_TotalSeconds = 0;
            m_TotalSeconds += m_Seconds;
            m_TotalSeconds += m_Minutes * 60;
            m_TotalSeconds += m_Hours * 3600;
            m_TotalSeconds += m_Days * 86400;
            m_TotalSeconds += m_Weeks * 604800;
        }

        private void btPLHelp_Click(object sender, EventArgs e)
        {
            using (fPLHelp HelpMenu = new fPLHelp())
            {
                HelpMenu.ShowDialog();
            }
        }

        private void btMLHelp_Click(object sender, EventArgs e)
        {
            using (fMLHelp HelpForm = new fMLHelp())
            {
                HelpForm.ShowDialog();
                if (HelpForm.DialogResult != DialogResult.Cancel)
                    nudMaterialRequirement.Value = HelpForm.MaterialResult;
            }
        }

        //--------------------------------------------------------------------------------------------
        // ----------------Local ML, PL and Refining Calculation Functions----------------

        /// <summary>Used to calculate Production Level from avalable in-form info</summary>
        private void CalculatePL()
        {
            lvPLResults.Items.Clear();  //Clear PL Results list
            // -Define local variables
            double PL = 0;
            double CurrentTime = 0, LastTime = 0;
            double RawNumber = 0;
            double BaseTime = m_TotalSeconds;
            double IndustrySkill = cbInustrySkill.SelectedIndex;

            // ---Calculate first PL  (PL = 0)
            RawNumber = (1 - (PL / (PL + 1) * 0.2));  //PL Effect
            RawNumber *= (1 - (IndustrySkill * 0.04));  //Industry Skill Effect
            RawNumber *= BaseTime;  //Base Time in Seconds

            lvPLResults.BeginUpdate();  // State that we're begining an update

            LastTime = Math.Truncate(RawNumber);  //Store PL 0 as LastTime
            ListViewItem lvItem = new ListViewItem(PL.ToString("#,##0"));  // Create a new ListViewItem, add PL
            lvItem.SubItems.Add(TimeFormats.SecondsToTime((uint)LastTime).ToString());  // Add sub item Time
            lvPLResults.Items.Add(lvItem);  // Add ListVeiwItem to PL Results

            // ---PL Caluclation Loop for MaxPLLoops
            for (PL = 1; PL < MaxPLLoops; PL++)
            {
                RawNumber = (1 - (PL / (PL + 1) * 0.2));  //PL Effect
                RawNumber *= (1 - (IndustrySkill * 0.04));  //Industry Skill Effect
                RawNumber *= BaseTime;  //Base Time in Seconds

                CurrentTime = Math.Truncate(RawNumber);  //Store current PL as CurrentTime
                if (CurrentTime < LastTime)
                {
                    // ---If CurrentTime is less than LastTime, Store results in PL Results and update LastTime
                    lvItem = new ListViewItem(PL.ToString("#,##0"));  // Create a new ListViewItem, add PL
                    lvItem.SubItems.Add(TimeFormats.SecondsToTime((uint)CurrentTime).ToString());  // Add sub item Time
                    lvPLResults.Items.Add(lvItem);  // Add ListVeiwItem to PL Results

                    LastTime = CurrentTime;
                }
            } // ---End PL Calculation Loop

            chPLValue.Width = 55;  // Resize PL column header Width

            // ---Check what column width to set (Content or Minimum Header Width: 35)
            chPLTime.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            int ColumnContentWidth = chPLTime.Width;
            int HeaderSize = 40;
            if (ColumnContentWidth > HeaderSize)
                chPLTime.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            else
                chPLTime.Width = HeaderSize;

            lvPLResults.EndUpdate();  // Update over, unlock the control
        }

        /// <summary>Used to calculate Material Level from avalable in-form info</summary>
        private void CalculateML()
        {
            lvMLResults.Items.Clear();  //Clear ML Results list
            // -Define local variables
            double ML = 0;
            double CurrentAmmount = 0, LastAmmount = 0;
            double RawNumber = 0;
            double BaseAmmount = (double)nudMaterialRequirement.Value;
            double PESkill = cbProductionEfficiencySkill.SelectedIndex;

            // ---Calculate first ML level (ML = 0)
            RawNumber = 1 + (0.1 / (1 + ML));  //ML Effect
            RawNumber *= 1 - (PESkill * 0.04);  //Skill Effect
            RawNumber *= BaseAmmount;  //Base Ammount

            LastAmmount = Math.Round(RawNumber, 0);  // Store ML 0 as LastAmmount

            this.lvMLResults.BeginUpdate();  // StatE that we're begining an update

            ListViewItem lvItem = new ListViewItem(ML.ToString()); // Build a new ListViewItem, add ML
            lvItem.SubItems.Add(LastAmmount.ToString("#,##0"));  // Add Ammount to new ListViewItem
            lvMLResults.Items.Add(lvItem);  // Add new ListViewItem to the List View

            // ---ML Calculation Loop for MaxMLLoops
            for (ML = 1; ML < MaxMLLoops; ML++)
            {
                RawNumber = 1 + (0.1 / (1 + ML));  //ML Effect
                RawNumber *= 1 - (PESkill * 0.04);  //Skill Effect
                RawNumber *= BaseAmmount;  //Base Ammount

                CurrentAmmount = Math.Round(RawNumber, 0);  //Store current ML as CurrentAmmount
                if (CurrentAmmount < LastAmmount)
                {
                    // ---If CurrentAmmount is less than LastAmmount, Store results in ML Results and update LastAmmount
                    lvItem = new ListViewItem(ML.ToString("#,##0")); // Build a new ListViewItem, add ML
                    lvItem.SubItems.Add(CurrentAmmount.ToString("#,##0"));  // Add Ammount to new ListViewItem
                    lvMLResults.Items.Add(lvItem);  // Add new ListViewItem to the List View

                    LastAmmount = CurrentAmmount;
                }

            } // ---End ML Calculation Loop

            chMLValue.Width = 55;  // Resize ML column

            // ---Check what column width to set (Content or Minimum Header Width: 56)
            chMLMaterial.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            int ColumnContentWidth = chMLMaterial.Width;
            int HeaderSize = 60;
            if (ColumnContentWidth > HeaderSize)
                chMLMaterial.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            else
                chMLMaterial.Width = HeaderSize;

            lvMLResults.EndUpdate();  // Updated complete, unlock the control
        }

        private void Refine()
        {
            if (cbEquipmentPercent.SelectedIndex >= 0)
            {
                // ---Collect all the different types of information
                Single StationPercent = (Single)StationPercents[cbEquipmentPercent.SelectedIndex];
                RefiningOutput NewOutput = new RefiningOutput();

                // ---Clear the refining output list
                RefiningOutputs.Clear();

                // ---Holding Variables
                RefiningInput InputOre;

                // ---Parse and process the Ore List one entry at a time
                for (int LoopIndex = 0; LoopIndex < RefiningInputs.Count; LoopIndex++)
                {
                    //Copy the current Ore to a temporary holder
                    InputOre = (RefiningInput)RefiningInputs[LoopIndex];

                    // ---Loop for each output of the Input Ore and process the output
                    foreach (ProductType CurrentOutput in InputOre.Ore.Outputs)
                    {
                        NewOutput.Product = CurrentOutput;
                        int NumberOfBatches = (int)InputOre.AmountToRefine / (int)InputOre.Ore.UnitsToRefine;
                        double PercentToUse = 0;

                        // Calculate Base %
                        int UsedSkillRefining = 0;
                        int UsedSkillRefineryEfficiency = 0;
                        switch(RefinerySkill)
                        {
                            case 1: UsedSkillRefining = 1; break;
                            case 2: UsedSkillRefining = 2; break;
                            case 3: UsedSkillRefining = 3; break;
                            case 4: UsedSkillRefining = 4; break;
                            case 5: UsedSkillRefining = 5; break;
                            case 6: UsedSkillRefining = 5; UsedSkillRefineryEfficiency = 1; break;
                            case 7: UsedSkillRefining = 5; UsedSkillRefineryEfficiency = 2; break;
                            case 8: UsedSkillRefining = 5; UsedSkillRefineryEfficiency = 3; break;
                            case 9: UsedSkillRefining = 5; UsedSkillRefineryEfficiency = 4; break;
                            case 10: UsedSkillRefining = 5; UsedSkillRefineryEfficiency = 5; break;
                        }

                        // Add Station Percent to base bonus
                        PercentToUse = StationPercent + 0.375;
                        // Add in refining skills
                        PercentToUse += 0.375 * (UsedSkillRefining * 0.02 + UsedSkillRefineryEfficiency * 0.044);
                        // Add in ore specific skills
                        PercentToUse += (0.12375 / 5) * RefiningSkills[(int)InputOre.Ore.Root];
                        // Can't have a percent greater than 100%
                        if (PercentToUse > 1) PercentToUse = 1;

                        // ---Calculate the base cut %
                        double BaseCutPercent = -7.5 * ((double)nudStatoinStanding.Value / 10) + 5;
                        // Can't make more ore (set the base cut to 0)
                        if (BaseCutPercent < 0) BaseCutPercent = 0;
                        // Convert the result into a usable decimal %
                        BaseCutPercent /= 100;

                        // ---Use collected data to calculate the results
                        // Total Ore
                        NewOutput.Total = Convert.ToUInt64(Math.Round((double)NumberOfBatches * CurrentOutput.BaseOutput));
                        // Waste Ore
                        NewOutput.Waste = Convert.ToUInt64(Math.Round(NewOutput.Total * (1 - PercentToUse)));
                        // Base Cut
                        NewOutput.BaseCut = Convert.ToUInt64(Math.Round(NewOutput.Total * PercentToUse * BaseCutPercent));
                        // Final Output
                        NewOutput.Output = NewOutput.Total - NewOutput.Waste - NewOutput.BaseCut;

                        // ---Search the exiting output list to see if our addition already exists
                        int TargetIndex = -1;
                        foreach (RefiningOutput Existing in RefiningOutputs)
                        {
                            if (NewOutput.Product.Name == Existing.Product.Name)
                                TargetIndex = RefiningOutputs.IndexOf(Existing);
                        }

                        if (TargetIndex < 0)
                        {
                            RefiningOutputs.Add(NewOutput);
                        }
                        else
                        {
                            RefiningOutput TempHolder = (RefiningOutput)RefiningOutputs[TargetIndex];
                            // Transfer over existing amounts
                            NewOutput.Total += TempHolder.Total;
                            NewOutput.Waste += TempHolder.Waste;
                            NewOutput.BaseCut += TempHolder.BaseCut;
                            NewOutput.Output += TempHolder.Output;
                            // Store the result over the old one
                            RefiningOutputs[TargetIndex] = NewOutput;
                        }
                    }
                }

                UpdateRefiningOutput();
            }
        }

        //--------------------------------------------------------------------------------------------
        // ----------------Time Numeric Up/Down Change Functions----------------

        private void nudWeeks_ValueChanged(object sender, EventArgs e)
        {
            m_Weeks = (uint)nudWeeks.Value;
            CalcSeconds();
        }

        private void nudDays_ValueChanged(object sender, EventArgs e)
        {
            m_Days = (uint)nudDays.Value;
            CalcSeconds();
        }

        private void nudHours_ValueChanged(object sender, EventArgs e)
        {
            m_Hours = (uint)nudHours.Value;
            CalcSeconds();
        }

        private void nudMinutes_ValueChanged(object sender, EventArgs e)
        {
            m_Minutes = (uint)nudMinutes.Value;
            CalcSeconds();
        }

        private void nudSeconds_ValueChanged(object sender, EventArgs e)
        {
            m_Seconds = (uint)nudSeconds.Value;
            CalcSeconds();
        }
        //--------------------------------------------------------------------------------------------
        // ---------------- Refining Functions ----------------
        internal void UpdateRefiningInput()
        {
            lvInputOre.Items.Clear();
            foreach (RefiningInput Input in RefiningInputs)
            {
                lvInputOre.Items.Add(new ListViewItem(new string[] { "", Input.Ore.Name, Input.AmountToRefine.ToString("#,##0") }, Input.Ore.Name));
            }

            Refine();
        }

        internal void UpdateRefiningOutput()
        {
            lvOutputProduct.Items.Clear();
            foreach (RefiningOutput Output in RefiningOutputs)
            {
                lvOutputProduct.Items.Add(new ListViewItem(new string[] { "", Output.Product.Name,
                    Output.Output.ToString("#,##0"),Output.BaseCut.ToString("#,##0"),Output.Waste.ToString("#,##0")}
                    , Output.Product.Name));
            }

            for (int LoopIndex = 0; LoopIndex < lvOutputProduct.Columns.Count; LoopIndex++)
            {
                int ContentWidth;
                lvOutputProduct.Columns[LoopIndex].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                ContentWidth = lvOutputProduct.Columns[LoopIndex].Width;
                lvOutputProduct.Columns[LoopIndex].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                if (lvOutputProduct.Columns[LoopIndex].Width < ContentWidth)
                {
                    lvOutputProduct.Columns[LoopIndex].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }

        }

        private void cbEquipmentPercent_SelectedIndexChanged(object sender, EventArgs e)
        {
            Registry.SetValue(GlobalVariables.RegistryPath, "StationPercent", cbEquipmentPercent.SelectedIndex);
            Refine();
        }

        private void nudStatoinStanding_ValueChanged(object sender, EventArgs e)
        {
            Registry.SetValue(GlobalVariables.RegistryPath, "StationStanding", nudStatoinStanding.Value);
            Refine();
        }

        //--------------------------------------------------------------------------------------------
        // ---------------- Button Clicks to activate Calculators----------------

        private void btPLAnalyze_Click(object sender, EventArgs e)
        {
            btPLAnalyze.Enabled = false;
            CalculatePL();
            btPLAnalyze.Enabled = true;
        }

        private void btMLAnalyze_Click(object sender, EventArgs e)
        {
            btMLAnalyze.Enabled = false;
            CalculateML();
            btMLAnalyze.Enabled = true;
        }

        private void btMaster_Click(object sender, EventArgs e)
        {
            if (gbMLGroup.Visible) { btMLAnalyze_Click(sender, e); }
            if (gbPLGroup.Visible) { btPLAnalyze_Click(sender, e); }
        }

        //--------------------------------------------------------------------------------------------
        // ---------------- Other events that activate Calculators----------------

        private void cbProductionEfficiencySkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Run the click function to calculate ML
            btMLAnalyze_Click(sender, e);

            // Set Registry Entry
            Registry.SetValue(GlobalVariables.RegistryPath, "MLSkill", cbProductionEfficiencySkill.SelectedIndex);
        }

        private void cbInustrySkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Run the click function to calculate PL
            btPLAnalyze_Click(sender, e);

            // Set Registry Entry
            Registry.SetValue(GlobalVariables.RegistryPath, "PLSkill", cbInustrySkill.SelectedIndex);

        }
        //--------------------------------------------------------------------------------------------
        // ---------------- Button Clicks to activate Refining functions----------------

        private void btRefiningAddItem_Click(object sender, EventArgs e)
        {
            RefiningInput OreToAdd;
            using(fAddRefiningItem Form = new fAddRefiningItem(OreTypes))
            {
                Form.ShowDialog();
                if (!Form.Cancled)
                {
                    OreToAdd = Form.Output;
                    RefiningInputs.Add(OreToAdd);
                    UpdateRefiningInput();
                    Refine();
                }
            }
        }

        private void btEditRefiningItem_Click(object sender, EventArgs e)
        {
            if (lvInputOre.SelectedItems.Count != 0)
            {
                RefiningInput OreToSend;
                int Selected = lvInputOre.SelectedItems[0].Index;
                OreToSend = (RefiningInput)RefiningInputs[Selected];
                using (fEditRefiningItem Form = new fEditRefiningItem(OreToSend))
                {
                    Form.ShowDialog();
                    RefiningInputs[Selected] = Form.Input;
                }
                UpdateRefiningInput();
                Refine();
            }
        }

        private void btRefiningRemove_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection Selected = lvInputOre.SelectedIndices;
            if (Selected.Count != 0)
            {
                RefiningInputs.RemoveAt(Selected[0]);
                UpdateRefiningInput();
            }
        }

        private void btRefiningClearInputList_Click(object sender, EventArgs e)
        {
            RefiningInputs.Clear();
            UpdateRefiningInput();
        }

        private void btEditRefiningSkills_Click(object sender, EventArgs e)
        {
            using (fEditRefiningSkills Form = new fEditRefiningSkills(ref RefiningSkills))
            {
                Form.ShowDialog();
                if (!Form.Cancled) RefinerySkill = Convert.ToInt32(Registry.GetValue(GlobalVariables.RegistryPath, "RefineSkill", 0));
            }
            int[] temp = RefiningSkills;
            Refine();
        }

        //--------------------------------------------------------------------------------------------
        // ---------------- Menu Functions ----------------

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmsiAbout_Click(object sender, EventArgs e)
        {
            Form About = new fResearchToolsAbout();
            About.ShowDialog();
        }
    }
}