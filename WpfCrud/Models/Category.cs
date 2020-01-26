using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WpfCrud.Models
{
    public class Category
    {
        [Display(Name = "Sıra No")]
        [ColumnColor(Red = 255, Green = 0, Blue = 0)]
        public int CategoryID { get; set; }

        [Display(Name = "Kategori Adı")]
        [ColumnColor(Red = 0, Green = 200, Blue = 0)]
        public string CategoryName { get; set; }

        [Display(Name = "Açıklama")]
        [ColumnColor(Red = 220, Green = 231, Blue = 117)]
        public string Description { get; set; }
        //[Display(Name="Kategori No ")]
        ////int id;string name;string description;
        //  [ColumnColor(Red=255,Green=0,Blue=0)]
        //public int CategoryID { get; set; }
        //[Display(Name = "Kategori Adı")]
        //public string CategoryName { get; set; }
        //[Display(Name = "Kategori Açıklama")]
        //public string Description { get; set; }
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
