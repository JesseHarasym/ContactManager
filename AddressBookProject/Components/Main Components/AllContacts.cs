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
        private int ContactID;
        private int CardStartPos = 56;
        private int CardHeight = 68;
        private int CardPos;
        private int SearchedCardPos;

        public AllContacts()
        {
            InitializeComponent();
            timerCheckForDelete.Start();
        }

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

        public void DisplayContactCard(PictureBox profilePic, string firstName, string lastName, string phoneNumber, string address, string email, bool picAdded)
        {
            ContactBasic contact = abc.AddContact(profilePic, firstName, lastName, phoneNumber, address, email, ContactID, CardStartPos, CardPos, picAdded);
            ContactID = Convert.ToInt32(contact.ContactID);

            Controls.Add(contact);
            ContactsVisible.Add(contact);
            abg.GroupChanged = true;
            abc.CurrentContactShowing = contact.ContactID;

            CardPos += CardHeight;
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
                    SearchedCardPos = CardStartPos;
                    searched = abc.SearchContact(txtSearch.Text, ContactsVisible);

                    searchedContactCard = searched.ToList();

                    foreach (var c in ContactsVisible)
                    {
                        Controls.Remove(c);
                    }

                    ContactsVisible.Clear();

                    foreach (var c in searchedContactCard.Distinct())
                    {
                        if (c == searchedContactCard.First())
                        {
                            abc.CurrentContactShowing = c.ContactID;
                        }
                        c.Top = SearchedCardPos;
                        Controls.Add(c);
                        ContactsVisible.Add(c);
                        SearchedCardPos += CardHeight;
                    }
                }
                else
                {
                    if (abg.CurrentGroupShowing != "1")
                    {
                        CardPos = CardStartPos;
                        foreach (var g in groupSearch)
                        {
                            foreach (var c in g)
                            {
                                if (c == g.First())
                                {
                                    abc.CurrentContactShowing = c.ContactID;
                                }
                                c.Top = CardPos;
                                Controls.Add(c);
                                ContactsVisible.Add(c);
                                CardPos += CardHeight;
                            }
                        }
                    }
                    else
                    {
                        foreach (var c in abc.ContactCards)
                        {
                            if (c == abc.ContactCards.First())
                            {
                                abc.CurrentContactShowing = c.ContactID;
                            }
                            c.Top = SearchedCardPos;
                            Controls.Add(c);
                            ContactsVisible.Add(c);
                            SearchedCardPos += CardHeight;
                        }
                    }
                }

                SearchedCardPos = CardStartPos;
            }
        }

        public void SearchGroups()
        {
            if (abg.GroupChanged && abc.DatabaseLoaded == false)
            {
                foreach (var g in abg.GroupList)
                {
                    if (g.GroupID == Convert.ToInt32(abg.CurrentGroupShowing))
                    {
                        SearchedCardPos = CardStartPos;
                        foreach (var c in ContactsVisible)
                        {
                            Controls.Remove(c);
                        }

                        ContactsVisible.Clear();

                        foreach (var c in g.ContactCards)
                        {
                            c.Top = SearchedCardPos;

                            Controls.Add(c);
                            ContactsVisible.Add(c);
                            SearchedCardPos += CardHeight;

                            if (c == g.ContactCards.First())
                            {
                                abc.CurrentContactShowing = c.ContactID;
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

        public void WhichContactClicked()
        {
            foreach (var c in ContactsVisible)
            {
                if (c.ContactID == abc.CurrentContactShowing)
                {
                    c.BackColor = Color.DarkBlue;
                    c.ForeColor = Color.AliceBlue;
                }
                else
                {
                    c.BackColor = SystemColors.GradientInactiveCaption;
                    c.ForeColor = Color.Black;
                }
            }
        }

        public void CheckForDeletedData()
        {
            bool deletedSuccessful = false;
            int deletedCount = 0;

            foreach (var c in abc.ContactCards)
            {
                if (c.ContactID == abc.DeletedContactID)
                {
                    Controls.Remove(c);
                    deletedSuccessful = true;
                    deletedCount++;
                }

                if (deletedSuccessful)
                {
                    c.Top -= CardHeight;
                }
            }
            abc.ContactCards.RemoveAll(c => c.ContactID == abc.DeletedContactID);
            abc.DeletedContactID = "0";

            deletedCount *= CardHeight;
            CardPos -= deletedCount;
            SearchedCardPos -= deletedCount;
        }

        public void CheckForDatabaseLoad()
        {
            if (abc.DatabaseLoaded)
            {
                foreach (var c in abc.DatabaseList)
                {
                    ContactID = c.ContactID - 1;
                    DisplayContactCard(c.ProfilePic, c.FirstName, c.LastName, c.PhoneNumber, c.Address, c.Email, c.PictureAdded);
                }
                abc.CurrentContactShowing = abc.ContactList.First().ContactID.ToString();
            }

            abc.DatabaseLoaded = false;
        }

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

        private void timerCheckForDelete_Tick(object sender, EventArgs e)
        {
            CheckForDatabaseLoad();
            CheckForDeletedData();
            WhichContactClicked();
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
            AutoScroll = true;
        }
    }
}
