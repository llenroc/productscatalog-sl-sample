
namespace ProductsCatalog.Web
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.ComponentModel.DataAnnotations;
	using System.Data.Objects.DataClasses;
	using System.Linq;
	using System.ServiceModel.DomainServices.Hosting;
	using System.ServiceModel.DomainServices.Server;


	[MetadataTypeAttribute(typeof(Category.CategoryMetadata))]
	public partial class Category
	{
		internal sealed class CategoryMetadata
		{
			private CategoryMetadata()
			{
			}

			[Display(Name="ID", 
					 Description="Id of category")]
			public int CategoryId { get; set; }

			[Display(Name="Name", 
					 Description="Name of products category")]
			[Required(ErrorMessage="Category name must not be empty!",
					  AllowEmptyStrings=false)]
			public string Name { get; set; }

			[Display(Name="Description", 
					 Description="Description of products category")]
			public string Description { get; set; }

			[Display(Name="Products", 
					 Description="Products in category")]
			public IEnumerable<Product> Products { get; set; }
		}
	}

	[MetadataTypeAttribute(typeof(Product.ProductMetadata))]
	public partial class Product
	{

		internal sealed class ProductMetadata
		{

			private ProductMetadata()
			{
			}

			[Display(Name="Id", 
					 Description="Id of product")]
			public int ProductId { get; set; }

			[Display(Name="Name", 
					 Description="Name of product")]
			[Required(ErrorMessage="Product name must not be empty!",
					  AllowEmptyStrings=false)]
			public string Name { get; set; }

			[Display(Name="Description", 
					 Description="Description of product")]
			public string Description { get; set; }

			[Display(Name="Category", 
					 Description="Category of product")]
			[Required(ErrorMessage="Category must be selected!")]
			public Nullable<int> CategoryId { get; set; }

			[Display(Name="Category", 
					 Description="Category of product")]
			public Category Category { get; set; }

			[Display(Name="Price", 
					 Description="Price of product")]
			[Required(ErrorMessage="Product price name must not be empty!")]
			public Nullable<decimal> Price { get; set; }

		}
	}
}
