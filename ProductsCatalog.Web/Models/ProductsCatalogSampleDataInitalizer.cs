using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProductsCatalog.Web.Models
{
	public class ProductsCatalogSampleDataInitalizer : DropCreateDatabaseAlways<ProductsCatalogContext>
	{
		protected override void Seed(ProductsCatalogContext context)
		{
			var categories = new List<Category>(){
					new Category()
					{
						Name = "Tablets",
						Description = "Tablet devices"
					},
					new Category()
					{
						Name = "Laptops",
						Description = "Laptop computers"
					},
					new Category()
					{
						Name = "Desktop PC",
						Description = "Desktop computers"
					},
					new Category()
					{
						Name = "Smartphones",
						Description = "Smartphone devices"
					},
					new Category()
					{
						Name = "Printers & scanners",
						Description = "printers devices"
					},
					new Category()
					{
						Name = "Accessoaries",
						Description = "Computer accessoaries"
					}
			};
			categories.ForEach(k => context.Categories.Add(k));


			var products = new List<Product>()
			{
				new Product()
				{
					Name = "HTC Mozard",
					Category = categories.Where(c=> c.Name =="Smartphones").FirstOrDefault(),
					Description = "Windows Phone 7.5 OS",
					Price = 720,
				},
				new Product()
				{
					Name = "Samsung Galaxy S2",
					Category = categories.Where(c=> c.Name =="Smartphones").FirstOrDefault(),
					Price = 1000,
				},
				new Product()
				{
					Name = "iPhone 4",
					Category = categories.Where(c=> c.Name =="Smartphones").FirstOrDefault(),
					Description = "iOS 5",
					Price = 1400,
				},
				new Product()
				{
					Name = "iPhone 3",
					Category = categories.Where(c=> c.Name =="Smartphones").FirstOrDefault(),
					Description = "iOS 4",
					Price = 880,
				},
				new Product()
				{
					Name = "iPhone 4s",
					Category = categories.Where(c=> c.Name =="Smartphones").FirstOrDefault(),
					Description = "iOS 5",
					Price = 1550,
				},
				new Product()
				{
					Name = "Nokia Lumia 800",
					Category = categories.Where(c=> c.Name =="Smartphones").FirstOrDefault(),
					Description = "Windows Phone 7.5 OS",
					Price = 800,
				},
				new Product()
				{
					Name = "Nokia Lumia 900",
					Category = categories.Where(c=> c.Name =="Smartphones").FirstOrDefault(),
					Description = "Windows Phone 7.5 OS",
					Price = 1050,
				},
				new Product()
				{
					Name = "Dell Inspiron 5110",
					Category = categories.Where(c=> c.Name =="Laptops").FirstOrDefault(),
					Description = "6GB Ram, i7 2630, 640 HDD",
					Price = 1400,
				},
				new Product()
				{
					Name = "Dell Inspiron 7110",
					Category = categories.Where(c=> c.Name =="Laptops").FirstOrDefault(),
					Description = "8GB Ram, i7 2630, 640 HDD",
					Price = 1880,
				},
				new Product()
				{
					Name = "Dell Inspiron 5110",
					Category = categories.Where(c=> c.Name =="Laptops").FirstOrDefault(),
					Description = "4GB Ram, i5 2530, 750 HDD",
					Price = 1400,
				},
				new Product()
				{
					Name = "Dell Inspiron 5110",
					Category = categories.Where(c=> c.Name =="Laptops").FirstOrDefault(),
					Description = "2GB Ram, i7 2630, 640 HDD",
					Price = 1300,
				},
				new Product()
				{
					Name = "MacBook Air",
					Category = categories.Where(c=> c.Name =="Laptops").FirstOrDefault(),
					Description = "4GB Ram, i7 2630, 500 HDD",
					Price = 4500,
				},
				new Product()
				{
					Name = "MacBook Pro",
					Category = categories.Where(c=> c.Name =="Laptops").FirstOrDefault(),
					Description = "4GB Ram, i5 2530, 500 HDD",
					Price = 3880,
				}
			};
			products.ForEach(p => context.Products.Add(p));

			base.Seed(context);
		}
	}
}