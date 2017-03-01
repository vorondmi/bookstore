using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookstore.ViewModels
{
    public class CheckBoxModel
    {
        public CheckBoxModel()
        { }
        public CheckBoxModel(Guid id, string name, bool Checked)
        {
            this.id = id;
            this.name = name;
            this.Checked = Checked;
        }

        public Guid id { get; set; }

        public string name { get; set; }

        public bool Checked { get; set; }
    }
}