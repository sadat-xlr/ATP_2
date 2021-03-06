﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ch24ShoppingCartMVC.Models;

namespace Ch24ShoppingCartMVC.Controllers
{
    public class CheckoutController : Controller
    {
        
        // GET: /Checkout/
        private CartModel cart = new CartModel();
        public ActionResult Index()
        {
           CartViewModel inCart = (CartViewModel)TempData["cart"];
           if (inCart == null)
               inCart = cart.GetCart();
           
            
            return View(inCart);
        }

    }
}
