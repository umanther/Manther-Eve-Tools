namespace MantherEveTools
{
    partial class fMLHelp
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btHelp = new System.Windows.Forms.Button();
            this.cbProductionEfficiencySkill = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nudRequiredMaterials = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudCurrentML = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btCancle = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRequiredMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCurrentML)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btHelp
            // 
            this.btHelp.Location = new System.Drawing.Point(182, 131);
            this.btHelp.Name = "btHelp";
            this.btHelp.Size = new System.Drawing.Size(75, 23);
            this.btHelp.TabIndex = 0;
            this.btHelp.Text = "&Ok";
            this.btHelp.UseVisualStyleBackColor = true;
            this.btHelp.Click += new System.EventHandler(this.btHelp_Click);
            // 
            // cbProductionEfficiencySkill
            // 
            this.cbProductionEfficiencySkill.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbProductionEfficiencySkill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProductionEfficiencySkill.FormattingEnabled = true;
            this.cbProductionEfficiencySkill.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cbProductionEfficiencySkill.Location = new System.Drawing.Point(167, 3);
            this.cbProductionEfficiencySkill.Name = "cbProductionEfficiencySkill";
            this.cbProductionEfficiencySkill.Size = new System.Drawing.Size(41, 21);
            this.cbProductionEfficiencySkill.TabIndex = 1;
            this.cbProductionEfficiencySkill.SelectedIndexChanged += new System.EventHandler(this.cbProductionEfficiencySkill_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Production Efficiency Skill Level";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nudRequiredMaterials, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbProductionEfficiencySkill, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.nudCurrentML, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(503, 108);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // nudRequiredMaterials
            // 
            this.nudRequiredMaterials.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudRequiredMaterials.Location = new System.Drawing.Point(167, 37);
            this.nudRequiredMaterials.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudRequiredMaterials.Name = "nudRequiredMaterials";
            this.nudRequiredMaterials.Size = new System.Drawing.Size(75, 20);
            this.nudRequiredMaterials.TabIndex = 3;
            this.nudRequiredMaterials.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRequiredMaterials.ThousandsSeparator = true;
            this.nudRequiredMaterials.ValueChanged += new System.EventHandler(this.nudRequiredMaterials_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 41);
            this.label2.TabIndex = 4;
            this.label2.Text = "Required Materials";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 40);
            this.label3.TabIndex = 6;
            this.label3.Text = "Current Blueprint ML Level";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudCurrentML
            // 
            this.nudCurrentML.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudCurrentML.Location = new System.Drawing.Point(167, 78);
            this.nudCurrentML.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudCurrentML.Name = "nudCurrentML";
            this.nudCurrentML.Size = new System.Drawing.Size(75, 20);
            this.nudCurrentML.TabIndex = 7;
            this.nudCurrentML.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCurrentML.ThousandsSeparator = true;
            this.nudCurrentML.ValueChanged += new System.EventHandler(this.nudCurrentML_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox1.Image = global::MantherEveTools.HelpImages.MaterialsExample;
            this.pictureBox1.Location = new System.Drawing.Point(248, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(252, 35);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox2.Image = global::MantherEveTools.HelpImages.MaterialLevel;
            this.pictureBox2.Location = new System.Drawing.Point(248, 71);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(182, 33);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(248, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(252, 27);
            this.label4.TabIndex = 9;
            this.label4.Text = "Example Blueprint Info";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btCancle
            // 
            this.btCancle.Location = new System.Drawing.Point(263, 131);
            this.btCancle.Name = "btCancle";
            this.btCancle.Size = new System.Drawing.Size(75, 23);
            this.btCancle.TabIndex = 4;
            this.btCancle.Text = "&Cancel";
            this.btCancle.UseVisualStyleBackColor = true;
            this.btCancle.Click += new System.EventHandler(this.btCancle_Click);
            // 
            // fMLHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 160);
            this.ControlBox = false;
            this.Controls.Add(this.btCancle);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btHelp);
            this.Name = "fMLHelp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Material Level Help";
            this.Load += new System.EventHandler(this.fMLHelp_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRequiredMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCurrentML)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btHelp;
        private System.Windows.Forms.ComboBox cbProductionEfficiencySkill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown nudRequiredMaterials;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudCurrentML;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btCancle;
    }
}