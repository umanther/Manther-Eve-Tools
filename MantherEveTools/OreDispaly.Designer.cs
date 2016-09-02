namespace MantherEveTools
{
    partial class OreDispaly
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
            this.nudAmountValue = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lOreName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmountValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // nudAmountValue
            // 
            this.nudAmountValue.Location = new System.Drawing.Point(73, 47);
            this.nudAmountValue.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudAmountValue.Name = "nudAmountValue";
            this.nudAmountValue.Size = new System.Drawing.Size(104, 20);
            this.nudAmountValue.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lOreName
            // 
            this.lOreName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lOreName.AutoSize = true;
            this.lOreName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lOreName.Location = new System.Drawing.Point(70, 17);
            this.lOreName.Name = "lOreName";
            this.lOreName.Size = new System.Drawing.Size(88, 16);
            this.lOreName.TabIndex = 3;
            this.lOreName.Text = "[Ore Name]";
            // 
            // OreDispaly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lOreName);
            this.Controls.Add(this.nudAmountValue);
            this.Controls.Add(this.pictureBox1);
            this.Name = "OreDispaly";
            this.Size = new System.Drawing.Size(240, 70);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmountValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown nudAmountValue;
        private System.Windows.Forms.Label lOreName;
    }
}
