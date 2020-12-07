using AddressBookProject.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AddressBookProject
{
    public partial class AllContacts : UserControl
    {
        AddressBookContacts abc = AddressBookContacts.Instance;
        AddressBookGroups abg = AddressBookGroups.Instance;
        private List<ContactBasic> ContactsVisible = new List<ContactBasic>();
        private List<FullContactInfo> FullContact = new List<FullContactInfo>();
        private int ContactID;
        private int CardStartPos = 56;
        private int CardHeight = 68;
        private int CardPos;
        private int SearchedCardPos;
        private string CurrentContact;

        public AllContacts()
        {
            InitializeComponent();
            timerCheckForChanges.Start();
        }

        //gets results of AddContact class dialog
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            AddContact ac = new AddContact();
            DialogResult dialogResult = ac.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                DisplayContactCard(ac.ProfilePic, ac.FirstName, ac.LastName, ac.PhoneNumber, ac.Address, ac.Email, ac.PictureAdded);
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                //cancelled
            }
            ac.Dispose();
        }

        //creates contacts, sends data to AddressBookContacts to add to our singleton, and then returns whats needed to create our ContactCards
        public void DisplayContactCard(PictureBox profilePic, string firstName, string lastName, string phoneNumber, string address, string email, bool picAdded)
        {
            Contacts contact = abc.AddContact(profilePic, firstName, lastName, phoneNumber, address, email, ContactID, picAdded);

            ContactBasic contactCard = abc.AddContactCard(CardStartPos, CardPos);

            //bind each created allContact object to the Contact class 
            #region
            contactCard.DataBindings.Add("ContactName", contact, "FullName", true,
                DataSourceUpdateMode.OnPropertyChanged);
            contactCard.DataBindings.Add("ProfilePic", contact, "ProfilePic", true,
                DataSourceUpdateMode.OnPropertyChanged);
            contactCard.DataBindings.Add("ContactID", contact, "ContactID", true,
                DataSourceUpdateMode.OnPropertyChanged);
            #endregion  //where contact card is binded to contact list

            ContactID = Convert.ToInt32(contactCard.ContactID); //current id is last id added to ContactList in AddressBookContacts singleton

            pnlAllContacts.Controls.Add(contactCard);   //add to panel to view card
            ContactsVisible.Add(contactCard);   //add to list to track current visible contacts (to aid with searching and the logistics of groups)

            FullContactInfo fullContact = new FullContactInfo();
            //bind each created allContact object to the Contact class 
            #region

            fullContact.DataBindings.Add("ContactID", contact, "ContactID", true,
                DataSourceUpdateMode.OnPropertyChanged);
            fullContact.DataBindings.Add("ProfilePic", contact, "ProfilePic", true,
                DataSourceUpdateMode.OnPropertyChanged);
            fullContact.DataBindings.Add("FullName", contact, "FullName", true,
                DataSourceUpdateMode.OnPropertyChanged);
            fullContact.DataBindings.Add("FirstName", contact, "FirstName", true,
                DataSourceUpdateMode.OnPropertyChanged);
            fullContact.DataBindings.Add("LastName", contact, "LastName", true,
                DataSourceUpdateMode.OnPropertyChanged);
            fullContact.DataBindings.Add("PhoneNumber", contact, "PhoneNumber", true,
                DataSourceUpdateMode.OnPropertyChanged);
            fullContact.DataBindings.Add("Address", contact, "Address", true,
                DataSourceUpdateMode.OnPropertyChanged);
            fullContact.DataBindings.Add("Email", contact, "Email", true,
                DataSourceUpdateMode.OnPropertyChanged);
            fullContact.DataBindings.Add("PicAdded", contact, "PictureAdded", true,
                DataSourceUpdateMode.OnPropertyChanged);
            #endregion

            fullContactInfo1.Visible = false;   //hide default FullContact panel
            pnlFullContact.Controls.Clear();
            pnlFullContact.Controls.Add(fullContact);
            FullContact.Add(fullContact);

            abc.CurrentContactShowing = ContactID.ToString();

            abg.GroupChanged = true;

            CardPos += CardHeight;  //variable to keep track of current card position
        }

        //if database is loaded then add each contact to be loaded into our singleton ContactList and ContactCard and then for ContactCard to be displayed
        public void CheckForDatabaseLoad()
        {
            if (abc.DatabaseLoaded)
            {
                abc.db.GetContactData();
                abc.DatabaseList = abc.db.ContactList;  //use database list as temporary list to load the data up
                foreach (var c in abc.DatabaseList)
                {
                    ContactID = c.ContactID - 1;
                    DisplayContactCard(c.ProfilePic, c.FirstName, c.LastName, c.PhoneNumber, c.Address, c.Email, c.PictureAdded);
                }

                if (abc.ContactList.Any())
                {
                    abc.CurrentContactShowing = abc.ContactList.First().ContactID.ToString();   //make first contact in ContactList the currently viewed contact 
                }
            }

            abc.DatabaseLoaded = false; //stop load unless database is loaded again
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                List<ContactBasic> searchedContactCard = new List<ContactBasic>();

                var searched = abc.ContactCards.Select(c => c);
                var groupSearch = abg.GroupList.Where(g => g.GroupID == Convert.ToInt32(abg.CurrentGroupShowing))
                    .Select(g => g.ContactCards);

                if (!String.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    SearchedCardPos = CardStartPos; //back to starting pos every time a search is done
                    searched = abc.SearchContact(txtSearch.Text, ContactsVisible);  //send to our singleton class to search the criteria entered by user

                    searchedContactCard = searched.ToList();

                    foreach (var c in ContactsVisible)
                    {
                        pnlAllContacts.Controls.Remove(c);  //remove every ContactCard currently visible to user
                    }

                    ContactsVisible.Clear();    //clear list of visible contacts to be re added to 

                    foreach (var c in searchedContactCard.Distinct())   //only find distinct (had issues with duplicates with my group set up)
                    {
                        if (c == searchedContactCard.First())
                        {
                            abc.CurrentContactShowing = c.ContactID;    //make first contact in our search list the currently visible contact
                        }
                        //add to our AllContact panel, add to our Visible list and increment the positioning
                        c.Top = SearchedCardPos;
                        pnlAllContacts.Controls.Add(c);
                        ContactsVisible.Add(c);
                        SearchedCardPos += CardHeight;
                    }
                }
                else
                {
                    if (abg.CurrentGroupShowing != "1") //if the current group showing is not All Contacts, then show all contacts in that specific group
                    {
                        CardPos = CardStartPos;
                        foreach (var g in groupSearch)  //search group specifically rather then All Contacts
                        {
                            foreach (var c in g)
                            {
                                //this was all explained in the first if statement
                                if (c == g.First())
                                {
                                    abc.CurrentContactShowing = c.ContactID;
                                }
                                c.Top = CardPos;
                                pnlAllContacts.Controls.Add(c);
                                ContactsVisible.Add(c);
                                CardPos += CardHeight;
                            }
                        }
                    }
                    else   //if search is empty and AllContacts, show all contacts in our singletons list
                    {
                        foreach (var c in abc.ContactCards)
                        {
                            //this was all explained in the first if statement
                            if (c == abc.ContactCards.First())
                            {
                                abc.CurrentContactShowing = c.ContactID;
                            }
                            c.Top = SearchedCardPos;
                            pnlAllContacts.Controls.Add(c);
                            ContactsVisible.Add(c);
                            SearchedCardPos += CardHeight;
                        }
                    }
                }

                SearchedCardPos = CardStartPos; //reset SearchedCardPos so its ready for the next search
            }
        }

        //search group is in AllContacts since it was panel is a part of the AllContacts custom control
        //this not actually searching a GroupCard, but rather the ContactCards associated with the currently showing group
        public void SearchGroups()
        {
            if (abg.GroupChanged && abc.DatabaseLoaded == false)
            {
                foreach (var g in abg.GroupList)
                {
                    //this whole base search class works almost identically to searching contacts except for the last if
                    if (g.GroupID == Convert.ToInt32(abg.CurrentGroupShowing))
                    {
                        SearchedCardPos = CardStartPos;
                        foreach (var c in ContactsVisible)
                        {
                            pnlAllContacts.Controls.Remove(c);
                        }

                        ContactsVisible.Clear();

                        foreach (var c in g.ContactCards)
                        {
                            c.Top = SearchedCardPos;
                            pnlAllContacts.Controls.Add(c);
                            ContactsVisible.Add(c);
                            SearchedCardPos += CardHeight;

                            if (c == g.ContactCards.First())
                            {
                                //to allow contacts to be clicked and shown when they are in a group
                                var clickedContact = FullContact.First(con => con.ContactID == c.ContactID);
                                pnlFullContact.Controls.Clear();
                                pnlFullContact.Controls.Add(clickedContact);
                                abc.CurrentContactShowing = c.ContactID;
                                //color change for chosen card
                                c.BackColor = Color.DarkBlue;
                                c.ForeColor = Color.AliceBlue;
                            }
                        }
                    }
                }
            }
            SearchedCardPos = CardStartPos;
            abg.GroupChanged = false;
        }

        //this checks for user deleted data and removes the ContactCards as needed
        public void CheckForDeletedData()
        {
            bool deletedSuccessful = false;
            int deletedCount = 0;

            foreach (var c in abc.ContactCards)
            {
                if (c.ContactID == abc.DeletedContactID)
                {
                    pnlAllContacts.Controls.Remove(c);
                    pnlFullContact.Controls.Remove(c);

                    if (!ContactsVisible.Any())
                    {
                        fullContactInfo1.Visible = true;
                    }

                    deletedSuccessful = true;
                    deletedCount++;
                }

                //if a contact was deleted then adjust the remaining ContactCard positions
                if (deletedSuccessful)
                {
                    c.Top -= CardHeight;
                }
            }
            abc.ContactCards.RemoveAll(c => c.ContactID == abc.DeletedContactID);
            abc.DeletedContactID = "0";

            //tracks total number of contacts to ensure CardPos and SearchCardPos is always taking that into account
            deletedCount *= CardHeight;
            CardPos -= deletedCount;
            SearchedCardPos -= deletedCount;
        }

        //used to open and close the groups window on the right side
        private void btnGroups_Click(object sender, EventArgs e)
        {
            if (abg.GroupsVisible == false)
            {
                btnGroups.Text = "Close Groups";
                abg.GroupsVisible = true;
            }
            else
            {
                btnGroups.Text = "Open Groups";
                abg.GroupsVisible = false;
            }
        }

        //this tracks which contact the user has clicked and shows the full contact and changes the colors of the card
        //to indicate that it has been chosen
        //because the data is bound, I originally did this through an event handler in the BasicContact class
        //but ran into bugs that made it simpler to leave this as is (was already built) as a way to indicate contact clicked
        public void WhichContactClicked()
        {
            foreach (var c in ContactsVisible)
            {
                if (c.ContactID == abc.CurrentContactShowing && c.ContactID != CurrentContact)
                {
                    c.BackColor = Color.DarkBlue;
                    c.ForeColor = Color.AliceBlue;
                    var clickedContact = FullContact.First(con => con.ContactID == c.ContactID);
                    pnlFullContact.Controls.Clear();
                    pnlFullContact.Controls.Add(clickedContact);
                    CurrentContact = clickedContact.ContactID;
                }
                else if (c.ContactID != abc.CurrentContactShowing)
                {
                    c.BackColor = SystemColors.GradientInactiveCaption;
                    c.ForeColor = Color.Black;
                }
            }
        }

        //since we hadn't learned data binding when I created the bulk of this application, I used timers to
        //check if a variety of actions have occured, and this is what this is for.
        //the names of the functions should identify what the timer is trying to do
        private void timerCheckForChanges_Tick(object sender, EventArgs e)
        {
            WhichContactClicked();
            CheckForDatabaseLoad();
            CheckForDeletedData();
            SearchGroups();

            if (abg.CurrentGroupShowing == "1")
            {
                btnAdd.Visible = true;
            }
            else
            {
                btnAdd.Visible = false;
            }
        }

        private void AllContacts_Load(object sender, EventArgs e)
        {
            //AutoScroll = true;
        }
    }
}
