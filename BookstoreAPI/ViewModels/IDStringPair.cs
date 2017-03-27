using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookstore.ViewModels
{
    public class IDStringPair
    {
        public Guid id { get; set; }

        public string name { get; set; }

        public IDStringPair(Guid _id, string _name)
        {
            id = _id;
            name = _name;
        }
    }
}