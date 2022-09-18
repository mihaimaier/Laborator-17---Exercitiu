using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator_17___Exercitiu.Models
{

    //O categorie va fi caracterizata de:
    //• Id(unic)
    //• Nume : string
    //• Pictograma – sub forma unui sir de
    //caractere reprezentand url-ul imaginii
    //corespunzatoare
    //• NavigationProperty / FK- ce lipseste? >>>  Product / Manufacturers

    internal class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pictograma { get; set; }
        public List<Product> Product { get; set; } = new List<Product>();
        public List<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();
    }
}
