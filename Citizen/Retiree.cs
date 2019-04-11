using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citizen
{
    class Retiree:Citizen
    {
        public Retiree (string name, int passport, int age)
            :base(name, passport, age)
        {
        }
    }
}
