using System;
using System.Drawing;
using System.Windows.Forms;

namespace AddressBookProject
{
    public partial class AddContact : Form
    {
        public PictureBox ProfilePic = new PictureBox();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool PictureAdded { get; set; }


        public AddContact()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FirstName = txtFirstName.Text;
            LastName = txtLastName.Text;
            PhoneNumber = txtPhoneNumber.Text;
            Address = txtAddress.Text;
            Email = txtEmail.Text;
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Add contacts profile picture";
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
