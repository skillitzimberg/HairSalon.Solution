using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientsControllerTest
  {
    [TestMethod]
    public void New_ReturnsCorrectView_True()
    {
      ClientsController controller = new ClientsController();
      Stylist testStylist = new Stylist("Wes", "Cecil");
      testStylist.Save();

      ActionResult newView = controller.New(testStylist.GetId());

      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }

    [TestMethod]
    public void Show_ReturnsCorrectView_True()
    {
      ClientsController controller = new ClientsController();
      Stylist testStylist = new Stylist("Wes", "Cecil");
      testStylist.Save();
      Client testClient = new Client("Scott", "Bergler", "5038905118", testStylist.GetId());
      ActionResult showView = controller.Show(testStylist.GetId(), testClient.GetId());

      Assert.IsInstanceOfType(showView, typeof(ViewResult));
    }

  }
}
