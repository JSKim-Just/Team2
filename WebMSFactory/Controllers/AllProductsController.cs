﻿using MSFactoryDAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
namespace WebMSFactory.Controllers
{
    public class AllProductsController : Controller
    {
        ProductDAC dac = new ProductDAC();

        [HttpGet]
        public ActionResult Search(string Category, string ProductName, int page = 1)
        {
            int pageSize = 10;
            
            DataTable dt = dac.SelectAllProducts(Category, page, pageSize);

            List<ProductList> list = SqlHelper.ConvertDataTableToList<ProductList>(dt);

            var SortedList = (from items in list
                              where items.Product_Name.Contains(ProductName)
                              select items).ToList();


            ProductListViewModel model = new ProductListViewModel
            {
                ComboList = dac.GetComboList(),
                Products = SortedList,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = dac.GetTotalCount(Category)
                },
                CurrentCategory = Category
            };

            return View(model);
        }

        public ActionResult DetailProduct(int ProductID)
        {
            ProductListViewModel model = new ProductListViewModel();

            model.ProductDetail = dac.DetailProduct(ProductID);

            List<ProductList> list = new List<ProductList>();

            if (dac.ProductBOM(true, ProductID) != null)
                model.ForwardBom = dac.ProductBOM(true, ProductID);
            else
                model.ForwardBom = list;

            if (dac.ProductBOM(false, ProductID) != null)
                model.ReverseBom = dac.ProductBOM(false, ProductID);
            else
                model.ReverseBom = list;

            return View(model);
        }

    }
}