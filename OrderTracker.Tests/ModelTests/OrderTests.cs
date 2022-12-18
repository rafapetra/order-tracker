using System.Collections.Generic;
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

    [TestMethod]
    public void GetAll_ReturnsAllOrderObjects_OrderList()
    {
      //Arrange
      string name01 = "Order one";
      string name02 = "Order two";
      Order newOrder1 = new Order(name01, "Pastries order", 50, "12/22/2020");
      Order newOrder2 = new Order(name02, "Pastries order", 50, "12/22/2020");
      List<Order> newList = new List<Order> { newOrder1, newOrder2 };

      //Act
      List<Order> result = Order.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

      [TestMethod]
  public void Find_ReturnsCorrectOrder_Order()
  {
    //Arrange
    string name01 = "Order one";
    string name02 = "Order two";
    Order newOrder1 = new Order(name01, "Pastries order", 50, "12/22/2020");
    Order newOrder2 = new Order(name02, "Pastries order", 50, "12/22/2020");

    //Act
   Order result = Order.Find(2);

    //Assert
    Assert.AreEqual(newOrder2, result);
  }
  }
}