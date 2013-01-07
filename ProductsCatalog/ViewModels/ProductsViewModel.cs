using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using ProductsCatalog.Web;
using ProductsCatalog.Web.Services;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using ProductsCatalog.Utils;
using Microsoft.Windows.Data.DomainServices;

namespace ProductsCatalog.ViewModels
{
	public class ProductsViewModel : ViewModelBase
	{
		ProductsCatalogContext _context = new ProductsCatalogContext();

		public ProductsViewModel()
		{
			AddNewProductCommand = new RelayCommand(AddNewCommandExecute, () => Products != null);
			DeleteProductCommand = new RelayCommand(DeleteCommandExecute, () => SelectedProduct != null);
			SaveCommand = new RelayCommand(SaveCommandExecute, () => _context.HasChanges);
			
			//notifies for changes
			_context.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(_context_PropertyChanged);

			this.LoadData();
		}

		void _context_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			SaveCommand.RaiseCanExecuteChanged();
		}

		public void LoadData()
		{
			//Load products
			var productsQuery = _context.GetProductsQuery();
			_context.Load<Product>(productsQuery, OnProductsLoaded, null);

			//Load categories
			var categoriesQuery = _context.GetCategoriesQuery();
			_context.Load<Category>(categoriesQuery, OnCategoriesLoaded, null);
		}

		private void OnProductsLoaded(LoadOperation<Product> op)
		{
			var products = op.Entities;
			Products = new EntityList<Product>(_context.Products, products);
		}

		private void OnCategoriesLoaded(LoadOperation<Category> op)
		{
			var categories = op.Entities;
			Categories = new ObservableCollection<Category>(categories);
		}

		private ObservableCollection<Category> _categories;
		public ObservableCollection<Category> Categories
		{
			get
			{
				return _categories;
			}

			set
			{
				if (_categories == value)
				{
					return;
				}
				_categories = value;
				RaisePropertyChanged("Categories");
			}
		}

		private ObservableCollection<Product> _products;
		public ObservableCollection<Product> Products
		{
			get
			{
				return _products;
			}

			set
			{
				if (_products == value)
				{
					return;
				}
				_products = value;
				RaisePropertyChanged("Products");
				AddNewProductCommand.RaiseCanExecuteChanged();
			}
		}

		private Product _selectedProduct;
		public Product SelectedProduct
		{
			get
			{
				return _selectedProduct;
			}

			set
			{
				if (_selectedProduct == value)
				{
					return;
				}
				_selectedProduct = value;
				RaisePropertyChanged("SelectedProduct");
				DeleteProductCommand.RaiseCanExecuteChanged();
			}
		}

		public RelayCommand AddNewProductCommand { get; set; }
		void AddNewCommandExecute()
		{
			var product = new Product();
			Products.Add(product);
			SelectedProduct = product;
		}

		public RelayCommand DeleteProductCommand { get; set; }
		void DeleteCommandExecute()
		{
			var product = SelectedProduct;
			Products.Remove(product);
		}

		public RelayCommand SaveCommand { get; set; }
		void SaveCommandExecute()
		{
			_context.SubmitChanges(OnSaved, null);
		}

		void OnSaved(SubmitOperation op)
		{
			if (op.HasError)
			{
				MessageBox.Show("Error occured!");
			}
			else
			{
				MessageBox.Show("Save success!");
			}
		}
	}
}
