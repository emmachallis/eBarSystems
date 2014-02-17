/****************************************************************************************** 
                        eBar Systems Data Grabber Service Console
 
 * The purpose of the console is exactly the same as the eBar Systems Data Grabber Service
 * The console allows code to be tested prior to adding this code to the service
 * If you edit the service directly, please also add the code in this project and vice versa
 
******************************************************************************************/
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
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;

namespace eBarSystemsDataGrabberServiceConsole
{
    class Program
    {
        static Timer getDataTimer = new Timer();
        static SqlConnection databaseConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseInfo"].ConnectionString);
        static SqlCommand sqlCommand = new SqlCommand();
        static Queue temporaryDataQueue = new Queue();
        static List<string> comparisonList = new List<string>();
        static Regex regularExpression = new Regex(@"<tag\>(.*?)</tag\>");
        static string userIDString, timeString, dateString, webString;
        static int pumpID;
        static WebClient client = new WebClient();
        static bool executionComplete;

        static void Main(string[] args)
        {
            TestDatabaseConnection();
            CreateTimer();
            executionComplete = true;

            Console.ReadKey();
        }

        private static void TestDatabaseConnection()
        {
            try
            {
                databaseConnection.Open();
                Console.WriteLine("Database connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Database connection failed: " + e);
            }

            databaseConnection.Close();
        }

        private static void CreateTimer()
        {
            getDataTimer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            int interval = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["getDataInterval"]);
            getDataTimer.Interval = interval;

            //Start the timer
            getDataTimer.Enabled = true;
        }


        private static void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("OnElapsedTime method entered");
            
            //if the execution has complete then execute following code
            if (executionComplete)
            {
                Console.WriteLine("Execution beginning...");
                
                //set the execution to not complete
                executionComplete = false;

                //download the webpage and store it in variable
                webString = client.DownloadString(ConfigurationManager.AppSettings["webServerUrl"]);
                Console.WriteLine("Web page downloaded");

                //check through the webpage for any matches matching the regex and store the matches in a collection
                MatchCollection matches = regularExpression.Matches(webString);

                //go through each of the matches
                foreach (Match match in matches)
                {
                    //add the match to the queue
                    temporaryDataQueue.Enqueue(match.Groups[1].Value);
                    Console.WriteLine("adding matches to queue");
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
                        Console.WriteLine("Comparing match to list");
                    }
                }

                //move onto the split string method to store the data
                SplitString();
            }
        }

        private static void SplitString()
        {
            Console.WriteLine("Entered splitString method");

            //iterate through the list
            foreach (string item in comparisonList)
            {
                //split the string
                string[] words = item.Split(' ');

                //store different parts of the string in appropriate variables
                int.TryParse(words[3], out pumpID);
                userIDString = words[6];
                //dateString = words[7];
                //timeString = words[8];

                //convert the time to SQL format
                DateTime time = Convert.ToDateTime(timeString);
                timeString = time.ToString("HH:mm:ss");

                //convert the date to SQL format
                DateTime date = Convert.ToDateTime(dateString);
                dateString = date.ToString("yyyy/M/d");

                WriteToDatabase();
                executionComplete = true;

                /*
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
                }*/
            }
        }

        private static bool RecordExists(ref SqlConnection sqlConnection, string sqlQuery)
        {
            Console.WriteLine("Entered RecordExists method");
            SqlDataReader sqlDataReader = null;

            //open the database connection
            databaseConnection.Open();

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
                Console.WriteLine("Record found");

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

        private static void WriteToDatabase()
        {
            Console.WriteLine("Entered WriteToDatabase method");

            //the sql command will be generated from a stored procedure
            sqlCommand.CommandType = CommandType.StoredProcedure;

            //the stored procedure is called dbo.Save
            sqlCommand.CommandText = "dbo.Save";

            sqlCommand.Parameters.Add("@PumpNumber", SqlDbType.Int).Value = pumpID;
            sqlCommand.Parameters.Add("@UserNumber", SqlDbType.VarChar).Value = userIDString;
            //sqlCommand.Parameters.Add("@Date", SqlDbType.Date).Value = dateString;
            //sqlCommand.Parameters.Add("@time", SqlDbType.Time).Value = timeString;

            sqlCommand.Connection = databaseConnection;

            try
            {
                databaseConnection.Open();
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
    }
}
