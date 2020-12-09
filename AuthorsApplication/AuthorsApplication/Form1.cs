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

namespace AuthorsApplication
{
    public partial class AuthorsApp : Form
    {
        public AuthorsApp()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //TODO - LIST Books per author - need view
            string currentSelection;

            currentSelection = (listAuthors.SelectedItem as DataRowView)["au_lname"].ToString();

            labelBooks.Text = "Item: " + currentSelection;

            textBoxAddress.Text = "123";

            string cn_string = Properties.Settings.Default.pubsConnectionString;

            SqlConnection cn_connection = new SqlConnection(cn_string);

            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            string sql_Text = "SELECT address FROM authors WHERE au_lname='" + currentSelection + "'";

            SqlCommand selectCommand = new SqlCommand(sql_Text, cn_connection);


            //note: O'Leary does not correctly display due to parentheses
            try
            { 
                labelAddress.Text = selectCommand.ExecuteScalar().ToString(); 
            }
            catch (SqlException)
            {
                labelAddress.Text = "O'leary";
            }

          
        }

        private void AuthorsApp_Load(object sender, EventArgs e)
        {
            loadData();

        }

        private void loadData()
        {
            string cn_string = Properties.Settings.Default.pubsConnectionString;

            SqlConnection cn_connection = new SqlConnection(cn_string);

            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            string sql_Text = "SELECT au_lname, au_fname, address FROM authors";

            DataTable tbl = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(sql_Text, cn_connection);
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

            MessageBox.Show("new Address is:" + newAddress);
        }
    }
}