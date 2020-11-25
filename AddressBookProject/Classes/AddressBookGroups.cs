using AddressBookProject.Components.Helper_Components;
using AddressBookProject.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookProject.Classes
{
    //Singleton class
    public sealed class AddressBookGroups
    {
        private AddressBookGroups()
        {
            DatabaseLoaded = true;
        }
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
        public string CurrentGroupShowing { get; set; } = "1";
        public string DeletedGroupID { get; set; }
        public bool GroupsVisible { get; set; }
        public bool GroupChanged { get; set; }
        public bool DatabaseLoaded { get; set; }

        public BasicGroup AddGroup(string groupName, List<ContactBasic> contactCards, int groupID, int cardStartPos, int cardPos)
        {
            groupID++;

            GroupList.Add(new Groups()
            {
                GroupID = groupID,
                GroupName = groupName,
                ContactCards = contactCards
            });

            if (DatabaseLoaded == false)
            {
                if (groupID != 1)
                {
                    db.AddGroupData(groupName, contactCards, groupID);
                }
            }

            BasicGroup group = AddGroupCard(groupID, cardStartPos, cardPos);

            CurrentGroupShowing = Convert.ToString(groupID);
            GroupChanged = true;

            return group;
        }

        public BasicGroup AddGroupCard(int groupID, int cardStartPos, int cardPos)
        {
            int left = 1;

            BasicGroup group = new BasicGroup();

            if (groupID == 1)
            {
                group.HideDeleteBtn();
                cardPos += cardStartPos;
            }

            group.Left = left;
            group.Top = cardPos;
            group.Name = "group" + groupID;

            var matcher = new CardMatcher();
            string groupName = matcher.MatchGroupID(groupID);

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
                    AddressBookContacts.Instance.CurrentContactShowing = GroupList[i].ContactCards.First().ContactID;
                }
            }
            db.DeleteGroupData(id);
            db.DeleteGroupCardData(id);     //must delete group cards first because their dependent on group data (with a fk)

            DeletedGroupID = Convert.ToString(id);
            GroupChanged = true;
        }

        public void EditGroup(string groupName, List<ContactBasic> contactCards)
        {
            int i = GroupList.FindIndex(g => g.GroupID.ToString() == CurrentGroupShowing);

            GroupList[i].GroupName = groupName;
            GroupList[i].ContactCards = contactCards;
            int groupID = GroupList[i].GroupID;

            db.EditGroupNameData(groupID, groupName, contactCards);
            db.DeleteGroupCardData(groupID);
            db.AddGroupCardData(groupID, contactCards);
            EditGroupCard(groupName);

            GroupChanged = true;
        }

        public void EditGroupCard(string groupName)
        {
            int i = GroupCards.FindIndex(g => g.GroupID == CurrentGroupShowing);
            GroupCards[i].GroupName = groupName;
        }

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
