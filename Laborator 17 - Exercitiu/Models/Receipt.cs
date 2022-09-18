using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator_17___Exercitiu.Models
{
    //Eticheta este caracterizata de :
    //• Id(unic)
    //• Cod de bare(sub forma unui Guid)
    //• Pret : double
    //• NavigationProperty / FK- ce lipseste >>> ProductId / Product

    internal class Receipt
    {
        public int Id { get; set; }
        public Guid Barcode { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
