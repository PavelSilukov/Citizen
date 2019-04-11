using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citizen
{
    class Worker:Citizen
    {
       public Worker(string name, int passport, int age)
            :base(name, passport, age)
        {

        }
    }
}
