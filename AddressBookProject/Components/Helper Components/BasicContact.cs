using System.Windows.Forms;

namespace AddressBookProject
{
    public partial class ContactBasic : UserControl
    {
        private AddressBookContacts abc = AddressBookContacts.Instance;
        public PictureBox ProfilePic = new PictureBox();
        public string ContactID { get; set; }
        public string ContactName { get; set; }

        public bool PictureAdded { get; set; }
        public ContactBasic()
        {
            InitializeComponent();
            tmrRefreshContact.Start();
        }

        private void ContactBasic_MouseDown(object sender, MouseEventArgs e)
        {
            abc.CurrentContactShowing = ContactID;
        }

        public void SetContactInfo(string id, string name, PictureBox profilePic, bool picAdded)
        {
            PictureAdded = picAdded;

            ContactID = id;
            ContactName = name;
            lblContactName.Text = ContactName;

            if (PictureAdded)
            {
                ProfilePic.Image = profilePic.Image;
                picBoxContact.Image = ProfilePic.Image;
            }
        }

        private void refreshContact_Tick(object sender, System.EventArgs e)
        {
            lblContactName.Text = ContactName;

            if (PictureAdded)
            {
                picBoxContact.Image = ProfilePic.Image;
            }
        }
    }
}

