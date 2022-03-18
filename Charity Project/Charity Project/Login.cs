using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Charity_Project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if( textBox1.Text==""||textBox2.Text==""||!textBox1.Text.Equals("admin") || !textBox2.Text.Equals("2468"))
            {
                    MessageBox.Show("please try agaim");
                    Form f1 = new Login();
                    this.Hide();
                    f1.Show();
            }
            else{
                    this.Hide();
                   Form f = new Admin();
                    f.Show();
            }
               
        }
            
        
    }
}
