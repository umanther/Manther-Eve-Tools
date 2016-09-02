namespace MantherEveTools
{
    partial class fPLHelp
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
            this.lEnterManufacturingTime = new System.Windows.Forms.Label();
            this.btHelpButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pbManufacturingTime = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbManufacturingTime)).BeginInit();
            this.SuspendLayout();
            // 
            // lEnterManufacturingTime
            // 
            this.lEnterManufacturingTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEnterManufacturingTime.Location = new System.Drawing.Point(12, 9);
            this.lEnterManufacturingTime.Name = "lEnterManufacturingTime";
            this.lEnterManufacturingTime.Size = new System.Drawing.Size(156, 13);
            this.lEnterManufacturingTime.TabIndex = 11;
            this.lEnterManufacturingTime.Text = "Enter Manufacturing Time";
            this.lEnterManufacturingTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btHelpButton
            // 
            this.btHelpButton.Location = new System.Drawing.Point(56, 74);
            this.btHelpButton.Name = "btHelpButton";
            this.btHelpButton.Size = new System.Drawing.Size(75, 23);
            this.btHelpButton.TabIndex = 21;
            this.btHelpButton.Text = "&Ok";
            this.btHelpButton.UseVisualStyleBackColor = true;
            this.btHelpButton.Click += new System.EventHandler(this.btHelpButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // pbManufacturingTime
            // 
            this.pbManufacturingTime.Image = global::MantherEveTools.HelpImages.ManufacturingTime;
            this.pbManufacturingTime.Location = new System.Drawing.Point(15, 25);
            this.pbManufacturingTime.Name = "pbManufacturingTime";
            this.pbManufacturingTime.Size = new System.Drawing.Size(156, 40);
            this.pbManufacturingTime.TabIndex = 26;
            this.pbManufacturingTime.TabStop = false;
            // 
            // fPLHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(187, 106);
            this.ControlBox = false;
            this.Controls.Add(this.pbManufacturingTime);
            this.Controls.Add(this.btHelpButton);
            this.Controls.Add(this.lEnterManufacturingTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "fPLHelp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Production Level Help";
            ((System.ComponentModel.ISupportInitialize)(this.pbManufacturingTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lEnterManufacturingTime;
        private System.Windows.Forms.Button btHelpButton;
        private System.Windows.Forms.PictureBox pbManufacturingTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}