using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator_17___Exercitiu.Models
{
    //Producatorii vor fi caracterizati de
    //• Id(unic)
    //• Nume
    //• Adresa : string
    //• CUI : string
    //• NavigationProperty- ce lipseste >>> Products / Categories

    internal class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string CUI { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
