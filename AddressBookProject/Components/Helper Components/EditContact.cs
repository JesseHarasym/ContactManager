using System;
using System.Drawing;
using System.Windows.Forms;

namespace AddressBookProject
{
    public partial class EditContact : Form
    {
        public PictureBox ProfilePic = new PictureBox();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool PictureAdded { get; set; }

        public EditContact()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FirstName = txtFirstName.Text;
            LastName = txtLastName.Text;
            PhoneNumber = txtPhoneNumber.Text;
            Address = txtAddress.Text;
            Email = txtEmail.Text;
        }

        private void EditContact_Load(object sender, EventArgs e)
        {
            var abc = AddressBookContacts.Instance;
            foreach (var c in abc.ContactList)
            {
                if (c.ContactID.ToString() == abc.CurrentContactShowing)
                {
                    txtFirstName.Text = c.FirstName;
                    txtLastName.Text = c.LastName;
                    txtAddress.Text = c.Address;
                    txtEmail.Text = c.Email;
                    txtPhoneNumber.Text = c.PhoneNumber;

                    if (c.PictureAdded)
                    {
                        picProfileCheck.Image = c.ProfilePic.Image;
                    }
                }
            }
        }

        private void btnEditPicture_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Edit contacts profile picture";
                dialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ProfilePic.Image = new Bitmap(dialog.FileName);
                    picProfileCheck.Image = ProfilePic.Image;
                    PictureAdded = true;
                }
            }
        }
    }
}
