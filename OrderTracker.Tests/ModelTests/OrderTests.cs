using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderTracker.Models;

namespace OrderTracker.Tests
{
  [TestClass]
  public class OrderTest
  {

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("Order One", "Pastries order", 50, "12/22/2020");
      string testOrder = "Order One";
      Assert.AreEqual(typeof(Order), newOrder.GetType());
      Assert.AreEqual(testOrder, newOrder.Title);
    }

  }
}