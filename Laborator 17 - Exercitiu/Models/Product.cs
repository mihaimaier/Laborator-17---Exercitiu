using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator_17___Exercitiu.Models
{
    //Un produs este caracterizat de 
    //• Id(unic)
    //• Nume : string
    //• Stoc: int
    //• Producator
    //• Categorie
    //• Eticheta

    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }

        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Receipt Receipt { get; set; }
    }
}
