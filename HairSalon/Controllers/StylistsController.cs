using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    [HttpGet("/stylists")]
    public ActionResult Index()
    {
      List<Stylist> allStylists = Stylist.GetAll();
      return View(allStylists);
    }

    [HttpGet("/stylists/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/stylists")]
    public ActionResult Create(string stylistFirstName, string stylistLastName)
    {
      Stylist newStylist = new Stylist(stylistFirstName, stylistLastName);
      List<Stylist> allStylists = Stylist.GetAll();
      return View("Index", 0);
    }

  }
}
