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
    public partial class WelcomPage : Form
    {
        string ordb = "data source =orcl; user id=scott ; password=tiger;";
        OracleConnection conn;
       public static string id;
        public WelcomPage()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand c1 = new OracleCommand();
            c1.Connection = conn;
            c1.CommandText = "select name from donator where phoneno=:phone";
            c1.CommandType = CommandType.Text;
            c1.Parameters.Add("phone", textBox2.Text);
            OracleDataReader dr = c1.ExecuteReader();
            if (dr.Read())
            {
                id = textBox2.Text;
                MessageBox.Show("Welcome Again");
                this.Hide();
                Form f = new Donation();
                f.Show();
            }
            else
            {

                OracleCommand c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into donator values (:name ,:phone,:location)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("name", textBox1.Text);
                c.Parameters.Add("phone", textBox2.Text);
                c.Parameters.Add("location", textBox3.Text);
                int execute = c.ExecuteNonQuery();
                id = textBox2.Text;
                this.Hide();
                Form f = new Donation();
                f.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Login();
            f.Show();
        }

        private void WelcomPage_Load(object sender, EventArgs e)
        {


            conn = new OracleConnection(ordb);
            conn.Open();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
