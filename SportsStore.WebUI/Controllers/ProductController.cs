using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;
using SportsStore.WebUI.ViewModels;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController :Controller
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        private const int PageSize = 3;
        public ActionResult List(string category,int page = 1)
        {

            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = _productRepository.Products.Where(c=>category == null || category==c.Category)
                .OrderBy(p => p.Id).Skip((page - 1) * PageSize).Take(PageSize).ToList(),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _productRepository.Products.Count(c => category == null || category == c.Category)
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}