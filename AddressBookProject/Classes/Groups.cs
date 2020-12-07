using System.Collections.Generic;

namespace AddressBookProject.Classes
{
    public class Groups
    {
        //basic group class set up, since there was no data binding this one is simple and just used for instantiating to add to lists
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public List<ContactBasic> ContactCards = new List<ContactBasic>();
    }
}