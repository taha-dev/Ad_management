using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asg3_Task1
{
    public class Admin : User, Subject
    {
        List<Observer> obs;

        public List<Observer> Obs { get => obs; set => obs = value; }

        public Admin(int id, string name, string phone, string email, string pass, DateTime dob) : base(id, name, phone, email, pass, dob)
        {
            obs = new List<Observer>();
        }
        public void RegisterObserver(Observer o)
        {
            obs.Add(o);
        }
        public void RemoveObserver(Observer o)
        {
            obs.Remove(o);
        }
        public List<string> NotifyObserver(Ad ad)
        {
            List<string> temp = new List<string>();
            foreach(Observer i in obs)
            {
                if(i.GetInterests().Contains(ad.Category))
                    temp.Add(i.Update(ad));
            }
            return temp;
        }
        public Ad Create_ad(string title, string category, string desc)
        {
            Ad ad = new Ad(title, category, desc);
            return ad;
        }
        public Consumer Create_consumer(int id, string name, string phone, string email, string pass, DateTime dob, List<string> interests)
        {
            Consumer cn = new Consumer(id, name, phone, email, pass, dob, interests);
            return cn;
        }

    }
}
