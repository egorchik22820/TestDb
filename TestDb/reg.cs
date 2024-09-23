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
    public partial class reg : Form
    {

        private DataSet _userSet = new DataSet();
        private SqlDataAdapter _adapter;

        public reg()
        {
            InitializeComponent();

            string connectionString = @"Data Source=pcsqlstud01;Initial Catalog=10240013;Integrated Security=True;Encrypt=False";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                string selectQuery = "SELECT * FROM users;";
                _adapter = new SqlDataAdapter(selectQuery, connection);
                _adapter.Fill(_userSet);
            }
        }

        private void reg_Load(object sender, EventArgs e)
        {

        }

        private void SaveData()
        {
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(_adapter);
            _adapter.Update(_userSet);
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            DataRow newRow = _userSet.Tables[0].NewRow();
            newRow["login"] = textBox1.Text;
            newRow["password"] = textBox2.Text;
            newRow["FIO"] = "smth1";
            newRow["e-mail"] = "smth2";
            newRow["phone"] = "smth3";
            _userSet.Tables[0].Rows.Add(newRow);
            SaveData();
            MessageBox.Show("user added");
        }
    }
}
