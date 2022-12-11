using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderTracker.Models;

namespace OrderTracker.Models
{
  public class Vendor
  {
    public string Name { get; set; }
    public string VendorDescription { get; set; }
    public int Id { get; }
    private static List<Vendor> _instances = new List<Vendor> { };
    public List<Order> Orders { get; set; }

    public Vendor(string name, string description)
    {
      Name = name;
      VendorDescription = description;
      _instances.Add(this);
      Id = _instances.Count;
      Orders = new List<Order> { };
    }

    public static List<Vendor> GetAll()
    {
      return _instances;
    }

    public static Vendor Find(int searchId)
    {
      return _instances[searchId - 1];
    }

    public void AddOrder(Order order)
    {
      Orders.Add(order);
    }
  }
}