using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Diagnostics;

namespace eBarSystemsSolution
{
    public partial class LoginForm : Form
    {
        //Declaring variables that need to be used elsewhere
        public static string username;
        public static int primaryKey;
        private SqlConnection databaseConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseInfo"].ConnectionString);
        private SqlCommand sqlCommand = new SqlCommand();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Secure database connection
            using (SqlConnection databaseConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseInfo"].ConnectionString))
            using (SqlCommand command = databaseConnection.CreateCommand())
            {
                //We are using a stored procedure
                command.CommandType = CommandType.StoredProcedure;
                
                //the stored procedure name
                command.CommandText = "dbo.CheckUser";

                command.Parameters.Add("@username", SqlDbType.VarChar).Value = txtUsername.Text;
                command.Parameters.Add("@password", SqlDbType.VarChar).Value = txtPassword.Text;

                databaseConnection.Open();

                SqlDataReader reader = command.ExecuteReader();

                int count = 0;

                while (reader.Read())
                {
                    count = count + 1;
                }

                if (count == 1)
                {
                    username = txtUsername.Text;
                    LogIn();
                    //TillScreen TillScreen = new TillScreen();
                    //TillScreen.Show();
                    //TillScreen.Focus();
                    //this.Hide();
                    AdminPanel AdminPanel = new AdminPanel();
                    AdminPanel.Show();
                    AdminPanel.Focus();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username and password is incorrect!");
                }

                //Close the connection
                databaseConnection.Close();
            }
        }

        private void LogIn()
        {   
            //Secure database access
            using (SqlConnection databaseConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseInfo"].ConnectionString))
            using (SqlCommand command = databaseConnection.CreateCommand())
            {
                //We are using a stored procedure
                command.CommandType = CommandType.StoredProcedure;

                //The stored procedure name
                command.CommandText = "dbo.UserLogIn";

                //parameter used by stored procedure
                command.Parameters.Add("@UserID", SqlDbType.VarChar).Value = username;

                //parameter used by stored procedure
                command.Parameters.Add("@LogOn", SqlDbType.DateTime).Value = DateTime.Now.ToString();

                //the connection the command needs to use
                command.Connection = databaseConnection;

                //Open the database for data insertion
                databaseConnection.Open();

                //return the primary key to amend the row with logout information later
                primaryKey = (int)command.ExecuteScalar();

                //Clear the parameters for next time
                command.Parameters.Clear();

                //Close the connection
                databaseConnection.Close();
            }
        }
    }
}
