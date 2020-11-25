using System.Collections.Generic;

namespace AddressBookProject.Classes
{
    class ConnectDatabase
    {
        public List<Contacts> ContactList = new List<Contacts>();
        public void GetContactData()
        {
            //string connectionString;
            //SqlConnection connection;
            //connectionString =
            //    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jghar\source\repos\AddressBookProject\AddressBookProject\Database\AddressBookDB.mdf;Integrated Security=True";
            //connection = new SqlConnection(connectionString);
            //connection.Open();

            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Contacts", con))
            //    {
            //        using (SqlDataReader sdr = cmd.ExecuteReader())
            //        {
            //            sdr.Read();
            //            int contactID = Convert.ToInt32(sdr["ContactID"]);
            //            string firstName = sdr["FirstName"].ToString();
            //            string lastName = sdr["LastName"].ToString();
            //            string phoneNumber = sdr["PhoneNumber"].ToString();
            //            string address = sdr["Address"].ToString();
            //            string email = sdr["Email"].ToString();
            //            //Console.WriteLine(firstName);
            //        }
            //    }
            //    connection.Close();
            //}
        }
    }
}
