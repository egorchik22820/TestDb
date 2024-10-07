using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDb
{
    public partial class Form2 : Form
    {
        private DataSet _userSet = new DataSet();
        private SqlDataAdapter _adapter;
        public Form2()
        {
            InitializeComponent();

            string connectionString = @"Data Source=pcsqlstud01;Initial Catalog=10240013;Integrated Security=True;Encrypt=False";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                string selectQuery = "SELECT * FROM products;";
                _adapter = new SqlDataAdapter(selectQuery, connection);
                _adapter.Fill(_userSet);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM prodANDcoaf;";
            _adapter = new SqlDataAdapter(selectQuery, @"Data Source=pcsqlstud01;Initial Catalog=10240013;Integrated Security=True;Encrypt=False");
            _adapter.Fill(_userSet, "prodANDcoaf");
            dataGridView1.DataSource = _userSet.Tables["prodANDcoaf"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM products;";
            _adapter = new SqlDataAdapter(selectQuery, @"Data Source=pcsqlstud01;Initial Catalog=10240013;Integrated Security=True;Encrypt=False");
            _adapter.Fill(_userSet, "products");
            dataGridView2.DataSource = _userSet.Tables["products"];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddProd addProd = new AddProd();
            addProd.Show();
        }
    }
}
