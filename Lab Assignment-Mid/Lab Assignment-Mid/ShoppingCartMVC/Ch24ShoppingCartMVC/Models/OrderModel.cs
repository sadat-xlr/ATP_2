using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ch24ShoppingCartMVC.Models;
using Ch24ShoppingCartMVC.Models.DataAccess;

namespace Ch24ShoppingCartMVC.Models {
    public class OrderModel
    { private List<ProductViewModel> products;
        //Implement GetAllProductsFromDataStore
        public List<Product> GetAllProductsFromDataStore()
        {    

            using (HalloweenContext data = new HalloweenContext())
            {  //get all the products from the Collection Products order by name using HalloweenEntities=Halloween;
               // var list = from item in data.Products orderby item.Name ascending select item;
               
                return data.Products.OrderBy(x => x.Name).ToList() ;
            }
        }
        //Implement the method ConvertToViewModel
        private ProductViewModel ConvertToViewModel(Product product)
        {
            ProductViewModel model = new ProductViewModel();
            model.ProductID = product.ProductID;
            model.Name = product.Name;
            model.ImageFile = product.ImageFile;
            model.LongDescription = product.LongDescription;
            model.UnitPrice = product.UnitPrice;
            
            //implement other required properties
           
            return model;
        }
        //Implement the method GetProductList
        public List<ProductViewModel> GetProductsList() {
            if (this.products == null)
                //Call the method GetAllProducts
                this.GetAllProducts();
            //Return the products
            return products;
        }
        public List<ProductViewModel> GetAllProducts()
        {
            List<ProductViewModel> productmodels = new List<ProductViewModel>();
             //Call the GetAllProductsFromDataStore()
            this.GetAllProductsFromDataStore();
            foreach (Product p in products)
            {  //Call the method ConvertToViewModel to convert p and pass the method ConvertToViewModel to the method add of the productmodels
                this.ConvertToViewModel(p);
            }
            return productmodels;
        }
        
        public Product GetProductByIdFromDataStore(string id)
        {
            using (HalloweenContext data = new HalloweenContext())
            {  //Get a product from Products of data where ProductID is matched with id parameter
              
              

                return new Product();
                //  return _________________________________________.FirstOrDefault(); this line is provided by sir
            }
        }
        public OrderViewModel GetOrderInfo(string id)
        {
            OrderViewModel order = new OrderViewModel();
            //Call the method GetSelectedProduct and assign the return value to SelectedProduct property
           //****work needed
            return order;
        }  
        public ProductViewModel GetSelectedProduct(string id)
        {
            if (this.products == null)
                //call the method ConvertToViewModel and pass the method GetProductByIdFromDataStore(id)
                
                return new ProductViewModel();//dummy objct added by me for remoing error--sadat
            else
                //Get the product from the products where ProductID is matched with id (Using Lambda expression)
                return new ProductViewModel();//dummy objct added by me for remoing error--sadat
        }
              
        
        
        
        
        
    }
}