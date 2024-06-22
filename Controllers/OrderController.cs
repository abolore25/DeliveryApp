using DeliveryApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Controllers;

public class OrderController : Controller
{
    private readonly List<Order> _orders; //Assume this is your list of orders for demonstration

    public OrderController()
    {
    //Initialize with some dummy data for demonstration
        _orders = new List<Order>
        {
            new Order {Id = 1, TotalAmount = 10000, OrderDate = DateTime.Now},
            new Order {Id = 2, TotalAmount = 15000, OrderDate = DateTime.Now},
            new Order {Id = 3, TotalAmount = 20000,  OrderDate = DateTime.Now}
        };
    }

    public IActionResult Index()
    {
        return View(_orders);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Order order) 
    {
        if (ModelState.IsValid)
        {
            //Add the new order to the list
            _orders.Add(order);
            //Redirect to the order list 
            return RedirectToAction(nameof(Index));
        }
        //If the model state is not valid, return the create
        return View(order);
    }


    [HttpGet]
    public IActionResult Edit(int id)
    {
        // Find the order by id
        var order = _orders.FirstOrDefault( o => o.Id == id);
        if (order == null)
        {
            return NotFound();
        }
        return View(order);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Order order)
    {
        if (id != order.Id)
        {
            return NotFound();
        }
    
        if (ModelState.IsValid)
        {
            // Find the index of the existing order in the list
            var index = _orders.FindIndex(o => o.Id == id);
            if (index == -1)
            {
                return NotFound();
            }
            // Update the order in the list
            _orders[index] = order;
            //Redirect to the order list
            return RedirectToAction(nameof(Index));
        }
        return View(order);
    }




    [HttpGet]
    public IActionResult Delete(int id)
    {
        //Find the order by id
        var order = _orders.FirstOrDefault(o => o.Id  == id);
        if (order == null)
        {
            return NotFound();
        }
        return View(order);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        //find the order by id
        var order = _orders.FirstOrDefault (o => o.Id == id);
        if (order == null)
        {
            return NotFound();
        }
    
        // Remove the order from the list
        _orders.Remove(order);
        //Redirect to the order list
        return RedirectToAction(nameof(Index));
    }
   

}