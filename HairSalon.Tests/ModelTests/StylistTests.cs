using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest
  {
    [TestMethod]
    public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
    {
      Stylist newStylist = new Stylist("Stephan", "Blair", 1);
      Assert.AreEqual(typeof(Stylist), newStylist.GetType());
    }

    [TestMethod]
    public void GetId_ReturnsId_Int()
    {
      int expectedId = 1;
      Stylist newStylist = new Stylist("Stephan", "Blair", expectedId);

      int actualId = newStylist.GetId();

      Assert.AreEqual(expectedId, actualId);
    }

    [TestMethod]
    public void GetFirstName_ReturnsFirstName_String()
    {
      string expectedFirstName = "Stephan";
      Stylist newStylist = new Stylist(expectedFirstName, "Blair", 1);

      string actualFirstName = newStylist.GetFirstName();

      Assert.AreEqual(expectedFirstName, actualFirstName);
    }

    [TestMethod]
    public void GetLastName_ReturnsLastName_String()
    {
      string expectedLastName = "Blair";
      Stylist newStylist = new Stylist("Stephan", expectedLastName, 1);

      string actualLastName = newStylist.GetLastName();

      Assert.AreEqual(expectedLastName, actualLastName);
    }
  }
}
