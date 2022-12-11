using Microsoft.AspNetCore.Mvc;
using OrderTracker.Models;
using System.Collections.Generic;

namespace ForSale.Controllers
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
    public ActionResult Create(string name, string vendordescription)
    {
      Vendor newVendor = new Vendor(name, vendordescription);
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
      Vendor myVendor = Vendor.Find(vendorId);
      Order myOrder = new Order(title, description, price, date);
      myVendor.AddOrder(myOrder);
      List<Order> vendorOrders = myVendor.Orders;
      model.Add("orders", vendorOrders);
      model.Add("vendor", myVendor);
      return View("Show", model);
    }

  }

}