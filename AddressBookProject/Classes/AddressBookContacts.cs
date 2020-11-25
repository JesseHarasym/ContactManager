using AddressBookProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AddressBookProject
{
    //Singleton class
    public sealed class AddressBookContacts
    {
        private AddressBookContacts()
        {
            db.GetContactData();
            DatabaseList = db.ContactList;
            DatabaseLoaded = true;
        }
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

        ConnectContactDB db = new ConnectContactDB();
        AddressBookGroups abg = AddressBookGroups.Instance;
        public List<Contacts> DatabaseList = new List<Contacts>();
        public List<Contacts> ContactList = new List<Contacts>();
        public List<ContactBasic> ContactCards = new List<ContactBasic>();
        public string CurrentContactShowing { get; set; }
        public string DeletedContactID { get; set; }
        public bool DatabaseLoaded { get; set; }

        public ContactBasic AddContact(PictureBox profilePic, string firstName, string lastName, string phoneNumber, string address, string email, int contactID, int cardStartPos, int cardPos, bool picAdded)
        {
            contactID++;
            ContactList.Add(new Contacts()
            {
                ProfilePic = profilePic,
                ContactID = contactID,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Address = address,
                Email = email,
                PictureAdded = picAdded
            });

            if (DatabaseLoaded == false)
            {
                db.AddContactData(profilePic, contactID, firstName, lastName, phoneNumber, address, email, picAdded);
            }

            ContactBasic contact = AddContactCard(profilePic, cardStartPos, cardPos, contactID, picAdded);
            return contact;
        }

        public ContactBasic AddContactCard(PictureBox profilePic, int cardStartPos, int cardPos, int contactID, bool picAdded)
        {
            int left = 1;

            ContactBasic contact = new ContactBasic();

            contact.Left = left;
            contact.Top = cardPos + cardStartPos;
            contact.Name = "contact" + contactID;

            var matcher = new CardMatcher();
            string fullName = matcher.MatchContactID(contactID);
            contact.SetContactInfo(contactID.ToString(), fullName, profilePic, picAdded);

            ContactCards.Add(contact);

            return contact;
        }

        public bool RemoveContact(int id)
        {
            bool anyContacts = ContactList.Any();

            ContactList.RemoveAll(c => c.ContactID == id);
            DatabaseList.RemoveAll(c => c.ContactID == id);

            for (int i = 0; i < abg.GroupList.Count; i++)
            {
                abg.GroupList[i].ContactCards.RemoveAll(c => c.ContactID == Convert.ToString(id));
            }

            DeletedContactID = Convert.ToString(id);

            if (anyContacts)
            {
                CurrentContactShowing = Convert.ToString(ContactList.First().ContactID);
            }

            db.DeleteContactData(id);
            abg.GroupChanged = true;

            return anyContacts;
        }

        public void EditContact(string firstName, string lastName, string phoneNumber, string address, string email, PictureBox profilePic, bool picAdded)
        {
            int i = ContactList.FindIndex(c => c.ContactID.ToString() == CurrentContactShowing);
            ContactList[i].FirstName = firstName;
            ContactList[i].LastName = lastName;
            ContactList[i].PhoneNumber = phoneNumber;
            ContactList[i].Address = address;
            ContactList[i].Email = email;
            ContactList[i].ProfilePic = profilePic;
            ContactList[i].PictureAdded = picAdded;

            db.EditContactData(ContactList[i].ContactID, firstName, lastName, phoneNumber, address, email, profilePic, picAdded);
            EditContactCard(profilePic, picAdded);
        }

        public void EditContactCard(PictureBox profilePic, bool picAdded)
        {
            int iCL = ContactList.FindIndex(c => c.ContactID.ToString() == CurrentContactShowing);
            int iCC = ContactCards.FindIndex(c => c.ContactID == CurrentContactShowing);
            ContactCards[iCC].ContactName = ContactList[iCL].FirstName + ' ' + ContactList[iCL].LastName;
            ContactCards[iCC].ProfilePic.Image = profilePic.Image;
            ContactCards[iCC].PictureAdded = picAdded;
        }

        public IEnumerable<ContactBasic> SearchContact(string searchCriteria, List<ContactBasic> contactsVisible)
        {
            var searched =
                from c in contactsVisible
                where c.ContactName.ToLower().Contains(searchCriteria.ToLower())
                select c;

            return searched;
        }
    }
}