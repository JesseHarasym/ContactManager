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
        public string GroupName;
        public AddGroup()
        {
            InitializeComponent();
        }

        private void AddGroup_Load(object sender, EventArgs e)
        {
            FlowLayoutPanel pnl = new FlowLayoutPanel();
            pnl.Dock = DockStyle.Fill;
            pnl.AutoScroll = true;

            foreach (var c in abc.ContactCards)
            {
                var check = new CheckBox() { Text = c.ContactName, Name = c.ContactID };
                CheckBoxes.Add(check);
                pnl.Controls.Add(check);
            }
            pnlAddGroup.Controls.Add(pnl);
        }

        private void btnCreate_Click(object sender, EventArgs e)
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
