using Microsoft.AspNetCore.Mvc;
using ForSale.Models;
using System.Collections.Generic;

namespace OrderTracker.Controllers
{
  public class VendorsController : Controller
  {
    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendor> allVendors = Vendor.GetAll();
      return View(allVendors);
    }

    [HttpGet("vendors/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string name, string description)
    {
      Vendor newVendor = new Vendor(name, description);
      return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor myVendor = Vendor.Find(id);
      List<Order> vendorOrders = myVendor.Orders;
      model.Add("vendor", myVendor);
      model.Add("orders", vendorOrders);
      return View(model);
    }

    [HttpPost("/vendors/{vendorId}/orders")]
    public ActionResult Create(int vendorId, string title, string description, int price, string date)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      VendorsController myVendor = Vendor.Find(vendorId);
      Order myOrder = new Order(title, description, price, date);
      myVendor.AddOrder(myOrder);
      List<Order> vendorOrders = myVendor.Orders;
      model.Add("orders", vendorOrders);
      model.Add("vendor", myVendor);
      return View("Show", model);
    }
  }
}


//I think the quality and efficiency of the material fell sharply after c# course started. it is a lot more complex than JS but we are moving with the same pace, if not faster. We are hardly processing new info before 20 lessons of reading is thrown at us for the next sunday. 

//Also, the big reading lessons are always coinciding with code reviews week, so form thursday to sunday we are expected to do a code review (minimum 4 hours put in, always takes a lot more) + 15 pages of readings, 
//resultings in at least 35h/week when we signed up for 25. It just leads to frustration to those who work full time in a week. (40h of work a week plus 8h of sleep + 25h of epicodus = 120h of the week (168h). That leaves us with 48h/week for everything else, on top of code view + reading (10h). It becomes impossible. It almost feels like it was an impossible promise of learning all of this in a xnumber of weeks and smooching the material in that x number of weeks when it could be stretched out by a month or two in a more doable way without overloading and stressing out students with a full time job. we are already flying through allof this material so quickly that it even feels like we are not really learning, so there's no reason to be so fast. resulting in drop outs. what is the benefit of doing it so quickly if we dont be actually processing and learning?