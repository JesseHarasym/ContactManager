namespace AddressBookProject
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.checkForGroups = new System.Windows.Forms.Timer(this.components);
            this.allGroups1 = new AddressBookProject.AllGroups();
            this.allContacts = new AddressBookProject.AllContacts();
            this.fullContactInfo1 = new AddressBookProject.FullContactInfo();
            this.SuspendLayout();
            // 
            // allGroups1
            // 
            this.allGroups1.AutoSize = true;
            this.allGroups1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.allGroups1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.allGroups1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.allGroups1.Dock = System.Windows.Forms.DockStyle.Right;
            this.allGroups1.Location = new System.Drawing.Point(734, 0);
            this.allGroups1.Name = "allGroups1";
            this.allGroups1.Size = new System.Drawing.Size(2, 399);
            this.allGroups1.TabIndex = 3;
            // 
            // allContacts
            // 
            this.allContacts.AutoScroll = true;
            this.allContacts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.allContacts.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.allContacts.Dock = System.Windows.Forms.DockStyle.Left;
            this.allContacts.Location = new System.Drawing.Point(377, 0);
            this.allContacts.Name = "allContacts";
            this.allContacts.Size = new System.Drawing.Size(357, 399);
            this.allContacts.TabIndex = 2;
            // 
            // fullContactInfo1
            // 
            this.fullContactInfo1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.fullContactInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fullContactInfo1.Dock = System.Windows.Forms.DockStyle.Left;
            this.fullContactInfo1.Location = new System.Drawing.Point(0, 0);
            this.fullContactInfo1.Name = "fullContactInfo1";
            this.fullContactInfo1.Size = new System.Drawing.Size(377, 399);
            this.fullContactInfo1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(736, 399);
            this.Controls.Add(this.allGroups1);
            this.Controls.Add(this.allContacts);
            this.Controls.Add(this.fullContactInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(741, 433);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Address Book";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FullContactInfo fullContactInfo1;
        private AllContacts allContacts;
        private System.Windows.Forms.Timer checkForGroups;
        private AllGroups allGroups1;
    }
}

