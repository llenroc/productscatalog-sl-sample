﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsCatalog.Web
{
	public partial class Category
	{
		public int CategoryId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual IEnumerable<Product> Products { get; set; }
	}
}