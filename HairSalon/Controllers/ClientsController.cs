
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {

    [HttpGet("/clients")]
    public ActionResult Index()
    {
      List<Client> allClients = Client.GetAll();
      return View(allClients);
    }

    [HttpGet("/clients/new")]
    public ActionResult CreateForm()
    {
      return View();
    }

    [HttpPost("/clients")]
    public ActionResult Create(string description)
    {
      Client myClient = new Client(description);
      return RedirectToAction("Index");
    }

  }
}
