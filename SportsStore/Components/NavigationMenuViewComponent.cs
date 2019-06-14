using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SportsStore.Models;
using System;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository repository;

        public NavigationMenuViewComponent(IProductRepository repo)
        {
            repository  = repo;
        }


        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x));
        }
        

        /*public string Invoke()
        {
            //string myStringOutput = String.Join(",", repository.Products.Select(p => p.ToString()).ToArray());
            string myStringOutput = String.Join(",", repository.Products.Select(p => p.Category).ToArray());

            return myStringOutput;
            
        }*/
    }
}
