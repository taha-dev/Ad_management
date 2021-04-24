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
        public Admin(int id, string name, string phone, string email, string pass, DateTime dob) : base(id, name, phone, email, pass, dob){}
        public void RegisterObserver(Observer o)
        {
            obs.Add(o);
        }
        public void RemoveObserver(Observer o)
        {
            obs.Remove(o);
        }
        public void NotifyObserver(Ad ad)
        {
            foreach(Observer i in obs)
            {
                i.Update(ad);
            }
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
