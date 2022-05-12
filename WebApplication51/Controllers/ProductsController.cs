using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication51.Models;
using WebApplication51.Models.ViewModel;

namespace WebApplication51.Controllers
{
    public class ProductsController : Controller
    {
        ApplicationDbcontext dbcontext = new ApplicationDbcontext();
        // GET: Products
        public ActionResult Index()
        {
            //var products = dbcontext.products.ToList();
            var products = (from e in dbcontext.products
                            join
                            c in dbcontext.Categories
                            on e.category.Id equals c.Id

                            select new ProductListViewModel()
                            {
                                Id=e.Id,
                                Description=e.Description,
                                Quantity=e.Quantity,
                                Price=e.Price,
                                category=c.name

                            });


            return View(products);
        }
        public ActionResult Create()
        {
            var cats = dbcontext.Categories.ToList();
            ViewBag.cats = cats;
            return View();
        }

           [HttpPost]
        public ActionResult Create(ProductViewModel product)
        {
            var cat = dbcontext.Categories.SingleOrDefault(e => e.Id == product.category);
            var objproduct = new products()
            {
                Myproperty=product.Myproperty,
                Quantity = product.Quantity,
                Description = product.Description,
                Price= product.Price,
                category= cat

            };
            dbcontext.products.Add(objproduct);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var product = dbcontext.products.SingleOrDefault(e => e.Id == id);
            dbcontext.products.Remove(product);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var product = dbcontext.products.SingleOrDefault(e => e.Id == id);
            return View(product);
        }

         [HttpPost]
        public ActionResult Edit(products product)
        {

            dbcontext.Entry(product).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}