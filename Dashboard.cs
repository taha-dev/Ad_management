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
    public partial class Dashboard : Form
    {
        List<Consumer> cn;
        Consumer cn1;
        List<string> categories;
        public Dashboard()
        {
            InitializeComponent();
            cn = new List<Consumer>();
            categories = new List<string>();
            Generate_categories();
            Generate_consumer();
            Form f1 = new Form();
            RichTextBox r1 = new RichTextBox();
            r1.Dock = DockStyle.Fill;
            foreach(Consumer i in cn)
            {
                r1.Text += i.Print();
                r1.Text += "\n";
            }
            f1.Controls.Add(r1);
            f1.ShowDialog();
        }
        void Generate_categories()
        {
            foreach(string i in clb_interests.Items)
            {
                categories.Add(i);
            }
        }
        void Generate_consumer()
        {
            string[] name = { "Ahmed", "Ali", "Hamza"};
            string[] phone = { "03214562190", "03142125897", "03479802654"};
            string[] email = { "ahmed123@gmail.com", "m_ali_20@outlook.com", "hamza_h_212@hotmail.com"};
            string[] pass = { "11223344", "87654321", "55667788" };
            DateTime[] dob = { new DateTime(1999,5,20), new DateTime(1998,9,4), new DateTime(2001,6,30)};
            string[,] interest = {{"Car", "Home"},{"Laptop", "Car"},{"Laptop", "Home"} };
            for(int i = 0; i < 3; i++)
            {
                
                cn1 = new Consumer(i, name[i], phone[i], email[i], pass[i], dob[i], new List<string>(new string[] { interest[i, 0], interest[i, 1] }));
                cn.Add(cn1);
            }
        }
    }
}
