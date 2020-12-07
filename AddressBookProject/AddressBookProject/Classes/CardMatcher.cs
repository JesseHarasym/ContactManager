using AddressBookProject.Classes;

namespace AddressBookProject
{
    class CardMatcher
    {
        //just matches the id with it's group name when creating their card
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
