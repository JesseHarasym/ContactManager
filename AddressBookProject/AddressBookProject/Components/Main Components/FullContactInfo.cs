using AddressBookProject.Classes;
using System;
using System.Windows.Forms;

namespace AddressBookProject
{
    public partial class FullContactInfo : UserControl
    {
        public FullContactInfo()
        {
            InitializeComponent();
            timerUpdateContact.Start();
        }

        //these properties automatically set their labels/pictureBox as the data is changed in the corresponding Contacts class instance
        public string ContactID
        {
            get
            {
                return lblContactID.Text;
            }
            set
            {
                lblContactID.Text = value;
            }
        }
        public PictureBox ProfilePic
        {
            get
            {
                return picProfilePic;
            }
            set
            {
                picProfilePic.Image = value.Image;
            }
        }
        public string FullName
        {
            get
            {
                return lblFullName.Text;
            }
            set
            {
                lblFullName.Text = value;
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber
        {
            get
            {
                return lblPhoneNumber.Text;
            }
            set
            {
                lblPhoneNumber.Text = value;
            }
        }
        public string Email
        {
            get
            {
                return lblEmail.Text;
            }
            set
            {
                lblEmail.Text = value;
            }
        }
        public string Address
        {
            get
            {
                return lblAddress.Text;
            }
            set
            {
                lblAddress.Text = value;
            }
        }
        public bool PicAdded { get; set; }

        //edits contact in our contacts singleton according to properties changed in the EditContact class
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditContact ec = new EditContact(ContactID, ProfilePic, FirstName, LastName, PhoneNumber, Email, Address, PicAdded);

            DialogResult dialogResult = ec.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                AddressBookContacts.Instance.EditContact(ec.FirstName, ec.LastName, ec.PhoneNumber, ec.Address, ec.Email, ec.ProfilePic, ec.PictureAdded, ec.ContactID);
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                //cancelled
            }
            ec.Dispose();
        }

        //delete contact in our contacts singleton
        private void btnDelete_Click(object sender, EventArgs e)
        {
            AddressBookContacts.Instance.RemoveContact(Convert.ToInt32(ContactID));

        }

        //timer to hide/show delete button depending on if you're viewing the All Contacts group
        //i made this choice to simplify data management and to only allow users to remove contacts in a group
        //through editing that group, not through deleting contacts themselves, and it got messy to deal with
        private void timerUpdateContact_Tick(object sender, EventArgs e)
        {
            if (AddressBookGroups.Instance.CurrentGroupShowing == "1")
            {
                btnDelete.Visible = true;
            }
            else
            {
                btnDelete.Visible = false;
            }
        }
    }
}
