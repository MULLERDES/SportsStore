using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class NavigationController : Controller
    {
        private IProductRepository _productRepository;
        public NavigationController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        // GET: Navigation
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> Categories = _productRepository.Products.Select(x => x.Category).Distinct().OrderBy(x=>x);

            return PartialView(Categories);
        }
    }
}