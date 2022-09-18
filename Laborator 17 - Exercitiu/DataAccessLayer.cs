using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Laborator_17___Exercitiu.Models;
using Laborator_17___Exercitiu.Exceptions;
using System.Runtime.ConstrainedExecution;
using Microsoft.EntityFrameworkCore.Internal;

namespace Laborator_17___Exercitiu
{
    internal class DataAccessLayer
    {
        private static DataAccessLayer instance = null;
        public static DataAccessLayer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataAccessLayer();
                }
                return instance;
            }
        }
        private DataAccessLayer()
        {
        }

        //Adaugare de categorie

        public Category AddCategory(string name, string urlPicture)
        {
            using var ctx = new ShopManagementContextDb();
            var category = new Category { Name = name, Pictograma = urlPicture };
            ctx.Categories.Add(category);
            ctx.SaveChanges();
            return category;
        }
        // Adaugare de producator
        public Manufacturer AddManufacturer(string name, string cui, string address)
        {
            using var ctx = new ShopManagementContextDb();
            var manufacturer = new Manufacturer { Name = name, CUI = cui, Adress = address };
            ctx.Add(manufacturer);
            ctx.SaveChanges();
            return manufacturer;
        }
        // Modificarea pretului unui produs
        public void ChangePrice(int productId, double newPrice)
        {
            using var ctx = new ShopManagementContextDb();
            var product = ctx.Products.Include(p => p.Receipt).FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                throw new NotFoundException($"Product {productId} does not exist!!!");
            }
            product.Receipt.Price = newPrice;

            ctx.SaveChanges();
        }
        //Obtinerea valorii totale a stocului magazinului.
        public double GetTotalStockQuantityStore()
        {
            using var ctx = new ShopManagementContextDb();
            return ctx.Products.Include(p => p.Receipt).Sum(p => p.Stock * p.Receipt.Price);
        }
        //Obtinearea valorii stocului de la un anumit producator oferit ca parametru.
        public double GetTotalStockForManufacturer(int manufacturerId)
        {
            using var ctx = new ShopManagementContextDb();
            return ctx.Products.Include(p => p.Receipt).Where(p => p.ManufacturerId == manufacturerId).Sum(p => p.Stock * p.Receipt.Price);
        }
        //Obtinerea valorii totale a stocului per categorie.
        public double GetTotalStockQuantityCategory(int categoryId)
        {
            using var ctx = new ShopManagementContextDb();
            return ctx.Products.Include(p => p.Receipt).Where(p => p.CategoryId == categoryId).Sum(p => p.Stock * p.Receipt.Price);
        }
        //• Adaugare de produs:• Va adauga automat si eticheta
        public Product AddProduct(string name, int stock, int manufacturerId, int categoryId)
        {
            using var ctx = new ShopManagementContextDb();

            if (!ctx.Manufacturers.Any(p => p.Id == manufacturerId))
            {
                throw new NotFoundException($"The manufacturer {manufacturerId} does not exist in the system!!!");
            }
            Console.Clear();
            if (!ctx.Categories.Any(p => p.Id == categoryId))
            {
                throw new NotFoundException($"The category {categoryId} does not exist in the system!!!");
            }
            var product = new Product
            {
                Name = name,
                Stock = stock,
                ManufacturerId = manufacturerId,
                CategoryId = categoryId,
            };
            ctx.Products.Add(product);
            ctx.SaveChanges();
            return product;
        }
        //Obtinerea valorii stocului per categorie per producator.
        public double GetStockValuePerCategoryPerManufacturer(int categoryId, int manufacturerId)
        {
            using var ctx = new ShopManagementContextDb();

            if (!ctx.Manufacturers.Any(p => p.Id == manufacturerId))
            {
                throw new NotFoundException($"The manufacturer {manufacturerId} does not exist!!!");
            }
            if (!ctx.Categories.Any(p => p.Id == categoryId))
            {
                throw new NotFoundException($"The category {categoryId} does not exist!!!");
            }
            return ctx.Products.Where(p => p.ManufacturerId == manufacturerId && p.CategoryId == categoryId).Sum(p => p.Stock * p.Receipt.Price);
        }
    }
}
