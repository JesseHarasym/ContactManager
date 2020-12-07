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
            var abg = AddressBookGroups.Instance;
            //Load data currently stored in database
            abc.db.GetContactData();
            abc.DatabaseList = abc.db.ContactList;  //use database list as temporary list to load the data up
            abg.db.GetGroupData();
            abg.db.GetGroupsContactData();
            abg.DatabaseList = abg.db.GroupList;
            //set to true so that AllContacts and AllGroups classes are aware that it must create cards for this data
            abc.DatabaseLoaded = true;
            abg.DatabaseLoaded = true;

            if (abc.ContactList.Any())
            {
                abc.CurrentContactShowing = abc.ContactList.First().ContactID.ToString();
            }
        }
    }
}