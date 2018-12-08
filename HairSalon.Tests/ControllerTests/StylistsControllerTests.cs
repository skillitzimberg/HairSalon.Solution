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

      ActionResult createView = controller.Create("Scott", "Bergler");

      Assert.IsInstanceOfType(createView, typeof(ViewResult));
    }

  }
}
