namespace AddressBookProject.Database
{
    //just a static class so connection string only has to be made once to be used in multiple classes
    static class ConnectionString
    {
        public static string connectionString =
            "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jghar\\source\\repos\\ContactManager\\AddressBookProject\\bin\\Debug\\Database\\AddressBookDB.mdf;Integrated Security=True;Connect Timeout=30";

        //No idea why, but using this instead of manual connection string breaks the MainForm designer?
        //public static string connectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
    }
}
