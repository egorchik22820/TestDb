using Microsoft.Data.SqlClient;
using System.Data;

namespace TestDb
{
    public partial class Form1 : Form
    {
        private DataSet _userSet = new DataSet();
        private SqlDataAdapter _adapter;

        public Form1()
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



        private void button1_Click(object sender, EventArgs e)
        {

            foreach (DataRow row in _userSet.Tables[0].Rows)
            {
                if (row["login"].ToString() == textBox1.Text && row["password"].ToString() == textBox2.Text)
                {
                    Form2 f = new Form2();
                    f.Show();
                    return;


                }
            }
            reg r = new reg();
            r.Show();
             
        }
    }
}
