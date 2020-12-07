using System.ComponentModel;
using System.Windows.Forms;

namespace AddressBookProject
{
    //base class for our AllContacts list in our AddressBookContacts singleton
    public class Contacts : INotifyPropertyChanged  //this is used for our data binding
    {
        //private variables needed to use the properties get;set; needed for data binding with INotifyPropertyChanged
        private PictureBox _profilePic;
        private int _contactID;
        private string _firstName;
        private string _lastName;
        private string _fullName;
        private string _phoneNumber;
        private string _address;
        private string _email;
        private bool _picAdded;

        //event handler for when a property is changed to notify properties it's bound with
        public event PropertyChangedEventHandler PropertyChanged;

        //all the properties for the Contacts class and their needed get; set; methods for INotifyPropertyChanged
        //the basic layout is explained in the ProfilePic property, and the rest are essentially identical to this set up.
        public PictureBox ProfilePic
        {
            get
            {
                return _profilePic; //return currently stored variable
            }
            set
            {
                if (value != _profilePic)   //if the set value is not the value currently stored
                {
                    _profilePic = value;    //update value
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProfilePic"));  //notify bound properties of it's change
                }
            }
        }
        public int ContactID
        {
            get
            {
                return _contactID;
            }
            set
            {
                if (value != _contactID)
                {
                    _contactID = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ContactID"));
                }
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FirstName"));
                }
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastName"));
                }
            }
        }
        public string FullName
        {
            get
            {
                return _firstName + " " + _lastName;
            }
            set
            {
                if (value != _fullName)
                {
                    _fullName = _firstName + _lastName;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FullName"));
                }
            }
        }
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if (value != _phoneNumber)
                {
                    _phoneNumber = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PhoneNumber"));
                }
            }
        }
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                if (value != _address)
                {
                    _address = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Address"));
                }
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Email"));
                }
            }
        }
        public bool PictureAdded
        {
            get
            {
                return _picAdded;
            }
            set
            {
                if (value != _picAdded)
                {
                    _picAdded = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PictureAdded"));
                }
            }
        }


        public Contacts()
        {
            //setup for FullName since some of the classes will use that instead of first and last
            FullName = FirstName + " " + LastName;
        }
    }
}
