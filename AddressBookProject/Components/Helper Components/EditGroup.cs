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

            foreach (var g in abg.GroupCards)
            {
                if (g.GroupID == abg.CurrentGroupShowing)
                {
                    txtGroupName.Text = g.GroupName;
                }
            }
        }

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
