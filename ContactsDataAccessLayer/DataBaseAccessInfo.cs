using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDataAccessLayer
{
    internal class DataBaseAccessInfo
    {
        public static string connectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=sa123456;";
    }
}
