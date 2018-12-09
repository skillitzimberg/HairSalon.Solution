using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistsControllerTest
  {

    public void Dispose()
    {
      Stylist.ClearAll();
    }

    public StylistsControllerTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=scott_bergler_test;";
    }

    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      StylistsController controller = new StylistsController();

      ActionResult indexView = controller.Index();

      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void Index_ReturnsCorrectModel_True()
    {
      ViewResult indexView = new StylistsController().Index() as ViewResult;

      var modelDatatype = indexView.ViewData.Model;

      Assert.IsInstanceOfType(modelDatatype, typeof(List<Stylist>));
    }

    [TestMethod]
    public void New_ReturnsCorrectView_True()
    {
      StylistsController controller = new StylistsController();

      ActionResult newView = controller.New();

      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }

    [TestMethod]
    public void Create_ReturnsCorrectView_True()
    {
      StylistsController controller = new StylistsController();

      ActionResult createView = controller.Create("Mindy", "StCyr");

      Assert.IsInstanceOfType(createView, typeof(ViewResult));
    }

    [TestMethod]
    public void CreateStylist_RedirectsToCorrectAction_Index()
    {
      StylistsController controller = new StylistsController();
      RedirectToActionResult actionResult = controller.Create("Mindy", "StCyr") as RedirectToActionResult;

      string actionName = actionResult.ActionName;

      Assert.AreEqual(actionName, "Index");
    }

    [TestMethod]
    public void Show_ReturnsCorrectView_True()
    {
      StylistsController controller = new StylistsController();
      Stylist testStylist = new Stylist("Wes", "Cecil");
      testStylist.Save();
      ActionResult showView = controller.Show(testStylist.GetId());

      Assert.IsInstanceOfType(showView, typeof(ViewResult));
    }

    [TestMethod]
    public void Show_HasCorrectModelType_Dictionary()
    {
      Stylist testStylist = new Stylist("Wes", "Cecil");
      testStylist.Save();
      ViewResult showView = new StylistsController().Show(testStylist.GetId()) as ViewResult;

      var modelDatatype = showView.ViewData.Model;

      Assert.IsInstanceOfType(modelDatatype, typeof(Dictionary<string, object>));
    }

    [TestMethod]
    public void CreateClient_ReturnsCorrectView_True()
    {
      StylistsController controller = new StylistsController();
      Stylist testStylist = new Stylist("Mindy", "StCyr");
      testStylist.Save();

      ActionResult createView = controller.Create(testStylist.GetId(), "Scott", "Bergler", "5038905118");

      Assert.IsInstanceOfType(createView, typeof(ViewResult));
    }

    [TestMethod]
    public void CreateClient_ReturnsCorrectActionName_True()
    {
      StylistsController controller = new StylistsController();
      Stylist testStylist = new Stylist("Mindy", "StCyr");
      testStylist.Save();
      RedirectToActionResult actionResult = controller.Create(testStylist.GetId(), "Scott", "Bergler", "5038905118") as RedirectToActionResult;

      string actionName = actionResult.ActionName;

      Assert.AreEqual(actionName, "Show");
    }


  }
}
