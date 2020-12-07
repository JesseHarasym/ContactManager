using AddressBookProject.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AddressBookProject.Components.Helper_Components
{
    public partial class EditGroup : Form
    {
        AddressBookContacts abc = AddressBookContacts.Instance;
        AddressBookGroups abg = AddressBookGroups.Instance;
        public List<ContactBasic> ContactCard = new List<ContactBasic>();
        public List<CheckBox> CheckBoxes = new List<CheckBox>();
        public string GroupName { get; set; }

        public EditGroup()
        {
            InitializeComponent();
        }

        private void EditGroup_Load(object sender, EventArgs e)
        {
            //panel used for adding checkboxes to show the user the currently selected contacts in the group
            FlowLayoutPanel pnl = new FlowLayoutPanel();
            pnl.Dock = DockStyle.Fill;
            pnl.AutoScroll = true;

            //add check boxes for user to choose contacts to be added to group
            foreach (var c in abc.ContactCards)
            {
                var check = new CheckBox() { Text = c.ContactName, Name = c.ContactID };

                CheckBoxes.Add(check);
                pnl.Controls.Add(check);
            }
            pnlAddGroup.Controls.Add(pnl);

            //search group and make the checkboxes checked if the contact is already a part of the group being edited
            foreach (var g in abg.GroupList)
            {
                foreach (var c in g.ContactCards)
                {
                    if (g.GroupID == Convert.ToInt32(abg.CurrentGroupShowing))
                    {
                        foreach (var cb in CheckBoxes)
                        {
                            if (c.ContactName == cb.Text)
                            {
                                cb.Checked = true;
                            }
                        }
                    }
                }
            }

            //show the groups current name (was too wonky to be added with the previous foreach)
            foreach (var g in abg.GroupCards)
            {
                if (g.GroupID == abg.CurrentGroupShowing)
                {
                    txtGroupName.Text = g.GroupName;
                }
            }
        }

        //add contacts to list to be accessed when the user has clicked the edit button
        private void btnEdit_Click(object sender, EventArgs e)
        {
            foreach (var checkBox in CheckBoxes)
            {
                if (checkBox.Checked)
                {
                    foreach (var c in abc.ContactCards)
                    {
                        if (checkBox.Name == c.ContactID)
                        {
                            ContactCard.Add(c);
                        }
                    }
                }
            }

            GroupName = txtGroupName.Text;
        }
    }
}
