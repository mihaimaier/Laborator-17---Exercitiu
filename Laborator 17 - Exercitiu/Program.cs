using Laborator_17___Exercitiu.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// Laborator 17 - Exercitiu

//1.Stabiliti relatiile dintre clase
//2. Realizati diagrama uml
//3. Stabiliti relatiile dintre entitati (1-
//1,1-*,*-*)
//4.Stabiliti Navigation Property-urile si
//FK-urile necesare
//5. Creeati DB-ul, DBContext-ul, precum 
//si o functie statica seedDB/resetDB

static Manufacturer ResetDb()
{
    using var ctx = new ShopManagementContextDb();

    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();

    var manufacturer = new Manufacturer
    {
        Name = "Alka",
        Adress = "Șoseaua Străulești 76, București 013337, Romania",
        CUI = "WAFERS",
    };

    var waferCategory = new Category
    {
        Name = "Wafer Items",
        Pictograma = @"https://www.mega-image.ro/ro-ro/Dulciuri-si-snacks/Napolitane-biscuiti-si-prajituri/Napolitane/Napolitane-cu-crema-de-lamaie-170g/p/12462"
    };
    manufacturer.Categories.Add(waferCategory);

    var product1 = new Product
    {
        Name = "Alka Lemon Cream Wafer",
        Manufacturer = manufacturer,
        Stock = 100,
        Category = waferCategory,
        Receipt = new Receipt
        {
            Barcode = Guid.NewGuid(),
            Price = 4.05,
        }
    };
    var product2 = new Product
    {
        Name = "Alka Cocoa Cream Wafer",
        Manufacturer = manufacturer,
        Stock = 70,
        Category = waferCategory,
        Receipt = new Receipt
        {
            Barcode = Guid.NewGuid(),
            Price = 5.30,
        }
    };
    var product3 = new Product
    {
        Name = "Alka Chocolate Glazed Wafer",
        Manufacturer = manufacturer,
        Stock = 250,
        Category = waferCategory,
        Receipt = new Receipt
        {
            Barcode = Guid.NewGuid(),
            Price = 9.75,
        }
    };
    var product4 = new Product
    {
        Name = "Alka Cocoa & Cholcolate Glazed Wafer",
        Manufacturer = manufacturer,
        Stock = 35,
        Category = waferCategory,
        Receipt = new Receipt
        {
            Barcode = Guid.NewGuid(),
            Price = 11.35,
        }
    };
    var product5 = new Product
    {
        Name = "Alka Vanilla Cream Wafer",
        Manufacturer = manufacturer,
        Stock = 350,
        Category = waferCategory,
        Receipt = new Receipt
        {
            Barcode = Guid.NewGuid(),
            Price = 7.00,
        }
    };
    ctx.Categories.Add(waferCategory);
    ctx.Products.Add(product1);
    ctx.Products.Add(product2);
    ctx.Products.Add(product3);
    ctx.Products.Add(product4);
    ctx.Products.Add(product5);

    ctx.SaveChanges();
    return manufacturer;
}