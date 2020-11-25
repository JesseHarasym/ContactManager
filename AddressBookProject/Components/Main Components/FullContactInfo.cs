using AddressBookProject.Classes;
using System;
using System.Windows.Forms;

namespace AddressBookProject
{
    public partial class FullContactInfo : UserControl
    {
        AddressBookContacts abc = AddressBookContacts.Instance;
        public FullContactInfo()
        {
            InitializeComponent();
            timerUpdateContact.Start();
        }

        public void ShowContactInformation()
        {
            foreach (var c in abc.ContactList)
            {
                if (abc.CurrentContactShowing == c.ContactID.ToString())
                {
                    picProfilePic.Image = c.ProfilePic.Image;
                    lblFullName.Text = c.FirstName + ' ' + c.LastName;
                    lblPhoneNumber.Text = "Phone Number: " + c.PhoneNumber;
                    lblEmail.Text = "Email: " + c.Email;
                    lblAddress.Text = "Address: " + c.Address;
                    lblContactID.Text = c.ContactID.ToString();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool anyContacts = abc.RemoveContact(Convert.ToInt32(lblContactID.Text));

            if (!anyContacts)
            {
                lblFullName.Text = "Full Name";
                lblPhoneNumber.Text = "Phone Number: ";
                lblEmail.Text = "Email: ";
                lblAddress.Text = "Address: ";
                lblContactID.Text = "0";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditContact ec = new EditContact();
            DialogResult dialogResult = ec.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                abc.EditContact(ec.FirstName, ec.LastName, ec.PhoneNumber, ec.Address, ec.Email, ec.ProfilePic, ec.PictureAdded);
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                //cancelled
            }
            ec.Dispose();
        }

        private void timerUpdateContact_Tick(object sender, EventArgs e)
        {
            ShowContactInformation();

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
