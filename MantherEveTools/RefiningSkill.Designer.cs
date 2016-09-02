namespace MantherEveTools
{
    partial class RefiningSkill
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lSkillName = new System.Windows.Forms.Label();
            this.cbSkillLevel = new System.Windows.Forms.ComboBox();
            this.lDashedLine = new System.Windows.Forms.Label();
            this.pbOrePic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrePic)).BeginInit();
            this.SuspendLayout();
            // 
            // lSkillName
            // 
            this.lSkillName.AutoSize = true;
            this.lSkillName.Location = new System.Drawing.Point(29, 6);
            this.lSkillName.Name = "lSkillName";
            this.lSkillName.Size = new System.Drawing.Size(63, 13);
            this.lSkillName.TabIndex = 1;
            this.lSkillName.Text = "[Skill Name]";
            // 
            // cbSkillLevel
            // 
            this.cbSkillLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSkillLevel.FormattingEnabled = true;
            this.cbSkillLevel.Location = new System.Drawing.Point(153, 3);
            this.cbSkillLevel.Name = "cbSkillLevel";
            this.cbSkillLevel.Size = new System.Drawing.Size(45, 21);
            this.cbSkillLevel.TabIndex = 2;
            this.cbSkillLevel.SelectedIndexChanged += new System.EventHandler(this.cbSkillLevel_SelectedIndexChanged);
            // 
            // lDashedLine
            // 
            this.lDashedLine.AutoSize = true;
            this.lDashedLine.Location = new System.Drawing.Point(29, 6);
            this.lDashedLine.Name = "lDashedLine";
            this.lDashedLine.Size = new System.Drawing.Size(133, 13);
            this.lDashedLine.TabIndex = 3;
            this.lDashedLine.Text = "------------------------------------------";
            // 
            // pbOrePic
            // 
            this.pbOrePic.Location = new System.Drawing.Point(0, 0);
            this.pbOrePic.Name = "pbOrePic";
            this.pbOrePic.Size = new System.Drawing.Size(27, 27);
            this.pbOrePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOrePic.TabIndex = 4;
            this.pbOrePic.TabStop = false;
            // 
            // RefiningSkill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbOrePic);
            this.Controls.Add(this.cbSkillLevel);
            this.Controls.Add(this.lSkillName);
            this.Controls.Add(this.lDashedLine);
            this.Name = "RefiningSkill";
            this.Size = new System.Drawing.Size(202, 27);
            this.Load += new System.EventHandler(this.RefiningSkill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbOrePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lSkillName;
        private System.Windows.Forms.ComboBox cbSkillLevel;
        private System.Windows.Forms.Label lDashedLine;
        private System.Windows.Forms.PictureBox pbOrePic;
    }
}
