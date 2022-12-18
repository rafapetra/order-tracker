using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderTracker.Models;

namespace OrderTracker.Tests
{
  [TestClass]
  public class VendorTest
  {

    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_VendorName()
    {
      Vendor newVendor = new Vendor("Vendor 01", "Vendor since 2019");
      string myVendor = "Vendor 01";
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
      Assert.AreEqual(myVendor, newVendor.Name);
    }


    [TestMethod]
    public void GetAll_ReturnsAllVendorObjects_OrderList()
    {
      //Arrange
      string name01 = "Vendor one";
      string name02 = "Vendor two";
      Order newVendor1 = new Vendor(name01, "vendor since 2019", 50, "12/22/2019");
      Order newVendor2 = new Vendor(name02, "vendor since 2020", 50, "12/22/2020");
      List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };

      //Act
      List<Vendor> result = Vendor.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

      [TestMethod]
  public void Find_ReturnsCorrectVendor_Order()
  {
    //Arrange
    string name01 = "Vendor one";
    string name02 = "Vendor two";
      Vendor newVendor1 = new Vendor(name01, "vendor since 2019", 50, "12/22/2019");
      Vendor newVendor2 = new Vendor(name02, "vendor since 2020", 50, "12/22/2020");

    //Act
   Vendor result = Vendor.Find(2);

    //Assert
    Assert.AreEqual(newVendor2, result);
  }

  }
}