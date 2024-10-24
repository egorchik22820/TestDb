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
    public partial class ConfirmForm : Form
    {

        private DataSet tagsSet;
        private DataSet tagsSet2;
        private SqlDataAdapter sqlDataAdapter;
        private SqlDataAdapter sqlDataAdapter2;
        private int itemId;

        public ConfirmForm(int id, DataSet dataset, DataSet dataset2, SqlDataAdapter adapter, SqlDataAdapter adapter2)
        {
            InitializeComponent();

            itemId = id;
            tagsSet = dataset;
            tagsSet2 = dataset2;
            sqlDataAdapter = adapter;
            sqlDataAdapter2 = adapter2;
        }

        private void ConfirmForm_Load(object sender, EventArgs e)
        {

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            //var selectedRowIndex = dataGridView2.SelectedRows[0].Index;

            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);


        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}
