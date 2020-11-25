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
        }

        public void SetGroupInfo(string id, string name)
        {
            GroupID = id;
            GroupName = name;
            lblGroupName.Text = GroupName;
        }

        public void HideDeleteBtn()
        {
            btnDelete.Visible = false;
        }

        private void BasicGroup_MouseDown(object sender, MouseEventArgs e)
        {
            if (GroupID != abg.CurrentGroupShowing)
            {
                abg.CurrentGroupShowing = GroupID;
                abg.GroupChanged = true;
            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            abg.RemoveGroup(Convert.ToInt32(GroupID));
        }

        private void tmrRefreshGroup_Tick(object sender, EventArgs e)
        {

            lblGroupName.Text = GroupName;
        }
    }
}
