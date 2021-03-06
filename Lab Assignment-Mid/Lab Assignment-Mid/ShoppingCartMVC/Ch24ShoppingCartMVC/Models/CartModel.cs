﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ch24ShoppingCartMVC.Models;
using Ch24ShoppingCartMVC.Models.DataAccess;

namespace Ch24ShoppingCartMVC.Models
{
    public class CartModel
    {
        //Data Access methods 
        private List<ProductViewModel> GetCartFromDataStore()
        {
            List<ProductViewModel> cart;
            object objCart = HttpContext.Current.Session["cart"];
            //Convert objCart to List<ProductViewModel>

            var listObj = (List<ProductViewModel>)objCart;
            cart = listObj;
            if (cart == null)
            {   //Create the object cart

                cart = new List<ProductViewModel>();
                HttpContext.Current.Session["cart"] = cart;
                //Assign cart to the Session object cart
              //  cart =(List<ProductViewModel>) HttpContext.Current.Session["cart"];


                ////////CONFUSION HERE
            }
            return cart;
        }
        private ProductViewModel GetSelectedProduct(string id)
        {   //Create an OrderModel object called order
            OrderModel order = new OrderModel();
            //Call the method GetSelectedProduct of the class OrderModel. Return the object returned by the call.

            return order.GetSelectedProduct(id);
        }
        public CartViewModel GetCart(string id = "")
        {
            CartViewModel model = new CartViewModel();
            //Call the method GetCartFromDataStore
            model.Cart=GetCartFromDataStore();
            if (!string.IsNullOrEmpty(id))
                //Called the method GetSelectedProduct with parameter id and assign the return object to the AddedProduct
                model.AddedProduct=GetSelectedProduct(id);

            return model;
        }
      
        private void AddItemToDataStore(CartViewModel model)
        {   //Add the AddedProduct to the cart
            model.Cart.Add(model.AddedProduct);
        }
        public void AddToCart(CartViewModel model)
        {
            if (model.AddedProduct.ProductID != null)
            {
                //Get the product id of the added product
                string id = model.AddedProduct.ProductID;
                //Find the product in the car that matches the id using lambda expression.
                ProductViewModel inCart = model.Cart.Where(p => p.ProductID == id).FirstOrDefault();
                if (inCart == null)
                    //Call the method AddItemToDataStore
                    AddItemToDataStore(model);
                else
                    //Increase the Quantity by the quantity of the added product
                    inCart.Quantity +=  model.AddedProduct.Quantity;
            }
        }
        public ProductViewModel Get(string id)
        {
            using (HalloweenContext data = new HalloweenContext())
                return data.Set<ProductViewModel>().Find(id);
        }
        public void Delete(string id)
        {
            using (HalloweenContext data = new HalloweenContext())
            {
                data.Set<ProductViewModel>().Remove(Get(id));
                data.SaveChanges();
            }
            }





    }
}
