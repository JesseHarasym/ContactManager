using System;
using System.Drawing;
using System.Windows.Forms;

namespace AddressBookProject
{
    public partial class EditContact : Form
    {
        public string ContactID { get; set; }
        public PictureBox ProfilePic { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool PictureAdded { get; set; }

        public EditContact()
        {
            InitializeComponent();
        }

        //constructor to pass information from FullContactInfo class into EditContact class
        public EditContact(string contactID, PictureBox profilePic, string firstName, string lastName, string phoneNumber, string email, string address, bool picAdded)
        {
            InitializeComponent();

            ContactID = contactID;
            ProfilePic = profilePic;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            PictureAdded = picAdded;
        }

        //load current contact being edited into text boxes so that user knows what they're changed
        private void EditContact_Load(object sender, EventArgs e)
        {
            txtFirstName.Text = FirstName;
            txtLastName.Text = LastName;
            txtAddress.Text = Address;
            txtEmail.Text = Email;
            txtPhoneNumber.Text = PhoneNumber;
            picProfileCheck.Image = ProfilePic.Image;
        }

        //when clicked edit, change the classes properties with the newly entered data so it can be accessed
        private void btnEdit_Click(object sender, EventArgs e)
        {
            FirstName = txtFirstName.Text;
            LastName = txtLastName.Text;
            PhoneNumber = txtPhoneNumber.Text;
            Address = txtAddress.Text;
            Email = txtEmail.Text;
            ProfilePic.Image = picProfileCheck.Image;
        }

        //replace with a new picture if the user so wishes
        private void btnEditPicture_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Edit contacts profile picture";
                dialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    picProfileCheck.Image = new Bitmap(dialog.FileName);
                    PictureAdded = true;    //indicate the picture has been changed
                }
            }
        }
    }
}
