using Microsoft.Data.SqlClient;
using System.Data;

namespace TestDb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string connectionString = @"Data Source=pcsqlstud01;Initial Catalog=10240013;Integrated Security=True;Encrypt=False";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connectionStatusLabel.Text = "Connected";
                string selectQuery = "SELECT * FROM users;";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectQuery, connection);
                DataSet usersSet = new DataSet();
                sqlDataAdapter.Fill(usersSet);
                usersGrid.DataSource = usersSet.Tables[0];
            }
        }
    }
}
