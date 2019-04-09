
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Citizen
{
    abstract class Citizen
    {
        protected int _passport;
        protected int _age;
        protected Citizen (int passport, int age)
        {
            this._passport = passport;
            this._age = age;
        }
        public int Passport
        {
            get { return _passport; }
        }
        public int Age
        {
            get { return _age; }
        }


    }
}