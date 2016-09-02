using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using METCommon;

namespace MantherEveTools
{
    public partial class RefiningSkill : UserControl
    {
        private string StoredSkillName;
        private string StoredIconName;

        public RefiningSkill()
        {
            InitializeComponent();
            foreach (string SkillName in Skilllevels)
            {
                cbSkillLevel.Items.Add(SkillName);
            }
        }

        private string[] Skilllevels = { "0", "I", "II", "III", "IV", "V", };

        [Category("Skill Settings")]
        [Description("Name of the skill to display")]
        [DefaultValue(@"[Skill Name]")]
        [DisplayName("Skill Name")]
        public string SkillName
        {
            get { return StoredSkillName; }
            set
            {
                string Suffix;
                StoredSkillName = (string)value;
                switch (value.ToUpper())
                {
                    case "ICE":
                        Suffix = " Harvesting";
                        break;
                    default:
                        Suffix = " Processing";
                        break;
                }

                lSkillName.Text = StoredSkillName + Suffix;
            }
        }

        [Category("Skill Settings")]
        [Description("")]
        [DefaultValue("00_00")]
        [DisplayName("Icon Name")]
        public string SkillIcon
        {
            get { return StoredIconName; }
            set
            {
                StoredIconName = (string)value;
                pbOrePic.Image = ResourceAccess.GetIcon("Black32", StoredIconName);
            }
        }

        [Category("Skill Settings")]
        [Description("")]
        [DefaultValue(0)]
        [DisplayName("Skill Level")]
        public int SkillLevel
        {
            get { return cbSkillLevel.SelectedIndex; }
            set
            {
                if (value < 0) cbSkillLevel.SelectedIndex = 0;
                else
                    if (value > cbSkillLevel.Items.Count - 1) cbSkillLevel.SelectedIndex = cbSkillLevel.Items.Count - 1;
                    else
                        cbSkillLevel.SelectedIndex = value;
            }
        }

        private void RefiningSkill_Load(object sender, EventArgs e)
        {
            cbSkillLevel.SelectedIndex = 0;
        }

        private void cbSkillLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            SkillLevel = cbSkillLevel.SelectedIndex;
        }
    }
}
