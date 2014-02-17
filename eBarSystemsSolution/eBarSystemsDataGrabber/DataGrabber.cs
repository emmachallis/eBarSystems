using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;

namespace eBarSystemsDataGrabber
{
    public partial class DataGrabber : ServiceBase
    {
        Timer getDataTimer = new Timer();
        SqlConnection databaseConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseInfo"].ConnectionString);
        SqlCommand sqlCommand = new SqlCommand();
        Queue temporaryDataQueue = new Queue();
        List<string> comparisonList = new List<string>();
        Regex regularExpression = new Regex(@"<tag\>(.*?)</tag\>");
        string userIDString, timeString, dateString, webString;
        int pumpID;
        WebClient client = new WebClient();
        bool executionComplete;

        //This method is executed once at startup
        public DataGrabber()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            CheckEventLog();
            CreateTimer();
            TestDatabaseConnection();

            getDataTimer.Enabled = true;
        }

        private void CheckEventLog()
        {
            Debug.WriteLine("Checking for event log...");

            //If the eBar Systems event log does not exist
            if (!System.Diagnostics.EventLog.SourceExists("eBar Systems"))
            {
                try
                {   //try to create the event log
                    System.Diagnostics.EventLog.CreateEventSource("eBar Systems", "Data Grabber Service");
                }
                catch (Exception e)
                {   //if it fails, output the error 
                    Debug.WriteLine(e);
                }
            }
            //if the eBar Systems event log does exist
            else
            {   //Set the source and the log 
                evntLog.Source = "eBar Systems";
                evntLog.Log = "Data Grabber Service";
            }
        }

        private void CreateTimer()
        {
            getDataTimer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            int interval = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["getDataInterval"]);
            getDataTimer.Interval = interval;
        }

        private void TestDatabaseConnection()
        {
            try
            {
                databaseConnection.Open();
                evntLog.WriteEntry("DATABASE CONNECTION SUCCESSFUL");
            }
            catch (Exception e)
            {
                evntLog.WriteEntry("DATABASE CONNECTION FAILED: " + e);
            }

            databaseConnection.Close();
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            //if the execution has complete then execute following code
            if (executionComplete)
            {
                //set the execution to not complete
                executionComplete = false;

                //download the webpage and store it in variable
                webString = client.DownloadString(ConfigurationManager.AppSettings["webServerUrl"]);

                //check through the webpage for any matches matching the regex and store the matches in a collection
                MatchCollection matches = regularExpression.Matches(webString);

                //go through each of the matches
                foreach (Match match in matches)
                {
                    //add the match to the queue
                    temporaryDataQueue.Enqueue(match.Groups[1].Value);
                }

                //while there is data in the queue
                while (temporaryDataQueue.Count > 0)
                {
                    //take the first item off the queue
                    string str = (string)temporaryDataQueue.Dequeue();

                    //check if the item is already in the list
                    bool listCheck = comparisonList.Any(str.Equals);

                    //if it's not in the list
                    if (listCheck == false)
                    {
                        //add the string to the list
                        comparisonList.Add(str);
                    }
                }

                //move onto the split string method to store the data
                SplitString();
            }
        }

        private void SplitString()
        {
            //iterate through the list
            foreach (string item in comparisonList)
            {
                //split the string
                string[] words = item.Split(' ');

                //store different parts of the string in appropriate variables
                int.TryParse(words[3], out pumpID);
                userIDString = words[6];
                dateString = words[7];
                timeString = words[8];

                //convert the time to SQL format
                DateTime time = Convert.ToDateTime(timeString);
                timeString = time.ToString("HH:mm:ss");

                //convert the date to SQL format
                DateTime date = Convert.ToDateTime(dateString);
                dateString = date.ToString("yyyy/M/d");

                //open the database connection
                databaseConnection.Open();

                if (RecordExists(ref databaseConnection, "SELECT * FROM Log Where Time = '" + timeString + "'"))
                {
                    //record is found, close the connection
                    databaseConnection.Close();
                    executionComplete = true;
                }
                else
                { 
                    //record not found in database, add record
                    WriteToDatabase();
                    executionComplete = true;
                }
            }
        }

        private static bool RecordExists(ref SqlConnection sqlConnection, string sqlQuery)
        {
            SqlDataReader sqlDataReader = null;

            try
            {
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

                sqlDataReader = sqlCommand.ExecuteReader();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }

            if (sqlDataReader != null && sqlDataReader.Read())
            {
                //close sql reader before exit
                if (sqlDataReader != null)
                {
                    sqlDataReader.Close();
                    sqlDataReader.Dispose();
                }

                return true;
            }
            else
            {
                if (sqlDataReader != null)
                {
                    sqlDataReader.Close();
                    sqlDataReader.Dispose();
                }

                return false;
            }
        }

        private void WriteToDatabase()
        {
            //the sql command will be generated from a stored procedure
            sqlCommand.CommandType = CommandType.StoredProcedure;

            //the stored procedure is called dbo.Save
            sqlCommand.CommandText = "dbo.Save";

            sqlCommand.Parameters.Add("@PumpNumber", SqlDbType.Int).Value = pumpID;
            sqlCommand.Parameters.Add("@UserNumber", SqlDbType.VarChar).Value = userIDString;
            sqlCommand.Parameters.Add("@Date", SqlDbType.Date).Value = dateString;
            sqlCommand.Parameters.Add("@time", SqlDbType.Time).Value = timeString;

            sqlCommand.Connection = databaseConnection;

            try
            {

                Console.WriteLine("Connection opened");
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Data insertion successful");
            }
            catch (Exception e)
            {
                Console.WriteLine("Data insertion failed: " + e);
            }
            finally
            {
                sqlCommand.Parameters.Clear();
                databaseConnection.Close();
                Console.WriteLine("Connection closed");
            }
        }

        protected override void OnStop()
        {
            getDataTimer.Enabled = false;
            evntLog.WriteEntry("Timer stopped succcessfully!");
            evntLog.WriteEntry("Database Grabber Service stopped successfully!");
        }
    }
}
