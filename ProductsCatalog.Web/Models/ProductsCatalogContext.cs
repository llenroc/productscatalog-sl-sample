using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProductsCatalog.Web.Models;

namespace ProductsCatalog.Web
{
	public class ProductsCatalogContext : DbContext
	{
		public ProductsCatalogContext()
		{
			if (HttpContext.Current == null)
			{
				Database.SetInitializer<ProductsCatalogContext>(new ProductsCatalogSampleDataInitalizer());
			}
		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
	}
}