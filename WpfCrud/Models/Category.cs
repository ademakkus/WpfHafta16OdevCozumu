using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCrud.Models
{
    public class Category
    {
        [Display(Name="Kategori No")]
        //int id;string name;string description;
        public int CategoryID { get; set; }
        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; }
        [Display(Name = "Kategori Açıklama")]
        public string Description { get; set; }
        //public Category(int id,string name,string description)
        //{
        //    Id = id;
        //    Name = name;
        //    Description = description;
        //}
        //public Category()
        //{

        //}

        //public int Id
        //{
        //    get { return id; }
        //    set { id = value; }
        //}       

        //public string Name
        //{
        //    get { return name; }
        //    set { name = value; }
        //}        

        //public string Description
        //{
        //    get { return description; }
        //    set { description = value; }
        //}
    }
}
