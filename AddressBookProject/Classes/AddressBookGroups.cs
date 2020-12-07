using AddressBookProject.Components.Helper_Components;
using AddressBookProject.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookProject.Classes
{
    //This is a singleton class that handles the data related to groups in the AddressBook application.
    public sealed class AddressBookGroups
    {
        private AddressBookGroups()
        {
        }
        //creation of single instance of class for our groups singleton
        private static readonly object padlock = new object();
        private static AddressBookGroups instance = null;
        public static AddressBookGroups Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new AddressBookGroups();
                    }
                    return instance;
                }
            }
        }

        public ConnectGroupDB db = new ConnectGroupDB();
        public List<Groups> GroupList = new List<Groups>();
        public List<Groups> DatabaseList = new List<Groups>();
        public List<BasicGroup> GroupCards = new List<BasicGroup>();
        public string CurrentGroupShowing { get; set; } = "1";  //indicate which group showing (default is All Contacts)
        public string DeletedGroupID { get; set; }  //tracks which group was deleted last
        public bool GroupsVisible { get; set; }     //tracks which group is currently visible
        public bool GroupChanged { get; set; }      //tracks if a group has been changed
        public bool DatabaseLoaded { get; set; }    //tracks if the database is being loaded

        public BasicGroup AddGroup(string groupName, List<ContactBasic> contactCards, int groupID, int cardStartPos, int cardPos)
        {
            groupID++;

            GroupList.Add(new Groups()
            {
                GroupID = groupID,
                GroupName = groupName,
                ContactCards = contactCards
            });

            //only write to database if this isn't the database being loaded
            if (DatabaseLoaded == false)
            {
                if (groupID != 1)   //and if it isn't the AllContact group
                {
                    db.AddGroupData(groupName, contactCards, groupID);
                }
            }

            BasicGroup group = AddGroupCard(groupID, cardStartPos, cardPos);    //create group cards

            CurrentGroupShowing = Convert.ToString(groupID);    //make first contact remaining in list the current contact shown (don't need to check for Any(), as there is always 1 group (All Contacts)

            GroupChanged = true;//indicates that the groups need to be reloaded

            return group;
        }

        public BasicGroup AddGroupCard(int groupID, int cardStartPos, int cardPos)
        {
            //basic card creation of position, id, etc
            BasicGroup group = new BasicGroup();

            //hide the delete button if its All Contact group (which is not treated like a real group in the application)
            if (groupID == 1)
            {
                group.HideDeleteBtn();
                cardPos += cardStartPos;
            }

            group.Left = 1;
            group.Top = cardPos;
            group.Name = "group" + groupID;

            var matcher = new CardMatcher();
            string groupName = matcher.MatchGroupID(groupID);

            //groups aren't data bound so their information has to be set to
            //the BasicGroup properties manually
            group.SetGroupInfo(groupID.ToString(), groupName);

            CurrentGroupShowing = groupID.ToString();

            GroupCards.Add(group);

            return group;
        }

        public void RemoveGroup(int id)
        {
            GroupList.RemoveAll(g => g.GroupID == id);
            DatabaseList.RemoveAll(g => g.GroupID == id);

            if (GroupList.Any())
            {
                CurrentGroupShowing = "1";

                for (int i = 0; i < 1; i++)
                {
                    //make first contact in AllContacts the shown contact if the group is deleted
                    //**need to be made to handle if no contacts are available (every contact deleted)
                    AddressBookContacts.Instance.CurrentContactShowing = GroupList[i].ContactCards.First().ContactID;
                }
            }

            //delete the group from database, and the groups contact cards associated with it (separate tables)
            db.DeleteGroupData(id);
            db.DeleteGroupCardData(id);

            DeletedGroupID = Convert.ToString(id);
            GroupChanged = true;
        }

        public void EditGroup(string groupName, List<ContactBasic> contactCards)
        {
            //find index of current group showing (which has to be the one that's being edited)
            //and change replace all the old data with the new user indicated data
            int i = GroupList.FindIndex(g => g.GroupID.ToString() == CurrentGroupShowing);

            GroupList[i].GroupName = groupName;
            GroupList[i].ContactCards = contactCards;
            int groupID = GroupList[i].GroupID;

            //edit the databases group table, delete the old groups contact cards and add their new contact cards 
            db.EditGroupNameData(groupID, groupName, contactCards);
            db.DeleteGroupCardData(groupID);
            db.AddGroupCardData(groupID, contactCards);
            EditGroupCard(groupName);

            GroupChanged = true;    //this acts as refresh to reload the new data to the user
        }

        public void EditGroupCard(string groupName)
        {
            //edit the cards currently showing 
            int i = GroupCards.FindIndex(g => g.GroupID == CurrentGroupShowing);
            GroupCards[i].GroupName = groupName;
        }

        //this is just the base of our group search function, the remaining is done in AllGroups class 
        //because everything else is related directly to the cards shown in the gui
        public IEnumerable<BasicGroup> SearchGroup(string searchCriteria)
        {
            var searched =
                from c in GroupCards
                where c.GroupName.ToLower().Contains(searchCriteria.ToLower())
                select c;

            return searched;
        }
    }
}
