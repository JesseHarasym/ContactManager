namespace AddressBookProject
{
    partial class ContactBasic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactBasic));
            this.lblContactName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.picBoxContact = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxContact)).BeginInit();
            this.SuspendLayout();
            // 
            // lblContactName
            // 
            this.lblContactName.AutoSize = true;
            this.lblContactName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactName.Location = new System.Drawing.Point(91, 23);
            this.lblContactName.Name = "lblContactName";
            this.lblContactName.Size = new System.Drawing.Size(97, 25);
            this.lblContactName.TabIndex = 5;
            this.lblContactName.Text = "Full Name";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(85, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 25);
            this.lblName.TabIndex = 4;
            // 
            // picBoxContact
            // 
            this.picBoxContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxContact.ErrorImage = ((System.Drawing.Image)(resources.GetObject("picBoxContact.ErrorImage")));
            this.picBoxContact.Image = global::AddressBookProject.Properties.Resources.defaultProfile;
            this.picBoxContact.InitialImage = ((System.Drawing.Image)(resources.GetObject("picBoxContact.InitialImage")));
            this.picBoxContact.Location = new System.Drawing.Point(7, 5);
            this.picBoxContact.Name = "picBoxContact";
            this.picBoxContact.Size = new System.Drawing.Size(60, 57);
            this.picBoxContact.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxContact.TabIndex = 3;
            this.picBoxContact.TabStop = false;
            // 
            // ContactBasic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblContactName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picBoxContact);
            this.Name = "ContactBasic";
            this.Size = new System.Drawing.Size(338, 68);
            this.Click += new System.EventHandler(this.ContactBasic_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxContact)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox picBoxContact;
        private System.Windows.Forms.Label lblContactName;
    }
}
