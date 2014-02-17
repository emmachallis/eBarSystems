using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace eBarSystemsSolution
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            LogOut();
        }

        private void LogOut()
        {
            using (SqlConnection databaseConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseInfo"].ConnectionString))
            using (SqlCommand command = databaseConnection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UserLogOut";

                command.Parameters.Add("@ID", SqlDbType.VarChar).Value = LoginForm.primaryKey;
                command.Parameters.Add("@LogOff", SqlDbType.DateTime).Value = DateTime.Now.ToString();

                command.Connection = databaseConnection;

                //open the database connection for writing
                databaseConnection.Open();

                //update the row in the database
                command.ExecuteNonQuery();

                //Clear the parameters for next time
                command.Parameters.Clear();

                //Close the connection
                databaseConnection.Close();
            }
            eBarDataViewSystem.ActiveForm.Close();
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            //LogScreen logScreen = new LogScreen();
            //logScreen.Show();
            //logScreen.Focus();
            //this.Hide();

            eBarDataViewSystem userForm = new eBarDataViewSystem();
            userForm.Show();
            userForm.Focus();
            this.Hide();
        }
    }
}
