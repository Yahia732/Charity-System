using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace Charity_Project
{
    public partial class Admin : Form
    {
        string ordb = "data source =orcl; user id=scott ; password=tiger;";
        OracleConnection conn;
        public Admin()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Task();
            f.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "insert into charity_emp (name,empphone,status) values (:name,:phone,:status)";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("name", textBox1.Text);
            c.Parameters.Add("phone", textBox2.Text);
            c.Parameters.Add("status", textBox3.Text);
            int execute = c.ExecuteNonQuery();
            MessageBox.Show("Done");
            this.Hide();
            Form f = new Admin();
            f.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            button4.Visible = true;

            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            button5.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button4.Visible = false;
           

            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            button5.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "insert into poorpeople values (:family,:location,:phone,:name)";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("family", textBox7.Text);
            c.Parameters.Add("location", textBox6.Text);
            c.Parameters.Add("phone", textBox5.Text);
            c.Parameters.Add("name", textBox4.Text);
            
            
           
            int execute = c.ExecuteNonQuery();
            MessageBox.Show("Done");
            this.Hide();
            Form f = new Admin();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            this.Hide();
            f.Show();
        }
    }
}
