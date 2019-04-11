
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Citizen
{
    abstract class Citizen
    {
        protected string _name;
        protected int _passport;
        protected int _age;
        protected Citizen (string name, int passport, int age)
        {
            this._name = name;
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
        public string Name
        {
            get { return _name; }
        }

    }
}