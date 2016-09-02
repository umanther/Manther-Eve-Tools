using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MantherEveTools
{
    [DefaultProperty("OreName")]
    public partial class OreDispaly : UserControl
    {
        public OreDispaly()
        {
            InitializeComponent();
        }

        /// <summary>Image to display</summary>
        [Category("Ore Settings")]
        [Description("Image displayed")]
        [DefaultValue(false)]
        [DisplayName("Image")]
        public Image OreImage
        {
            get { return this.pictureBox1.Image; }
            set { this.pictureBox1.Image = (Image)value; }
        }

        /// <summary>String used to set the Ore Name that is displayed</summary>
        [Category("Ore Settings")]
        [Description("Name of the ore to display")]
        [DefaultValue(@"[Ore Name]")]
        [DisplayName("Name")]
        public string OreName
        {
            get { return this.lOreName.Text; }
            set { this.lOreName.Text = (string)value; }
        }

        /// <summary>Decimal value of the amount entered</summary>
        [Category("Ore Settings")]
        [Description("Ore amount to be inputed")]
        [DefaultValue(0)]
        [DisplayName("Amount")]
        public decimal OreAmount
        {
            get { return nudAmountValue.Value; }
            set { nudAmountValue.Value = (decimal)value; }
        }
    }
}
