using AddressBookProject.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AddressBookProject.Database
{
    public class ConnectGroupDB
    {
        public List<Groups> GroupList = new List<Groups>();

        private string connectionString = ConnectionString.connectionString;

        public void GetGroupData()
        {
            DataSet dataset = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(
                    "SELECT * FROM Groups", connection);
                adapter.Fill(dataset, "groups");

                DataTable gtable = dataset.Tables["groups"];
                GroupList.Clear();

                for (int i = 0; i < gtable.Rows.Count; i++)
                {
                    DataRow drow = gtable.Rows[i];
                    string groupID = (drow["GroupID"].ToString());
                    string groupName = (drow["GroupName"].ToString());

                    GroupList.Add(new Groups()
                    {
                        GroupID = Convert.ToInt32(groupID),
                        GroupName = groupName
                    });
                }
            }
        }

        public void GetGroupsContactData()
        {
            DataSet dataset = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("SELECT * FROM dbo.GroupsContacts", connection);
                adapter.Fill(dataset, "groupsContacts");

                DataTable ctable = dataset.Tables["groupsContacts"];

                for (int i = 0; i < ctable.Rows.Count; i++)
                {
                    DataRow drow = ctable.Rows[i];
                    string groupID = (drow["GroupID"].ToString());
                    string contactID = (drow["ContactID"].ToString());
                    string contactName = (drow["ContactName"].ToString());


                    foreach (var g in GroupList)
                    {
                        if (g.GroupID.ToString() == groupID)
                        {
                            g.ContactCards.Add(new ContactBasic()
                            {
                                ContactID = contactID,
                                ContactName = contactName
                            });
                        }
                    }
                }
            }
        }

        public void AddGroupData(string groupName, List<ContactBasic> contactCards, int groupID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd =
                    new SqlCommand($"INSERT INTO Groups " +
                                   $"VALUES (@gi, @gn)", connection))
                {
                    cmd.Parameters.AddWithValue("@gi", groupID);
                    cmd.Parameters.AddWithValue("@gn", groupName);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }

            AddGroupCardData(groupID, contactCards);
        }

        public void AddGroupCardData(int groupID, List<ContactBasic> contactCards)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                foreach (var c in contactCards.Distinct())
                {
                    using (SqlCommand cmd = new SqlCommand($"INSERT INTO GroupsContacts VALUES (@gi, @ci, @cn)",
                        connection))
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@gi", groupID);
                        cmd.Parameters.AddWithValue("@ci", Convert.ToInt32(c.ContactID));
                        cmd.Parameters.AddWithValue("@cn", c.ContactName);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
        }

        public void EditGroupNameData(int groupID, string groupName, List<ContactBasic> contactCards)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd =
                    new SqlCommand($"UPDATE Groups " +
                                   $"SET GroupName = @gn WHERE GroupID = {groupID}", connection))
                {
                    cmd.Parameters.AddWithValue("@gn", groupName);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void DeleteGroupData(int groupID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd =
                    new SqlCommand($"DELETE FROM Groups " +
                                   $"WHERE GroupID = {groupID}", connection))
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void DeleteGroupCardData(int groupID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd =
                    new SqlCommand($"DELETE FROM GroupsContacts " +
                                   $"WHERE GroupID = {groupID}", connection))
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void EditGroupContactCard(string contactID, string fullName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd =
                    new SqlCommand($"UPDATE GroupsContacts " +
                                   $"SET ContactName = @fn WHERE ContactID = {contactID}",
                        connection))
                {
                    cmd.Parameters.AddWithValue("@fn", fullName);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
