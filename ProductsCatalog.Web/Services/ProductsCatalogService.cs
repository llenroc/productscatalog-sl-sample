using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ServiceModel.DomainServices.EntityFramework;
using System.ServiceModel.DomainServices.Hosting;
using ProductsCatalog.Web;

namespace ProductsCatalog.Web.Services
{
	[EnableClientAccess]
	public partial class ProductsCatalogService : DbDomainService<ProductsCatalogContext>
	{
		public ProductsCatalogService()
		{

		}
		#region Categories CRUD

		public IQueryable<Category> GetCategories()
		{
			return this.DbContext.Set<Category>();
		}

		public void InsertCategory(Category entity)
		{
			this.DbContext.Insert(entity);
		}

		public void UpdateCategory(Category current)
		{
			this.DbContext.Update(current);
		}

		public void DeleteCategory(Category entity)
		{
			this.DbContext.Delete(entity);
		}

		#endregion

		#region Products CRUD

		public IQueryable<Product> GetProducts()
		{
			return this.DbContext.Set<Product>();
		}

		public void InsertProduct(Product entity)
		{
			this.DbContext.Insert(entity);
		}

		public void UpdateProduct(Product current)
		{
			this.DbContext.Update(current);
		}

		public void DeleteProduct(Product entity)
		{
			this.DbContext.Delete(entity);
		}

		#endregion
	}
}