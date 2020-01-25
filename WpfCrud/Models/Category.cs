using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCrud.Models
{
    public class Category
    {
        int id;string name;string description;

        public Category(int id,string name,string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public Category()
        {

        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }       

        public string Name
        {
            get { return name; }
            set { name = value; }
        }        

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
