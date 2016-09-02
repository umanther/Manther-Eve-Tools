namespace MantherEveTools
{
    partial class fAddRefiningItem
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
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.cbOreList = new System.Windows.Forms.ComboBox();
            this.odOreToEdit = new MantherEveTools.OreDispaly();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(42, 115);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 0;
            this.btOk.Text = "&Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(150, 115);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "&Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // cbOreList
            // 
            this.cbOreList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOreList.FormattingEnabled = true;
            this.cbOreList.Location = new System.Drawing.Point(65, 12);
            this.cbOreList.Name = "cbOreList";
            this.cbOreList.Size = new System.Drawing.Size(136, 21);
            this.cbOreList.TabIndex = 3;
            this.cbOreList.SelectedIndexChanged += new System.EventHandler(this.cbOreList_SelectedIndexChanged);
            // 
            // odOreToEdit
            // 
            this.odOreToEdit.Location = new System.Drawing.Point(13, 39);
            this.odOreToEdit.Name = "odOreToEdit";
            this.odOreToEdit.OreAmount = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.odOreToEdit.OreImage = null;
            this.odOreToEdit.OreName = "";
            this.odOreToEdit.Size = new System.Drawing.Size(240, 70);
            this.odOreToEdit.TabIndex = 2;
            // 
            // fAddRefiningItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 143);
            this.ControlBox = false;
            this.Controls.Add(this.cbOreList);
            this.Controls.Add(this.odOreToEdit);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Name = "fAddRefiningItem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Item";
            this.Load += new System.EventHandler(this.fAddRefiningItem_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private OreDispaly odOreToEdit;
        private System.Windows.Forms.ComboBox cbOreList;
    }
}