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
    public partial class AddProd : Form
    {
        private DataSet typesSet = new DataSet();
        private DataSet productsSet = new DataSet();
        private SqlDataAdapter sqlDataAdapter;
        private SqlDataAdapter prodAdapter;
        private Button button1;
        private List<Types> types = new List<Types>();
        public AddProd()
        {
            InitializeComponent();



            string connectionString = @"Data Source=pcsqlstud01;Initial Catalog=10240013;Integrated Security=True;Encrypt=False";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
            {
                typesSet = new DataSet();
                productsSet = new DataSet();
                string selectTypes = "SELECT * FROM prodANDcoaf";
                string prod = "SELECT * FROM products;";
                sqlDataAdapter = new SqlDataAdapter(selectTypes, sqlConnection);
                prodAdapter = new SqlDataAdapter(prod, sqlConnection);
                sqlDataAdapter.Fill(typesSet);
                prodAdapter.Fill(productsSet);  
                foreach (DataRow typeRow in typesSet.Tables[0].Rows)
                {
                    types.Add(new Types(typeRow["typeName"].ToString(),
                        Convert.ToInt32(typeRow["typeID"])));
                }

                comboBox1.DataSource = types;
            }
        }

        private ComboBox comboBox1;

        private void InitializeComponent()
        {
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 27);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(258, 23);
            comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 1;
            label1.Text = "категория";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(373, 9);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 2;
            label2.Text = "наименование";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(373, 69);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 3;
            label3.Text = "мин. цена";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(373, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(209, 23);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(373, 87);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(209, 23);
            textBox2.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(373, 159);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AddProd
            // 
            ClientSize = new Size(620, 295);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Name = "AddProd";
            Load += AddProd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;

        private void AddProd_Load(object sender, EventArgs e)
        {

        }

        private void SaveData()
        {
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(prodAdapter);
            prodAdapter.Update(productsSet);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow newRow = productsSet.Tables[0].NewRow();
            newRow["prodName"] = textBox1.Text.ToString();
            newRow["typeID"] = comboBox1.SelectedIndex + 1;
            newRow["minCost"] = textBox2.Text.ToString();
            productsSet.Tables[0].Rows.Add(newRow);
            SaveData();
            MessageBox.Show("product added");
        }
    }
}
