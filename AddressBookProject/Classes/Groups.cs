using System.Collections.Generic;

namespace AddressBookProject.Classes
{
    public class Groups
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public List<ContactBasic> ContactCards = new List<ContactBasic>();
    }
}
