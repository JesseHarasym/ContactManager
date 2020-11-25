using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace AddressBookProject.Classes
{
    public class ConnectContactDB
    {
        public List<Contacts> ContactList = new List<Contacts>();

        string connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\JGHAR\SOURCE\REPOS\ADDRESSBOOKPROJECT\ADDRESSBOOKPROJECT\DATABASE\ADDRESSBOOKDB.MDF;Integrated Security=True";

        public void GetContactData()
        {
            DataSet dataset = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(
                    "SELECT * FROM Contacts", connection);
                adapter.Fill(dataset, "contacts");

                DataTable dtable = dataset.Tables["contacts"];
                ContactList.Clear();

                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    DataRow drow = dtable.Rows[i];
                    string contactID = (drow["ContactID"].ToString());
                    string firstName = (drow["FirstName"].ToString());
                    string lastName = (drow["LastName"].ToString());
                    string phoneNumber = (drow["PhoneNumber"].ToString());
                    string address = (drow["Address"].ToString());
                    string email = (drow["Email"].ToString());

                    PictureBox profilePic = new PictureBox();
                    profilePic.ImageLocation = null;

                    if (drow["ProfilePicture"] != System.DBNull.Value)
                    {
                        byte[] photo_aray = (byte[])drow["ProfilePicture"];
                        MemoryStream ms = new MemoryStream(photo_aray);
                        profilePic.Image = Image.FromStream(ms);
                    }

                    string picAdded = (drow["PictureAdded"].ToString());

                    ContactList.Add(new Contacts()
                    {
                        ProfilePic = profilePic,
                        ContactID = Convert.ToInt32(contactID),
                        FirstName = firstName,
                        LastName = lastName,
                        Address = address,
                        Email = email,
                        PhoneNumber = phoneNumber,
                        PictureAdded = Convert.ToBoolean(picAdded)
                    });
                }
            }
        }

        public void AddContactData(PictureBox profilePic, int contactID, string firstName, string lastName, string phoneNumber, string address, string email, bool picAdded)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd =
                    new SqlCommand($"INSERT INTO Contacts " +
                                   $"VALUES (@ci, @fn, @ln, @pn, @ad, @em, @pic, @picAdd)", connection))
                {
                    cmd.Parameters.AddWithValue("@ci", contactID);
                    cmd.Parameters.AddWithValue("@fn", firstName);
                    cmd.Parameters.AddWithValue("@ln", lastName);
                    cmd.Parameters.AddWithValue("@pn", phoneNumber);
                    cmd.Parameters.AddWithValue("@ad", address);
                    cmd.Parameters.AddWithValue("@em", email);
                    byte[] photoArr = ConvertImageToBinary(profilePic);
                    cmd.Parameters.AddWithValue("@pic", photoArr);
                    cmd.Parameters.AddWithValue("@picAdd", picAdded);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void EditContactData(int contactID, string firstName, string lastName, string phoneNumber, string address, string email, PictureBox profilePic, bool picAdded)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd =
                    new SqlCommand($"UPDATE Contacts " +
                                   $"SET FirstName = @fn, LastName = @ln, PhoneNumber = @pn, Address = @ad, Email = @em, ProfilePicture = @pic, PictureAdded = @picAdd WHERE ContactID = {contactID}", connection))
                {
                    cmd.Parameters.AddWithValue("@fn", firstName);
                    cmd.Parameters.AddWithValue("@ln", lastName);
                    cmd.Parameters.AddWithValue("@pn", phoneNumber);
                    cmd.Parameters.AddWithValue("@ad", address);
                    cmd.Parameters.AddWithValue("@em", email);
                    byte[] photoArr = ConvertImageToBinary(profilePic);
                    cmd.Parameters.AddWithValue("@pic", photoArr);
                    cmd.Parameters.AddWithValue("@picAdd", picAdded);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void DeleteContactData(int contactID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd =
                    new SqlCommand($"DELETE FROM Contacts " +
                                   $"WHERE ContactID = {contactID}", connection))
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                using (SqlCommand cmd =
                    new SqlCommand($"DELETE FROM GroupsContacts " +
                                   $"WHERE ContactID = {contactID}", connection))
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public byte[] ConvertImageToBinary(PictureBox profilePic)
        {
            byte[] photoArr;
            if (profilePic.Image == null)
            {
                profilePic.Image = new Bitmap("C:\\Users\\jghar\\source\\repos\\AddressBookProject\\AddressBookProject\\Resources\\defaultProfile.png");
            }

            MemoryStream ms = new MemoryStream();
            profilePic.Image.Save(ms, ImageFormat.Jpeg);
            photoArr = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(photoArr, 0, photoArr.Length);

            return photoArr;
        }
    }
}
