using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using ErrorLogger;

namespace DAL
{
    public class clsDBConnection
    {
        public SqlConnection connection;

        string methodName;

        /// <summary>
        /// Method for connecting to the DB
        /// </summary>
        public clsDBConnection()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                this.connection = new SqlConnection(connectionString);
            }

            catch (Exception ex)
            {
                clsErrorLogger objError = new clsErrorLogger();
                objError.LogErrorInFile("Exception(" + methodName + ") Common: {0}", ex.Message.ToString(), 0);
            }
        }
    }
}
