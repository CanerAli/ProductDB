using Microsoft.AspNetCore.Mvc;
using Zadacha05._12._2024.Data;
using Zadacha05._12._2024.Data.Models;
using Zadacha05._12._2024.Models;

namespace Zadacha05._12._2024.Controllers
{
   
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext db;
    public ProductController(ApplicationDbContext db)
    {
        this.db = db;
    }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel model) //Create
        {
            Products product = new Products
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Quantity = model.Quantity,
            };
            db.Products.Add(product);
            db.SaveChanges();
            return Redirect("/Home/Index");

        }
        public IActionResult All() //Read
        {
            List<ProductViewModel> model = db.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Quantity = x.Quantity
            }).ToList();
            return View(model);
        }
        public IActionResult Delete(int Id)
        {
            Products product = db.Products.FirstOrDefault(x => x.Id == Id);
            db.Products.Remove(product);
            db.SaveChanges();
            return Redirect("/Book/All"); //Kato izpalni ni vrusta kam All
        }
    }
}
