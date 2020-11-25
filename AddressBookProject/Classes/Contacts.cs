using System.Windows.Forms;

namespace AddressBookProject
{
    public class Contacts
    {
        public PictureBox ProfilePic { get; set; }
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool PictureAdded { get; set; }
    }
}
