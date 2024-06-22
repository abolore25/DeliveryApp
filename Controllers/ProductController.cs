using DeliveryApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Controllers;
public class ProductController : Controller
{
    private readonly List<Product> _products; //Assume this is your list of products for demonstration

    public ProductController()
    {
        //Initialize with some dummy data for demonstration
        _products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 10.99m },
            new Product { Id = 2, Name = "Product 2", Price = 20.99m },
            new Product {Id = 3, Name = "Product 3", Price = 30.99m}              
        };
    }

    public ActionResult Index()
    {
        return View(_products);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Product product)
    {
        if (ModelState.IsValid)
        {
            // Add the new product to the list
            _products.Add(product);
            //Redirect to the product list 
            return RedirectToAction(nameof(Index));
        }
        // If the model is not valid, return the create view with errors
        return View(product);
    }
        [HttpGet]
        public IActionResult Editt(int id)
        {
            //Find the product by id
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();  
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //Find the index of the existing product in the list
                var index = _products.FindIndex(p => p.Id == id);
                if (index == -1)
                {
                    return NotFound();
                }
                // Update the product in the list
                _products[index] = product;
                //Redirect to the product list
                return RedirectToAction(nameof(Index));
            } 
            return View(product);
        }
        [HttpGet]
        public IActionResult Delete (int id)
        {
            // Find the product by id 
            var product = _products.FirstOrDefault( p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            //Find the product by id 
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            //Remove the product from the list
            _products.Remove(product);
            //Redirect to the product list
            return RedirectToAction(nameof(Index));
        }

    
}
