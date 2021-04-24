using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asg3_Task1
{
    public class User
    {
        int _id;
        string _name;
        string _phone;
        string _email;
        string _pass;
        DateTime _dob;

        public User(int id, string name, string phone, string email, string pass, DateTime dob)
        {
            _id = id;
            _name = name;
            _phone = phone;
            _email = email;
            _pass = pass;
            _dob = dob;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public DateTime Dob { get => _dob; set => _dob = value; }
        public string Email { get => _email; set => _email = value; }
        public string Pass { get => _pass; set => _pass = value; }
        public string Print()
        {
            return string.Format("Id => {0}, Name => {1}, Email => {2}, Phone => {3}, Dob => {4}", Id, Name, Email, Phone, Dob);
        }
    }
}
