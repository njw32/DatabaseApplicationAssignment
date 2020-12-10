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

        public SqlConnection conn;
        public String connString;
        public String selectedItem;

        private void InitializeForm()
        {
            connString = Properties.Settings.Default.pubsConnectionString;

            conn = new SqlConnection(connString);

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
            selectedItem = (listAuthors.SelectedItem as DataRowView)["au_id"].ToString();

            labelBooks.Text = "Item: " + currentSelection + "books";

            textBoxAddress.Text = "123 Sample St.";
            textBoxCity.Text = "City";
            textBoxState.Text = "State";
            textBoxZip.Text = "600046";

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

            string sql_Text = "SELECT au_id, au_lname, au_fname, address FROM authors";

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
            MessageBox.Show(createStoredProcedure(newAddress).ExecuteNonQuery().ToString());

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