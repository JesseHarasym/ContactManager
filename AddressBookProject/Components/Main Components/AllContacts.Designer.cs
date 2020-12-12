namespace AddressBookProject
{
    partial class AllContacts
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
            this.components = new System.ComponentModel.Container();
            this.timerCheckForChanges = new System.Windows.Forms.Timer(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnGroups = new System.Windows.Forms.Button();
            this.pnlAllContacts = new System.Windows.Forms.Panel();
            this.pnlFullContact = new System.Windows.Forms.Panel();
            this.fullContactInfo1 = new AddressBookProject.FullContactInfo();
            this.pnlAllContacts.SuspendLayout();
            this.pnlFullContact.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerCheckForChanges
            // 
            this.timerCheckForChanges.Interval = 1;
            this.timerCheckForChanges.Tick += new System.EventHandler(this.timerCheckForChanges_Tick);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdd.Location = new System.Drawing.Point(2, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 32);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(2, 35);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(338, 23);
            this.txtSearch.TabIndex = 12;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnGroups
            // 
            this.btnGroups.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGroups.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnGroups.FlatAppearance.BorderSize = 0;
            this.btnGroups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGroups.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroups.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGroups.Location = new System.Drawing.Point(236, 3);
            this.btnGroups.Name = "btnGroups";
            this.btnGroups.Size = new System.Drawing.Size(104, 32);
            this.btnGroups.TabIndex = 14;
            this.btnGroups.Text = "Open Groups";
            this.btnGroups.UseVisualStyleBackColor = false;
            this.btnGroups.Click += new System.EventHandler(this.btnGroups_Click);
            // 
            // pnlAllContacts
            // 
            this.pnlAllContacts.AutoScroll = true;
            this.pnlAllContacts.Controls.Add(this.btnGroups);
            this.pnlAllContacts.Controls.Add(this.txtSearch);
            this.pnlAllContacts.Controls.Add(this.btnAdd);
            this.pnlAllContacts.Location = new System.Drawing.Point(371, 0);
            this.pnlAllContacts.Name = "pnlAllContacts";
            this.pnlAllContacts.Size = new System.Drawing.Size(358, 392);
            this.pnlAllContacts.TabIndex = 15;
            // 
            // pnlFullContact
            // 
            this.pnlFullContact.Controls.Add(this.fullContactInfo1);
            this.pnlFullContact.Location = new System.Drawing.Point(0, 0);
            this.pnlFullContact.Name = "pnlFullContact";
            this.pnlFullContact.Size = new System.Drawing.Size(370, 391);
            this.pnlFullContact.TabIndex = 16;
            // 
            // fullContactInfo1
            // 
            this.fullContactInfo1.Address = "Address:";
            this.fullContactInfo1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.fullContactInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fullContactInfo1.ContactID = "ID";
            this.fullContactInfo1.Email = "Email: ";
            this.fullContactInfo1.FirstName = null;
            this.fullContactInfo1.FullName = "Full Name";
            this.fullContactInfo1.LastName = null;
            this.fullContactInfo1.Location = new System.Drawing.Point(0, 1);
            this.fullContactInfo1.Name = "fullContactInfo1";
            this.fullContactInfo1.PhoneNumber = "Phone Number: ";
            this.fullContactInfo1.PicAdded = false;
            this.fullContactInfo1.Size = new System.Drawing.Size(370, 391);
            this.fullContactInfo1.TabIndex = 0;
            // 
            // AllContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.pnlAllContacts);
            this.Controls.Add(this.pnlFullContact);
            this.Name = "AllContacts";
            this.Size = new System.Drawing.Size(742, 395);
            this.pnlAllContacts.ResumeLayout(false);
            this.pnlAllContacts.PerformLayout();
            this.pnlFullContact.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerCheckForChanges;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnGroups;
        private System.Windows.Forms.Panel pnlAllContacts;
        private System.Windows.Forms.Panel pnlFullContact;
        private FullContactInfo fullContactInfo1;
    }
}
