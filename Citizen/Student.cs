using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citizen
{
    class Student:Citizen
    {
        public Student(int passport, int age)
              :base(passport, age)
        {
        }
    }
}
