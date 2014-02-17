/* 
 The purpose of this class is to carry out database activity like
 * Select, Update and Delete querys to the database. It can also check 
 * if the database connection is open or not
 * if the database connection is not open 
 * then it will open the connection and perform the database query
 * the database results are to be recevived and being passed to 
 * data table in this class.
 * This class takes the database setting from the app.config file so it's flexible to maange
 * database settings
 */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace eBarSystemsSolution
{
    public class dbConnection
    {
        private SqlDataAdapter dbAdapter;
        private SqlConnection dbConn;

        /// <constructor>
        /// Initialise Connection
        /// </constructor>
        public dbConnection()
        {
            dbAdapter = new SqlDataAdapter();
            dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseInfo"].ConnectionString);
        }

        /// <method>
        /// Open Database Connection if Closed or Broekn
        /// </method>
        private SqlConnection openConnection()
        {
            if (dbConn.State == ConnectionState.Closed || dbConn.State == ConnectionState.Broken)
            {
                dbConn.Open();
            }
            return dbConn;
        }

        /// <method>
        /// Select Query
        /// </method>
        /// <param name="_query"></param>
        /// <param name="sqlParameter"></param>
        /// <returns></returns>
        public DataTable executeSelectQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand dbCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            dataTable = null;
            DataSet ds = new DataSet();

            try
            {
                dbCommand.Connection = openConnection();
                dbCommand.CommandText = _query;
                dbCommand.Parameters.AddRange(sqlParameter);
                dbCommand.ExecuteNonQuery();

                dbAdapter.SelectCommand = dbCommand;
                dbAdapter.Fill(ds);

                dataTable = ds.Tables[0];
            }
            catch (SqlException e)
            {
                Debug.Write("Error - Connection.executeSelectQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                return null;
            }
            finally
            {

            }
            return dataTable;
        }

        /// <summary>
        /// Insert Query
        /// </summary>
        /// <param name="_query"></param>
        /// <param name="sqlParameter"></param>
        /// <returns>True or false depending on success</returns>
        public bool executeInsertQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand dbCommand = new SqlCommand();

            try
            {
                dbCommand.Connection = openConnection();
                dbCommand.CommandText = _query;
                dbCommand.Parameters.AddRange(sqlParameter);

                dbAdapter.InsertCommand = dbCommand;
                dbCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Debug.Write("Error - Connection.executeInsertQuery - Query: " + _query + " \nException: \n" + e.StackTrace.ToString());
                return false;
            }
            finally
            {

            }
            return true;
        }

        /// <summary>
        /// Update Query
        /// </summary>
        /// <param name="_query"></param>
        /// <param name="sqlParameter"></param>
        /// <returns>True or false depending on success</returns>
        public bool executeUpdateQuery(string _query, SqlParameter[] sqlParameter)
        {
            SqlCommand dbCommand = new SqlCommand();

            try
            {
                dbCommand.Connection = openConnection();
                dbCommand.CommandText = _query;
                dbCommand.Parameters.AddRange(sqlParameter);

                dbAdapter.UpdateCommand = dbCommand;
                dbCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeUpdateQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                return false;
            }
            finally { }
            return true;

        }
    }
}
