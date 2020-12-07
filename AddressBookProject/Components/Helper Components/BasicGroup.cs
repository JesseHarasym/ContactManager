using AddressBookProject.Classes;
using System;
using System.Windows.Forms;

namespace AddressBookProject.Components.Helper_Components
{
    public partial class BasicGroup : UserControl
    {
        AddressBookGroups abg = AddressBookGroups.Instance;
        public string GroupID { get; set; }
        public string GroupName { get; set; }

        public BasicGroup()
        {
            InitializeComponent();
            tmrRefreshGroup.Start();
        }

        //since no data binding in groups, set the properties and labels manually
        public void SetGroupInfo(string id, string name)
        {
            GroupID = id;
            GroupName = name;
            lblGroupName.Text = GroupName;
        }

        //for hiding delete button with All Contacts
        public void HideDeleteBtn()
        {
            btnDelete.Visible = false;
        }

        //indicate if a group has been chosen to our groups singleton
        private void BasicGroup_MouseDown(object sender, MouseEventArgs e)
        {
            if (GroupID != abg.CurrentGroupShowing)
            {
                abg.CurrentGroupShowing = GroupID;
                abg.GroupChanged = true;
            }
        }

        //if the delete button is clicked, remove with our singleton method and edit data from there
        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            abg.RemoveGroup(Convert.ToInt32(GroupID));
        }

        //refresh to know when a groups name has been changed
        private void tmrRefreshGroup_Tick(object sender, EventArgs e)
        {
            lblGroupName.Text = GroupName;
        }
    }
}