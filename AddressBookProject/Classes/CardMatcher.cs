using AddressBookProject.Classes;

namespace AddressBookProject
{
    class CardMatcher
    {
        public string MatchContactID(int id)
        {

            string fullName = "Default";

            foreach (var c in AddressBookContacts.Instance.ContactList)
            {
                if (c.ContactID == id)
                {
                    fullName = c.FirstName + " " + c.LastName;
                }
            }
            return fullName;
        }
        public string MatchGroupID(int id)
        {
            string groupName = "Default";

            foreach (var g in AddressBookGroups.Instance.GroupList)
            {
                if (g.GroupID == id)
                {
                    groupName = g.GroupName;
                }
            }
            return groupName;
        }
    }
}
