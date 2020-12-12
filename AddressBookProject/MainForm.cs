using AddressBookProject.Classes;
using System.Linq;
using System.Windows.Forms;

namespace AddressBookProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            var abc = AddressBookContacts.Instance;

            if (abc.ContactList.Any())
            {
                abc.CurrentContactShowing = abc.ContactList.First().ContactID.ToString();
            }


        }
    }
}