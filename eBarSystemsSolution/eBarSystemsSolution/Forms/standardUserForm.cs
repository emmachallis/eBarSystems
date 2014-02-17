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
using System.Diagnostics;

namespace eBarSystemsSolution
{
    public partial class eBarDataViewSystem : Form
    {
        private SqlConnection databaseConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseInfo"].ConnectionString);
        private SqlCommand sqlCommand = new SqlCommand();


        public eBarDataViewSystem()
        {
            InitializeComponent();
            PopulateUserComboBox();
            PopulatePumpComboBox();
            PopulateDataView();
        }

        private void PopulateDataView()
        {
            PopulateDataView("SELECT * FROM Log", databaseConnection);
        }

        private void PopulateUserComboBox()
        {
            databaseConnection.Open();

            sqlCommand = new SqlCommand("SELECT name FROM UserTable ORDER BY name", databaseConnection);
            SqlDataReader reader;
            reader = sqlCommand.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(string));
            dt.Load(reader);
            cboUser.DisplayMember = "name";
            cboUser.DataSource = dt;
            databaseConnection.Close();
        }

        private void PopulatePumpComboBox()
        {
            databaseConnection.Open();

            sqlCommand = new SqlCommand("SELECT PumpID FROM PumpTable ORDER BY PumpID", databaseConnection);
            SqlDataReader reader;
            reader = sqlCommand.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("PumpID", typeof(string));
            dt.Load(reader);
            cboPump.DisplayMember = "PumpID";
            cboPump.DataSource = dt;
            databaseConnection.Close();
        }

        //view logs for specific date and pump
        private void btnSearchPump_Click(object sender, EventArgs e)
        {
            string theDate = dTPicker.Value.ToString();

            DateTime date = Convert.ToDateTime(theDate);
            //theDate = date.ToString("yyyy/M/d");
            theDate = date.ToString("yyyy-MM-dd");
            var value = cboPump.SelectedValue;

            DataRow selectedDataRow = ((DataRowView)cboPump.SelectedItem).Row;
            int PumpID = Convert.ToInt32(selectedDataRow["PumpID"]);

            Debug.WriteLine(theDate);
            
            string strSQL = "SELECT * FROM Log WHERE PumpNumber = '" + PumpID + "' AND Date = '" + theDate + "'";

            PopulateDataView(strSQL, databaseConnection);
        }

        //View all logs for a specific date and user
        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            string theDate = dtPickerUser.Value.ToString();

            DateTime date = Convert.ToDateTime(theDate);

            //theDate = date.ToString("dd/MM/yyyy");
            theDate = date.ToString("yyyy-MM-dd");

            var value = cboUser.SelectedValue;

            DataRow selectedDataRow = ((DataRowView)cboUser.SelectedItem).Row;

            string selectedName = Convert.ToString(selectedDataRow["name"]);

            Debug.WriteLine(selectedName);

            string strSQL = "SELECT UserTable.UserID, Log.PumpNumber, Log.Date, Log.Time FROM UserTable, Log WHERE name = '" + selectedName + "' AND Date = '" + theDate + "'";

            PopulateDataView(strSQL, databaseConnection);

        }

        //View all logs for a specific date
        private void btnSearchDate_Click(object sender, EventArgs e)
        {
            string theDate = dTPickerDate.Value.ToString();

            DateTime date = Convert.ToDateTime(theDate);

            //theDate = date.ToString("dd/MM/yyyy");
            theDate = date.ToString("yyyy-MM-dd");

            string strSQL = "SELECT * FROM Log WHERE Date = '" + theDate + "' ORDER BY Time";

            PopulateDataView(strSQL, databaseConnection);
        }

        private void PopulateDataView(string strSQL, SqlConnection databaseConnection)
        {
            databaseConnection.Open();

            using (SqlDataAdapter a = new SqlDataAdapter(strSQL, databaseConnection))
            {
                DataTable t = new DataTable();
                a.Fill(t);
                dbGridView.DataSource = t;
            }
            databaseConnection.Close();
        }

        //View all logs regardless of date
        private void btnSearchAllDate_Click(object sender, EventArgs e)
        {
            string strSQL = "SELECT * FROM Log";
            PopulateDataView(strSQL, databaseConnection);
        }

        //View all logs for a specific pump
        private void btnSearchAllPump_Click(object sender, EventArgs e)
        {
            var value = cboPump.SelectedValue;

            DataRow selectedDataRow = ((DataRowView)cboPump.SelectedItem).Row;
            int PumpID = Convert.ToInt32(selectedDataRow["PumpID"]);

            string strSQL = "SELECT * FROM Log WHERE PumpNumber = '" + PumpID + "'";

            PopulateDataView(strSQL, databaseConnection);
        }

        //View all logs for a specific user
        private void btnSearchAllUser_Click(object sender, EventArgs e)
        {
            var value = cboUser.SelectedValue;

            DataRow selectedDataRow = ((DataRowView)cboUser.SelectedItem).Row;

            string selectedName = Convert.ToString(selectedDataRow["name"]);

            Debug.WriteLine(selectedName);

            string strSQL = "SELECT UserTable.UserID, Log.PumpNumber, Log.Date, Log.Time FROM UserTable, Log WHERE name = '" + selectedName + "'";

            PopulateDataView(strSQL, databaseConnection);
        }

    }
}
