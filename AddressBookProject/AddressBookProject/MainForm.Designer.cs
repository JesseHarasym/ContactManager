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
            this.allGroups = new AddressBookProject.AllGroups();
            this.allContacts1 = new AddressBookProject.AllContacts();
            this.SuspendLayout();
            // 
            // allGroups
            // 
            this.allGroups.AutoSize = true;
            this.allGroups.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.allGroups.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.allGroups.Dock = System.Windows.Forms.DockStyle.Right;
            this.allGroups.Location = new System.Drawing.Point(749, 0);
            this.allGroups.Name = "allGroups";
            this.allGroups.Size = new System.Drawing.Size(0, 411);
            this.allGroups.TabIndex = 5;
            // 
            // allContacts1
            // 
            this.allContacts1.AutoScroll = true;
            this.allContacts1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.allContacts1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.allContacts1.Dock = System.Windows.Forms.DockStyle.Left;
            this.allContacts1.Location = new System.Drawing.Point(0, 0);
            this.allContacts1.Name = "allContacts1";
            this.allContacts1.Size = new System.Drawing.Size(750, 411);
            this.allContacts1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(749, 411);
            this.Controls.Add(this.allGroups);
            this.Controls.Add(this.allContacts1);
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
        private System.Windows.Forms.Timer checkForGroups;
        private AllContacts allContacts1;
        private AllGroups allGroups;
    }
}

