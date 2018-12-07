using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest : IDisposable
  {
    public void Dispose()
    {
      Stylist.ClearAll();
    }

    public StylistTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=scott_bergler_test;";
    }

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

    [TestMethod]
    public void GetAll_ReturnsEmptyList_List()
    {
      List<Stylist> expectedStylistList = new List<Stylist> { };

      List<Stylist> actualStylistList = Stylist.GetAll();

      CollectionAssert.AreEqual(expectedStylistList, actualStylistList);
    }

    [TestMethod]
    public void Save_SavesToDatabase_StylistList()
    {
      Stylist newStylist = new Stylist("Stephan", "Blair", 1);
      List<Stylist> expectedList = new List<Stylist>{newStylist};

      newStylist.Save();
      List<Stylist> actualList = Stylist.GetAll();

      Console.WriteLine(expectedList.Count);
      Console.WriteLine(actualList.Count);
      CollectionAssert.AreEqual(expectedList, actualList);
    }

    [TestMethod]
    public void GetAll_ReturnsAllStylists_StylistList()
    {
      Stylist stylistOne = new Stylist("Stephan", "Blair", 1);
      Stylist stylistTwo = new Stylist("Holly", "Kindred", 1);
      List<Stylist> expectedList = new List<Stylist>{ stylistOne, stylistTwo };

      stylistOne.Save();
      stylistTwo.Save();
      List<Stylist> actualList = Stylist.GetAll();

      CollectionAssert.AreEqual(expectedList, actualList);
    }

  }
}
