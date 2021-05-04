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
        Ad ad;
        int ids = 2;
        public Dashboard()
        {
            InitializeComponent();
            cn = new List<Consumer>();
            categories = new List<string>();
            Generate_categories();
            Generate_consumer();
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
                Home.admin.RegisterObserver(cn1);
            }
        }

        private void btn_create_cat_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_cat.Text))
            {
                if (!categories.Contains(txt_cat.Text, StringComparer.OrdinalIgnoreCase))
                {
                    categories.Add(txt_cat.Text);
                    cmb_ad_cat.Items.Add(txt_cat.Text);
                    clb_interests.Items.Add(txt_cat.Text);
                    MessageBox.Show("Category Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_cat.ResetText();
                }
                else
                {
                    MessageBox.Show("Category Already Exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please write something in the field!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool validate_user_fields()
        {
            if(string.IsNullOrEmpty(txt_username.Text) || string.IsNullOrEmpty(txt_phone.Text) || string.IsNullOrEmpty(txt_email.Text) || string.IsNullOrEmpty(txt_pass.Text))
            {
                MessageBox.Show("Please Fill All the Required Fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool validate_user_data()
        {
            bool value = true;
            foreach(Consumer i in cn)
            {
                if(i.Phone.Equals(txt_phone.Text))
                {
                    MessageBox.Show("Phone number already in use!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    value = false;
                }
                if(i.Email.Equals(txt_email.Text))
                {
                    MessageBox.Show("Email already in use!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    value = false;
                }
            }
            return value;
        }
        private bool validate_email()
        {
            bool value = false;
            if (string.IsNullOrEmpty(txt_email.Text))
            {
                MessageBox.Show("Please enter an email to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return value;
            }
            foreach(Consumer i in cn)
            {
                if(i.Email.Equals(txt_email.Text))
                {
                    value = true;
                }
            }
            if(value)
            {
                return value;
            }
            MessageBox.Show("Email Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return value;
        }
        private bool validate_phone()
        {
            if (string.IsNullOrEmpty(txt_phone.Text))
                return true;
            bool value = true;
            foreach (Consumer i in cn)
            {
                if (i.Phone.Equals(txt_phone.Text))
                {
                    value = false;
                }
            }
            if (value)
            {
                return value;
            }
            MessageBox.Show("Phone number Already in use!\nPlease use another phone number or leave the field empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return value;
        }
        private Consumer get_cons()
        {
            Consumer temp = null;
            foreach(Consumer i in cn)
            {
                if(i.Email.Equals(txt_email.Text))
                {
                    temp = i;
                }
            }
            return temp;
        }
        private void Clear_user_data()
        {
            txt_username.Text = "";
            txt_phone.Text = "";
            txt_email.Text = "";
            txt_pass.Text = "";
            dtp_dob.Value = DateTime.Today;
            foreach (int i in clb_interests.CheckedIndices)
            {
                clb_interests.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
        private void btn_create_user_Click(object sender, EventArgs e)
        {
            if(validate_user_fields() && validate_user_data())
            {
                if(clb_interests.CheckedItems.Count == 0)
                {
                    ids++; ;
                    cn1 = new Consumer(ids,txt_username.Text, txt_phone.Text, txt_email.Text, txt_pass.Text, dtp_dob.Value, new List<string>());
                    cn.Add(cn1);
                    Form f = new Form();
                    RichTextBox rct = new RichTextBox();
                    f.Controls.Add(rct);
                    rct.Dock = DockStyle.Fill;
                    rct.Text = cn[cn.Count - 1].Print();
                    f.ShowDialog();
                }
                else
                {
                    ids++; ;
                    List<string> temp = new List<string>();
                    foreach(string i in clb_interests.CheckedItems)
                    {
                        temp.Add(i);
                    }
                    cn1 = new Consumer(ids, txt_username.Text, txt_phone.Text, txt_email.Text, txt_pass.Text, dtp_dob.Value, temp);
                    Home.admin.RegisterObserver(cn1);
                    cn.Add(cn1);
                    Form f = new Form();
                    RichTextBox rct = new RichTextBox();
                    f.Controls.Add(rct);
                    rct.Dock = DockStyle.Fill;
                    rct.Text = cn[cn.Count - 1].Print();
                    f.ShowDialog();
                }
                MessageBox.Show("User Created Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear_user_data();
            }
        }

        private void btn_update_user_Click(object sender, EventArgs e)
        {
            if(validate_email() && validate_phone())
            {
                List<string> temp = new List<string>();
                foreach (string i in clb_interests.CheckedItems)
                {
                    temp.Add(i);
                }
                cn1 = get_cons();
                if(!string.IsNullOrEmpty(txt_username.Text))
                    cn1.Name = txt_username.Text;
                if(!string.IsNullOrEmpty(txt_phone.Text))
                    cn1.Phone = txt_phone.Text;
                if (!string.IsNullOrEmpty(txt_pass.Text))
                    cn1.Pass = txt_pass.Text;
                if(dtp_dob.Value.Date != DateTime.Today.Date)
                    cn1.Dob = dtp_dob.Value;
                cn1.Interests = temp;
                cn[cn.IndexOf(get_cons())] = cn1;
                if(!Home.admin.Obs.Contains(cn1))
                {
                    if(temp.Count > 0)
                    {
                        Home.admin.RegisterObserver(cn1);
                    }
                }
                else
                {
                    if(temp.Count == 0)
                    {
                        Home.admin.RemoveObserver(cn1);
                    }
                }
                Form f = new Form();
                RichTextBox rct = new RichTextBox();
                f.Controls.Add(rct);
                rct.Dock = DockStyle.Fill;
                foreach (Consumer i in cn)
                {
                    rct.Text += i.Print();
                }
                f.ShowDialog();
                MessageBox.Show("Consumer Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear_user_data();
            }
        }
        private bool validate_ad()
        {
            if(string.IsNullOrEmpty(txt_ad_title.Text) || string.IsNullOrEmpty(rchtxt_desc.Text))
            {
                MessageBox.Show("Please Fill All the Fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btn_adpost_Click(object sender, EventArgs e)
        {
            List<string> temp;
            if(validate_ad())
            {
                ad = Home.admin.Create_ad(txt_ad_title.Text, cmb_ad_cat.Text, rchtxt_desc.Text);
                temp = Home.admin.NotifyObserver(ad);
                if(temp.Count > 0)
                {
                    Form f = new Form();
                    RichTextBox rct = new RichTextBox();
                    f.Controls.Add(rct);
                    rct.Dock = DockStyle.Fill;
                    foreach (string i in temp)
                    {
                        rct.Text += i+"\n";
                    }
                    txt_ad_title.Text = "";
                    cmb_ad_cat.SelectedIndex = -1;
                    rchtxt_desc.Text = "";
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("empty list", "dasdasd");
                }
            }
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.MessageLoop)
            {
                Application.Exit();
            }
            else
            {
                Environment.Exit(1);
            }
        }
    }
}
