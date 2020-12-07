using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AddressBookProject.Components.Helper_Components
{
    public partial class AddGroup : Form
    {
        AddressBookContacts abc = AddressBookContacts.Instance;
        public List<ContactBasic> ContactCard = new List<ContactBasic>();
        public List<CheckBox> CheckBoxes = new List<CheckBox>();
        public string GroupName { get; set; }
        public AddGroup()
        {
            InitializeComponent();
        }

        private void AddGroup_Load(object sender, EventArgs e)
        {
            //panel used for adding checkboxes to show the user the currently selected contacts in the group
            FlowLayoutPanel pnl = new FlowLayoutPanel();
            pnl.Dock = DockStyle.Fill;
            pnl.AutoScroll = true;

            foreach (var c in abc.ContactCards)
            {
                //create a checkbox for each ContactCard
                var check = new CheckBox() { Text = c.ContactName, Name = c.ContactID };
                CheckBoxes.Add(check);
                pnl.Controls.Add(check);
            }
            pnlAddGroup.Controls.Add(pnl);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //if the contact is chosen by the user, add to the ContactCard list to be accessed when creating group
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