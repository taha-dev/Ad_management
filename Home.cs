using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asg3_Task1
{
    public partial class Home : Form
    {
        public static Admin admin;
        public Home()
        {
            Generate_admin();
            InitializeComponent();
        }
        private void Generate_admin()
        {
            DateTime dob = new DateTime(2000, 10, 25);
            admin = new Admin(1, "Muhammad Taha", "03174112922", "f2018065102@umt.edu.pk", "12345678", dob);
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_email.Text) || string.IsNullOrEmpty(txt_pass.Text))
            {
                MessageBox.Show("Please Fill Both Fields Correctly!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(txt_email.Text == admin.Email && txt_pass.Text == admin.Pass)
                {
                    Dashboard dashboard = new Dashboard();
                    this.Hide();
                    dashboard.Show();
                }
                else
                {
                    MessageBox.Show("Failed to login, Invalid Credentials!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                if(MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
