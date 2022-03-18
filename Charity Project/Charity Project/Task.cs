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
    public partial class Task : Form
    {
        OracleDataAdapter da;
        OracleCommandBuilder cd;
        DataSet ds;
        string ordb = "data source =orcl; user id=scott ; password=tiger;";
        OracleConnection conn;
        public Task()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string id="";
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "employees";
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.Add("name", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr = c.ExecuteReader();
            if (dr.Read())
            {
                for (int i = 0; i <= comboBox1.SelectedIndex; i++)
                {
                     id = dr[1].ToString();
                }

            }
            dr.Close();
            OracleCommand c1 = new OracleCommand();
            c1.Connection = conn;
            c1.CommandText = "update donation set emp_id=:id where type=:type";
            c1.CommandType = CommandType.Text;
            c1.Parameters.Add("id",id);
            c1.Parameters.Add("type", comboBox2.SelectedItem);
            int execute = c1.ExecuteNonQuery();

           OracleCommand c4 = new OracleCommand();
            c4.Connection = conn;
            c4.CommandText = "insert into needy_emp (emp_id) values (:id)";
            c4.CommandType = CommandType.Text;
            c4.Parameters.Add("id", id);
            int execute3 = c4.ExecuteNonQuery();

            


            string id1 = "";
            OracleCommand c2 = new OracleCommand();
            c2.Connection = conn;
            c2.CommandText = "needy";
            c2.CommandType = CommandType.StoredProcedure;
            c2.Parameters.Add("name", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr2 = c2.ExecuteReader();
            if (dr2.Read())
            {
                for (int i = 0; i <= comboBox3.SelectedIndex; i++)
                {
                    id1 = dr2[1].ToString();
                }

            }
            dr2.Close();
            OracleCommand c3 = new OracleCommand();
            c3.Connection = conn;
            c3.CommandText = "update donation set needyperson_id=:id where type=:type";
            c3.CommandType = CommandType.Text;
            c3.Parameters.Add("id", id1);
            c3.Parameters.Add("type", comboBox2.SelectedItem);
            int execute1 = c3.ExecuteNonQuery();


            OracleCommand c5 = new OracleCommand();
            c5.Connection = conn;
            c5.CommandText = "update needy_emp set needy_id=:id where emp_id=:id1";
            c5.CommandType = CommandType.Text;
            c5.Parameters.Add("id", id1);
            c5.Parameters.Add("id1", id);
            int execute4 = c5.ExecuteNonQuery();

            OracleCommand c6 = new OracleCommand();
            c6.Connection = conn;
            c6.CommandText = "update charity_emp set status='busy' where id=:id";
            c6.CommandType = CommandType.Text;
            c6.Parameters.Add("id", id);
            int execute5 = c6.ExecuteNonQuery();


            cd = new OracleCommandBuilder(da);
            da.Update(ds.Tables[0]);

            MessageBox.Show("Done");
            Form f = new Task();
            this.Hide();
            f.Show();
        }

        private void Task_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand sn = new OracleCommand();
            sn.Connection = conn;
            sn.CommandText = "oneemp";
            sn.CommandType = CommandType.StoredProcedure;
            sn.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
            sn.ExecuteNonQuery();

            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "employees";
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.Add("name", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr = c.ExecuteReader();
            while (dr.Read())
            {
                if(Convert.ToInt32(sn.Parameters["id"].Value.ToString())==Convert.ToInt32(dr[1]))
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();

            OracleCommand c1 = new OracleCommand();
            c1.Connection = conn;
            c1.CommandText = "item";
            c1.CommandType = CommandType.StoredProcedure;
            c1.Parameters.Add("item", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr1 = c1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox2.Items.Add(dr1[0]);
            }
            dr1.Close();

            OracleCommand c2 = new OracleCommand();
            c2.Connection = conn;
            c2.CommandText = "needy";
            c2.CommandType = CommandType.StoredProcedure;
            c2.Parameters.Add("name", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr2 = c2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox3.Items.Add(dr2[0]);
            }
            dr2.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            string cmd = @"select type , amount from donation";
            da = new OracleDataAdapter(cmd,ordb);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

    }
}
