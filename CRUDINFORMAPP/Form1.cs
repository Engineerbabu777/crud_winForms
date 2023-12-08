using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDINFORMAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-Q2S09P8;Initial Catalog=learningDatabase;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-Q2S09P8;Initial Catalog=learningDatabase;Integrated Security=True");
            conn.Open();
            SqlCommand command = new SqlCommand("insert into ProductInfo_Tab values('"+int.Parse(textBox3.Text)+ "', '"+(textBox1.Text)+"','"+(textBox4.Text)+"','"+(comboBox1.Text)+"', getDate())",conn);
            command.ExecuteNonQuery();
            MessageBox.Show("Inserted Success!");
            conn.Close();

            BindData();
        }

        void BindData()
        {
            SqlCommand command = new SqlCommand("select * from ProductInfo_Tab", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand command = new SqlCommand("update ProductInfo_Tab set ItemName = '" + textBox1.Text + "',Design= '" +textBox4.Text+"', updatedDate= '"+DateTime.Parse(dateTimePicker1.Text)+"' where ProductID='"+int.Parse(textBox3.Text)+"' ", conn);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Updated Data");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("delete ProductInfo_Tab where productId='"+int.Parse(textBox3.Text)+"'", conn);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Deleted Success");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("select * from ProductInfo_Tab where productId='"+int.Parse(textBox3.Text)+"'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
