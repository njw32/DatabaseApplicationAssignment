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
using System.IO;

namespace AuthorsApplication
{
    public partial class AuthorsApp : Form
    {
        public AuthorsApp()
        {
            InitializeComponent();
            InitializeForm();
        }

        //public vatiables called by many methods
        public SqlConnection conn;
        public String connString;
        public String selectedItem;

        private void InitializeForm()
        {
            //create connection and connection string
            connString = Properties.Settings.Default.pubsConnectionString;

            conn = new SqlConnection(connString);

            //run sql files - create view
            string viewScript = File.ReadAllText("testViewNoParam.sql");
            //Below is commented out because it is mostly a copy of how the procedure was created and I am not sure how that works.
            //SQLCommand createViewScript = new SQLCommand(viewScript, conn);
           


            //run sql files - generate procedure
            string script = File.ReadAllText("setup.sql");
            if (conn.State != ConnectionState.Open) conn.Open();
            SqlCommand createScript = new SqlCommand(script, conn);
            createScript.ExecuteNonQuery();

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //TODO - LIST Books per author - need view
            string currentSelection;


            currentSelection = (listAuthors.SelectedItem as DataRowView)["au_id"].ToString();
            //set global variable - used for sp button
            selectedItem = (listAuthors.SelectedItem as DataRowView)["au_id"].ToString();

            labelBooks.Text = "Item ID: " + currentSelection;
            
            //textBox with sample text
            textBoxAddress.Text = "123 Sample St.";
            textBoxCity.Text = "City";
            textBoxState.Text = "MI";
            textBoxZip.Text = "60004";

            if (conn.State != ConnectionState.Open) conn.Open();

            string sql_Address = "SELECT address FROM authors WHERE au_id='" + currentSelection + "'";
            SqlCommand selectAddress = new SqlCommand(sql_Address, conn);
            string sql_City = "SELECT city FROM authors WHERE au_id='" + currentSelection + "'";
            SqlCommand selectCity = new SqlCommand(sql_City, conn);
            string sql_State = "SELECT state FROM authors WHERE au_id='" + currentSelection + "'";
            SqlCommand selectState = new SqlCommand(sql_State, conn);
            string sql_Zip = "SELECT zip FROM authors WHERE au_id='" + currentSelection + "'";
            SqlCommand selectZip = new SqlCommand(sql_Zip, conn);

            try
            { 
                labelAddress.Text = selectAddress.ExecuteScalar().ToString() + "\n" + selectCity.ExecuteScalar().ToString() + ", " + selectState.ExecuteScalar().ToString() + "\n" + selectZip.ExecuteScalar().ToString();
            }
            catch (SqlException)
            {
                labelAddress.Text = "Not Correctly Pulled from DB";
            }

          
        }

        private void AuthorsApp_Load(object sender, EventArgs e)
        {
            loadData();

        }

        private void loadData()
        { 
            if (conn.State != ConnectionState.Open) conn.Open();

            string sql_Text = "SELECT au_id, au_lname FROM authors";

            DataTable tbl = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(sql_Text, conn);
            adapter.Fill(tbl);

          
            //show elements
            listAuthors.DisplayMember = "au_lname";
            listAuthors.ValueMember = "au_id";

            listAuthors.DataSource = tbl;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newAddress = textBoxAddress.Text;

            //run stored procedure with selected data
            createStoredProcedure(newAddress).ExecuteNonQuery();
            MessageBox.Show("New Address Saved");
            loadData();

            //MessageBox.Show("new Address is:" + newAddress);
        }
        public SqlCommand createStoredProcedure(string newAddress)
        { 
            string sp_name = "proc_ainfo";

            if (conn.State != ConnectionState.Open) conn.Open();

            SqlCommand rSproc = new SqlCommand(sp_name, conn);
            rSproc.CommandType = CommandType.StoredProcedure;
            
            //incoming parameters
            rSproc.Parameters.AddWithValue("au_id", selectedItem);
            rSproc.Parameters.AddWithValue("@address", textBoxAddress.Text);
            rSproc.Parameters.AddWithValue("@city", textBoxCity.Text);
            rSproc.Parameters.AddWithValue("@state", textBoxState.Text);
            rSproc.Parameters.AddWithValue("@zip", textBoxZip.Text);

            //return parameter
            SqlParameter spReturn = new SqlParameter();
            spReturn.ParameterName = "@returnValue";
            spReturn.SqlDbType = System.Data.SqlDbType.Int;
            spReturn.Direction = ParameterDirection.ReturnValue;
            rSproc.Parameters.Add(spReturn);

            return rSproc;
        }
    }
}