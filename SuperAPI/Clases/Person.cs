using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperAPI.Clases
{
    public class Person
    {
        public string name
        {
            get; set;
        }
        public bool isVillan
        {
            get; set;
        }
        public Person(string name, bool isVillan)
        {
            this.name = name;
            this.isVillan = isVillan;
        }
    }
}