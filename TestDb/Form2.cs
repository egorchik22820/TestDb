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
        private DataSet _userSet2 = new DataSet();
        private SqlDataAdapter _adapter;
        private SqlDataAdapter _adapter2;
        public Form2()
        {
            InitializeComponent();

            //string connectionString = @"Data Source=pcsqlstud01;Initial Catalog=10240013;Integrated Security=True;Encrypt=False";
            //SqlConnection connection = new SqlConnection(connectionString);
            //connection.Open();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM prodANDcoaf;";
            _adapter2 = new SqlDataAdapter(selectQuery, @"Data Source=pcsqlstud01;Initial Catalog=10240013;Integrated Security=True;Encrypt=False");
            _adapter2.Fill(_userSet2, "prodANDcoaf");
            dataGridView1.DataSource = _userSet2.Tables["prodANDcoaf"];


        }

        private void button1_Click(object sender, EventArgs e)
        {

            string selectQuery = "SELECT * FROM products;";
            //_adapter = new SqlDataAdapter(selectQuery, @"Data Source=pcsqlstud01;Initial Catalog=10240013;Integrated Security=True;Encrypt=False");
            //_adapter.Fill(_userSet);
            dataGridView2.DataSource = _userSet.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddProd addProd = new AddProd();
            addProd.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var selectedRowIndex = -1;
            if (dataGridView2.SelectedRows.Count > 0 && dataGridView2.SelectedRows[0].Index < dataGridView2.Rows.Count - 1)
            {
                selectedRowIndex = dataGridView2.SelectedRows[0].Index;
            }
            else
            {
                MessageBox.Show("Вы не выбрали строку для редактирования!");
                return;
            }
            editPage editPage = new editPage(selectedRowIndex, _userSet, _userSet2, _adapter, _adapter2);
            editPage.Show();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            string connectionString = "Data Source=pcsqlstud01;Initial Catalog=10240013;Integrated Security=True;Encrypt=False";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
            {
                //заполнение таблицы данными
                _userSet = new DataSet();
                string selectCategories = "SELECT * FROM products";
                _adapter = new SqlDataAdapter(selectCategories, sqlConnection);
                _adapter.Fill(_userSet);
                //для DataGrid ставлю MultiSelect на false, чтобы пользователь не мог выделять сразу несколько строк
                dataGridView2.MultiSelect = false;
                dataGridView2.DataSource = _userSet.Tables[0];


                _userSet2 = new DataSet();
                selectCategories = "SELECT * FROM prodANDcoaf";
                _adapter2 = new SqlDataAdapter(selectCategories, sqlConnection);
                _adapter2.Fill(_userSet2);
                dataGridView1.DataSource = _userSet2.Tables[0];

            }

        }
    }
}
