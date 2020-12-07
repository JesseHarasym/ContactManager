using AddressBookProject.Classes;
using AddressBookProject.Components.Helper_Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AddressBookProject
{
    public partial class AllGroups : UserControl
    {
        AddressBookContacts abc = AddressBookContacts.Instance;
        AddressBookGroups abg = AddressBookGroups.Instance;
        public int GroupID;
        private int CardStartPos = 56;
        private int CardHeight = 68;
        private int CardPos;
        private int SearchedCardPos;
        public AllGroups()
        {
            InitializeComponent();
            tmrCheckForGroups.Start();
        }

        //gets results of AddGroup class dialog
        private void btnAddGroups_Click(object sender, System.EventArgs e)
        {
            AddGroup ag = new AddGroup();
            DialogResult dialogResult = ag.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                DisplayGroupCard(ag.GroupName, ag.ContactCard);
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                //cancelled
            }
            ag.Dispose();
        }

        //add groups as indicated in the AddGroup dialog, and send to our groups singleton for creation
        //this is all very similar to adding contacts, but some data is handled directly in the groups singleton
        public void DisplayGroupCard(string groupName, List<ContactBasic> contactCards)
        {
            BasicGroup group;

            group = abg.AddGroup(groupName, contactCards, GroupID, CardStartPos, CardPos);

            GroupID = Convert.ToInt32(group.GroupID);
            CardPos = group.Top;

            pnlGroups.Controls.Add(group);

            CardPos += CardHeight;
        }

        private void txtSearchGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                List<BasicGroup> searchedGroupCard = new List<BasicGroup>();

                var searched = abg.GroupCards.Select(g => g);

                if (!String.IsNullOrWhiteSpace(txtSearchGroup.Text))
                {
                    SearchedCardPos = CardStartPos;
                    searched = abg.SearchGroup(txtSearchGroup.Text);    //send to our singleton class to search the criteria entered by user

                    searchedGroupCard = searched.ToList();

                    foreach (var g in abg.GroupCards)
                    {
                        pnlGroups.Controls.Remove(g);   //remove every GroupCard currently visible to user
                    }

                    foreach (var g in searchedGroupCard.Distinct())
                    {
                        //make first group in our search list the currently visible group (All Contacts)
                        if (g == searchedGroupCard.First())
                        {
                            abg.CurrentGroupShowing = g.GroupID;
                            abg.GroupChanged = true;
                        }
                        //add searched group to panel and increment positioning
                        g.Top = SearchedCardPos;
                        pnlGroups.Controls.Add(g);
                        SearchedCardPos += CardHeight;
                    }
                }
                else   //if search is implenty then show all cards in the singletons list
                {
                    CardPos = CardStartPos;
                    foreach (var g in abg.GroupCards)
                    {
                        if (g == abg.GroupCards.First())
                        {
                            abg.CurrentGroupShowing = g.GroupID;
                            abg.GroupChanged = true;
                        }
                        g.Top = CardPos;
                        pnlGroups.Controls.Add(g);
                        CardPos += CardHeight;
                    }
                }

                SearchedCardPos = CardStartPos;
            }
        }

        public void WhichGroupClicked()
        {
            //show which group is clicked by checking groups singletons variable and change colors
            //as needed to indicate to user the group has been clicked
            foreach (var g in abg.GroupCards)
            {
                if (g.GroupID == abg.CurrentGroupShowing)
                {
                    g.BackColor = Color.DarkBlue;
                    g.ForeColor = Color.AliceBlue;
                }
                else
                {
                    g.BackColor = SystemColors.GradientInactiveCaption;
                    g.ForeColor = Color.Black;
                }
            }

            //display the ContactCards that correspond with that group
            foreach (var c in abc.ContactCards)
            {
                foreach (var g in abg.GroupList)
                {
                    foreach (var con in g.ContactCards)
                    {
                        if (con.ContactID == c.ContactID)
                        {
                            con.ProfilePic = c.ProfilePic;
                            con.PictureAdded = c.PictureAdded;
                        }
                    }
                }
            }

        }

        //this checks for user deleted data and removes the GroupCard as needed
        public void CheckForDeletedData()
        {
            bool deletedSuccessful = false;
            int deletedCount = 0;

            foreach (var g in abg.GroupCards)
            {
                if (g.GroupID == abg.DeletedGroupID)
                {

                    pnlGroups.Controls.Remove(g);
                    deletedSuccessful = true;
                    deletedCount++;
                }

                if (deletedSuccessful)
                {
                    g.Top -= CardHeight;
                }
            }

            if (deletedSuccessful)
            {
                abg.GroupCards.RemoveAll(g => g.GroupID == abg.DeletedGroupID);
            }

            abg.DeletedGroupID = "0";

            deletedCount *= CardHeight;
            CardPos -= deletedCount;
            SearchedCardPos -= deletedCount;
        }

        //gets result of the EditGroup dialog
        private void btnEditGroups_Click(object sender, System.EventArgs e)
        {
            EditGroup eg = new EditGroup();
            DialogResult dialogResult = eg.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                abg.EditGroup(eg.GroupName, eg.ContactCard);
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                //cancelled
            }
            eg.Dispose();
        }

        //check for database load variable set to true in groups singleton constructor, and load groups and their contact cards
        public void CheckForDatabaseLoad()
        {
            if (abg.DatabaseLoaded)
            {
                DisplayGroupCard("All Contacts", abc.ContactCards);
                abg.db.GetGroupData();
                abg.db.GetGroupsContactData();
                abg.DatabaseList = abg.db.GroupList;
                foreach (var g in abg.DatabaseList)
                {
                    GroupID = g.GroupID - 1;    //to ensure we are always using GroupID's that match with the database, minus 1 because we add to it in AddGroup function.
                    DisplayGroupCard(g.GroupName, g.ContactCards);
                }
                abg.CurrentGroupShowing = "1";
            }

            abg.DatabaseLoaded = false;
        }

        //since we hadn't learned data binding when I created the bulk of this application, I used timers to
        //check if a variety of actions have occured, and this is what this is for.
        //the names of the functions should identify what the timer is trying to do
        private void checkForGroups_Tick(object sender, System.EventArgs e)
        {
            if (abg.GroupsVisible)
            {
                pnlGroups.Visible = true;
                WhichGroupClicked();
                CheckForDeletedData();
                CheckForDatabaseLoad();

                if (abg.CurrentGroupShowing == "1")
                {
                    btnEditGroups.Visible = false;
                }
                else
                {
                    btnEditGroups.Visible = true;
                }
            }
            else
            {
                pnlGroups.Visible = false;
            }
        }
    }
}
