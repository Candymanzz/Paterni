using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace ClassLibary
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }

        public Product() { }

        public Product(string name, decimal price, int qty)
        {
            Name = name;
            Price = price;
            QuantityInStock = qty;
        }

        public bool DecreaseStock(int qty)
        {
            if (qty <= 0) return false;
            if (QuantityInStock < qty) return false;
            QuantityInStock -= qty;
            return true;
        }
    }

    public class SalesPerson
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        /// <summary>Бонус за продажу одной единицы товара</summary>
        public decimal BonusPerItem { get; set; }

        public SalesPerson() { }

        public SalesPerson(string firstName, string lastName, decimal bonusPerItem)
        {
            FirstName = firstName;
            LastName = lastName;
            BonusPerItem = bonusPerItem;
        }

        public string FullName => $"{FirstName} {LastName}";

        /// <summary>Количество проданных единиц этим продавцом — собирается из Store (эксперт)</summary>
        public int GetSoldCount(Store store)
        {
            if (store == null) throw new ArgumentNullException(nameof(store));
            return store.GetSalesBySalesPerson(Id).Sum(s => s.Quantity);
        }

        /// <summary>Примитивная формула зарплаты: baseSalary + BonusPerItem * soldCount</summary>
        public decimal CalculateSalary(decimal baseSalary, Store store)
        {
            var sold = GetSoldCount(store);
            return baseSalary + BonusPerItem * sold;
        }
    }

    public class SaleRecord
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Guid SalesPersonId { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public decimal TotalPrice => UnitPrice * Quantity;

        public SaleRecord() { }

        public SaleRecord(Product p, int qty, SalesPerson sp)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));
            if (sp == null) throw new ArgumentNullException(nameof(sp));
            ProductId = p.Id;
            ProductName = p.Name;
            UnitPrice = p.Price;
            Quantity = qty;
            SalesPersonId = sp.Id;
            Date = DateTime.UtcNow;
        }
    }

    [XmlRoot("StoreData")]
    public class Store
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public List<SalesPerson> SalesPersons { get; set; } = new List<SalesPerson>();
        public List<SaleRecord> Sales { get; set; } = new List<SaleRecord>();

        public Store() { }

        public void AddProduct(Product p)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));
            Products.Add(p);
        }

        public void AddSalesPerson(SalesPerson sp)
        {
            if (sp == null) throw new ArgumentNullException(nameof(sp));
            SalesPersons.Add(sp);
        }

        public bool SellProduct(Guid productId, int quantity, Guid salesPersonId, out string error)
        {
            error = null;
            var product = Products.FirstOrDefault(x => x.Id == productId);
            if (product == null) { error = "Product not found"; return false; }

            if (quantity <= 0) { error = "Quantity must be positive"; return false; }

            var sp = SalesPersons.FirstOrDefault(x => x.Id == salesPersonId);
            if (sp == null) { error = "SalesPerson not found"; return false; }

            if (!product.DecreaseStock(quantity))
            {
                error = "Not enough stock";
                return false;
            }

            var sale = new SaleRecord(product, quantity, sp);
            Sales.Add(sale);
            return true;
        }

        public decimal GetTotalRevenue()
        {
            return Sales.Sum(s => s.TotalPrice);
        }

        public List<SaleRecord> GetSalesBySalesPerson(Guid salesPersonId)
        {
            return Sales.Where(s => s.SalesPersonId == salesPersonId).ToList();
        }

        // Serialization
        public void SaveToXml(string path)
        {
            var serializer = new XmlSerializer(typeof(Store));
            using (var fs = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, this);
            }
        }

        public static Store LoadFromXml(string path)
        {
            var serializer = new XmlSerializer(typeof(Store));
            using (var fs = new FileStream(path, FileMode.Open))
            {
                return (Store)serializer.Deserialize(fs)!;
            }
        }
    }
}
