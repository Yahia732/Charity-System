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
    public partial class Donation : Form
    {

        string ordb = "data source =orcl; user id=scott ; password=tiger;";
        OracleConnection conn;
        public Donation()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Donation_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;

            c.CommandText = "insert into donation (type,amount,donator_id) values (:type,:amount,:id)";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("type", textBox1.Text);
            c.Parameters.Add("amount", textBox2.Text);
            c.Parameters.Add("id", WelcomPage.id);
            int execute = c.ExecuteNonQuery();
            this.Hide();
            Form F = new WelcomPage();
            F.Show();
        }
    }
}
