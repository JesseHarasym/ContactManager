using System.Windows.Forms;

namespace AddressBookProject
{
    public partial class ContactBasic : UserControl
    {
        AddressBookContacts abc = AddressBookContacts.Instance;
        public ContactBasic()
        {
            InitializeComponent();
        }

        public string ContactID { get; set; }
        public bool PictureAdded { get; set; }
        //basic get;set; for data binding to associate the bound data with their labels/pictureBox
        public PictureBox ProfilePic
        {
            get { return picBoxContact; }
            set { picBoxContact.Image = value.Image; }
        }
        public string ContactName
        {
            get { return lblContactName.Text; }
            set { lblContactName.Text = value; }
        }

        //if a contact is clicked, change the contacts singleton to indicate as such
        private void ContactBasic_Click(object sender, System.EventArgs e)
        {

            abc.CurrentContactShowing = ContactID;
        }
    }
}

