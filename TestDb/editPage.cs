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
    public partial class editPage : Form
    {
        //поля для хранения данных из предыдущей формы
        private DataSet tagsSet;
        private DataSet tagsSet2;
        private SqlDataAdapter sqlDataAdapter;
        private SqlDataAdapter sqlDataAdapter2;
        private int itemId;
        public editPage()
        {
            InitializeComponent();
        }

        public editPage(int id, DataSet dataset, DataSet dataset2, SqlDataAdapter adapter, SqlDataAdapter adapter2)
        {
            InitializeComponent();
            tagsSet = dataset;
            sqlDataAdapter = adapter;
            tagsSet2 = dataset2;
            sqlDataAdapter2 = adapter2;
            itemId = id;

            var row = tagsSet.Tables[0].Rows[itemId];
            textBox1.Text = row["prodName"].ToString();
        }

        private void SaveChanges()
        {
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            sqlDataAdapter.Update(tagsSet);

            SqlCommandBuilder sqlCommandBuilder2 = new SqlCommandBuilder(sqlDataAdapter2);
            sqlDataAdapter2.Update(tagsSet2);
        }

        private void editPage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            SqlCommandBuilder sqlCommandBuilder2 = new SqlCommandBuilder(sqlDataAdapter2);
            if (!string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox1.Text))
            {
                var row = tagsSet.Tables[0].Rows[itemId];
                row["prodName"] = textBox1.Text;
                row["minCost"] = textBox2.Text;
                SaveChanges();

                Close();
            }
        }
    }
}
