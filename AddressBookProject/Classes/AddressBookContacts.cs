using AddressBookProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AddressBookProject
{
    //This is a singleton class that handles the data related to contacts in the AddressBook application.
    public sealed class AddressBookContacts
    {
        private AddressBookContacts()
        {
        }

        //creation of single instance of class for our contact singleton
        private static readonly object padlock = new object();
        private static AddressBookContacts instance = null;
        public static AddressBookContacts Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new AddressBookContacts();
                    }
                    return instance;
                }
            }
        }

        public ConnectContactDB db = new ConnectContactDB();
        public AddressBookGroups abg = AddressBookGroups.Instance;
        public List<Contacts> DatabaseList = new List<Contacts>();
        public List<Contacts> ContactList = new List<Contacts>();
        public List<ContactBasic> ContactCards = new List<ContactBasic>();
        public string CurrentContactShowing { get; set; }   //to track the currently clicked contact
        public string DeletedContactID { get; set; }    //to track the last contact that has been deleted
        public bool DatabaseLoaded { get; set; }    //to track when the database is loaded and needs ContactCards created

        public Contacts AddContact(PictureBox profilePic, string firstName, string lastName, string phoneNumber, string address, string email, int contactID, bool picAdded)
        {
            contactID++;

            var contact = new Contacts()
            {
                ProfilePic = profilePic,
                ContactID = contactID,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Address = address,
                Email = email,
                PictureAdded = picAdded
            };

            ContactList.Add(contact);

            //only write to database if this isn't the database being loaded
            if (DatabaseLoaded == false)
            {
                db.AddContactData(profilePic, contactID, firstName, lastName, phoneNumber, address, email, picAdded);
            }

            return contact;
        }

        //create contact cards to display on the pnlAllContacts
        public ContactBasic AddContactCard(int cardStartPos, int cardPos)
        {
            ContactBasic contact = new ContactBasic();

            contact.Left = 1;
            contact.Top = cardPos + cardStartPos;

            ContactCards.Add(contact);

            return contact;
        }

        public bool RemoveContact(int id)
        {
            bool anyContacts = ContactList.Any();

            ContactList.RemoveAll(c => c.ContactID == id);
            DatabaseList.RemoveAll(c => c.ContactID == id);

            //remove from every group that has this contact in it
            for (int i = 0; i < abg.GroupList.Count; i++)
            {
                abg.GroupList[i].ContactCards.RemoveAll(c => c.ContactID == Convert.ToString(id));
            }

            DeletedContactID = Convert.ToString(id);

            if (anyContacts)
            {
                CurrentContactShowing = Convert.ToString(ContactList.First().ContactID);    //make first contact remaining in list the current contact shown
            }

            db.DeleteContactData(id);

            abg.GroupChanged = true;    //indicates that the groups need to be reloaded

            return anyContacts;
        }

        public void EditContact(string firstName, string lastName, string phoneNumber, string address, string email, PictureBox profilePic, bool picAdded, string contactID)
        {
            //find the contacts index and edit each input with the new input (or old input if it hasn't been changed)
            int i = ContactList.FindIndex(c => c.ContactID == Convert.ToInt32(contactID));

            ContactList[i].FirstName = firstName;
            ContactList[i].LastName = lastName;
            ContactList[i].PhoneNumber = phoneNumber;
            ContactList[i].Address = address;
            ContactList[i].Email = email;
            ContactList[i].ProfilePic = profilePic;
            ContactList[i].PictureAdded = picAdded;

            //edit the database data as well
            db.EditContactData(Convert.ToInt32(contactID), firstName, lastName, phoneNumber, address, email, profilePic, picAdded);
            EditContactCard(profilePic, picAdded, contactID);
        }

        public void EditContactCard(PictureBox profilePic, bool picAdded, string contacID)
        {
            //find ContactCard and ContactList indices of the edited ID and edit them with the new data
            int iCL = ContactList.FindIndex(c => c.ContactID.ToString() == contacID);
            int iCC = ContactCards.FindIndex(c => c.ContactID == contacID);
            ContactCards[iCC].ContactName = ContactList[iCL].FullName;
            ContactCards[iCC].ProfilePic.Image = profilePic.Image;
            ContactCards[iCC].PictureAdded = picAdded;
        }

        public IEnumerable<ContactBasic> SearchContact(string searchCriteria, List<ContactBasic> contactsVisible)
        {
            //this is just the base of our contact search function, the remaining is done in AllContacts class 
            //because everything else is related directly to the cards shown in the gui
            var searched =
                from c in contactsVisible
                where c.ContactName.ToLower().Contains(searchCriteria.ToLower())
                select c;

            return searched;
        }
    }
}