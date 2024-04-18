using CrudLoginSignup.data;
using CrudLoginSignup.Models.product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudLoginSignup.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext context;

        public ProductController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create( Product p)
        {
            var pro = new Product() { 
            Name=p.Name,
            Description=p.Description,
            Price=p.Price,
            UID=p.UID,
            };
             await context.AddAsync(pro);
            await context.SaveChangesAsync();
            return RedirectToAction("Index","Home");
           
        }
        [HttpGet]
        public  IActionResult Read()
        {
            var products =  context.products.ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult GetSingle(int id)
        {
            var product = context.products.Include(e => e.User).SingleOrDefault(x => x.Id == id);
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product =await context.products.FindAsync(id);
            if (product == null)
            {
                return RedirectToAction("Read");
            }
            return View(product);
        }
        [HttpPost]

        public async Task<IActionResult> Edit(int id,Product p) {
            var product= await context.products.FindAsync(id);
            if (product == null)
            {
                return RedirectToAction("read");
            }
            product.Name = p.Name;
            product.Description = p.Description;
            product.Price=p.Price;
            await context.SaveChangesAsync();
            return RedirectToAction("read");
        }
       

     
        public async Task<IActionResult> Delete(int id)
        {
            var product = await context.products.FindAsync(id);
            if (product == null)
            {
                return RedirectToAction("Read");
            }
            context.products.Remove(product);
            context.SaveChanges(true);
            return RedirectToAction("Read");
        }
    }
}
