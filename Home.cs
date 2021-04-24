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
        public static List<Consumer> cn;
        public static Admin admin;
        public Home()
        {
            cn = new List<Consumer>();
            Generate_admin();
            InitializeComponent();
        }
        private void Generate_admin()
        {
            DateTime dob = new DateTime(2000, 10, 25);
            admin = new Admin(1, "Muhammad Taha", "03174112922", "f2018065102@umt.edu.pk", "12345678", dob);
        }

    }
}
