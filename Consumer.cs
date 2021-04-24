﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asg3_Task1
{
    public class Consumer : User, Observer
    {
        List<string> _interests;
        public Consumer(int id, string name, string phone, string email, string pass, DateTime dob, List<string> interests) : base(id, name, phone, email, pass, dob)
        {
            _interests = interests;
        }

        public string Display(Ad ad)
        {
            return ad.Print()+"\n"+this.Print();
        }
        public void Update(Ad ad)
        {
            Display(ad);
        }

    }
}