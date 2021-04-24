using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asg3_Task1
{
    public interface Observer
    {
        string Update(Ad ad);
        List<string> GetInterests();
    }
}
