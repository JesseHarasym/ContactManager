namespace AddressBookProject
{
    partial class AllGroups
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
            this.pnlGroups = new System.Windows.Forms.Panel();
            this.btnAddGroups = new System.Windows.Forms.Button();
            this.txtSearchGroup = new System.Windows.Forms.TextBox();
            this.btnEditGroups = new System.Windows.Forms.Button();
            this.tmrCheckForGroups = new System.Windows.Forms.Timer(this.components);
            this.pnlGroups.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGroups
            // 
            this.pnlGroups.AutoScroll = true;
            this.pnlGroups.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlGroups.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlGroups.Controls.Add(this.btnAddGroups);
            this.pnlGroups.Controls.Add(this.txtSearchGroup);
            this.pnlGroups.Controls.Add(this.btnEditGroups);
            this.pnlGroups.Location = new System.Drawing.Point(0, 0);
            this.pnlGroups.Name = "pnlGroups";
            this.pnlGroups.Size = new System.Drawing.Size(251, 397);
            this.pnlGroups.TabIndex = 0;
            this.pnlGroups.Visible = false;
            // 
            // btnAddGroups
            // 
            this.btnAddGroups.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddGroups.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnAddGroups.FlatAppearance.BorderSize = 0;
            this.btnAddGroups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddGroups.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddGroups.Location = new System.Drawing.Point(0, 0);
            this.btnAddGroups.Name = "btnAddGroups";
            this.btnAddGroups.Size = new System.Drawing.Size(36, 32);
            this.btnAddGroups.TabIndex = 16;
            this.btnAddGroups.Text = "+";
            this.btnAddGroups.UseVisualStyleBackColor = false;
            this.btnAddGroups.Click += new System.EventHandler(this.btnAddGroups_Click);
            // 
            // txtSearchGroup
            // 
            this.txtSearchGroup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchGroup.Location = new System.Drawing.Point(0, 32);
            this.txtSearchGroup.Name = "txtSearchGroup";
            this.txtSearchGroup.Size = new System.Drawing.Size(228, 23);
            this.txtSearchGroup.TabIndex = 15;
            this.txtSearchGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchGroup_KeyDown);
            // 
            // btnEditGroups
            // 
            this.btnEditGroups.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEditGroups.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnEditGroups.FlatAppearance.BorderSize = 0;
            this.btnEditGroups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditGroups.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditGroups.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEditGroups.Location = new System.Drawing.Point(139, 0);
            this.btnEditGroups.Name = "btnEditGroups";
            this.btnEditGroups.Size = new System.Drawing.Size(89, 32);
            this.btnEditGroups.TabIndex = 17;
            this.btnEditGroups.Text = "Edit Group";
            this.btnEditGroups.UseVisualStyleBackColor = false;
            this.btnEditGroups.Click += new System.EventHandler(this.btnEditGroups_Click);
            // 
            // tmrCheckForGroups
            // 
            this.tmrCheckForGroups.Tick += new System.EventHandler(this.checkForGroups_Tick);
            // 
            // AllGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.pnlGroups);
            this.Name = "AllGroups";
            this.Size = new System.Drawing.Size(254, 400);
            this.pnlGroups.ResumeLayout(false);
            this.pnlGroups.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGroups;
        private System.Windows.Forms.Timer tmrCheckForGroups;
        private System.Windows.Forms.Button btnAddGroups;
        private System.Windows.Forms.TextBox txtSearchGroup;
        private System.Windows.Forms.Button btnEditGroups;
    }
}
