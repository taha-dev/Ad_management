using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asg3_Task1
{
    public class Ad
    {
        string _title;
        string _category;
        string _description;

        public Ad(string title, string category, string description)
        {
            _title = title;
            _category = category;
            _description = description;
        }

        public string Title { get => _title; set => _title = value; }
        public string Category { get => _category; set => _category = value; }
        public string Description { get => _description; set => _description = value; }
        public string Print()
        {
            return string.Format("Title => {0}, Category => {1}, Description => {2}", Title, Category, Description);
        }
    }
}
