
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {

    [HttpGet("/stylists/{stylistId}/clients/new")]
    public ActionResult New(int stylistId)
    {
       Stylist stylist = Stylist.Find(stylistId);
       return View();
    }

    [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
    public ActionResult Show(int stylistId, int clientId)
    {
      Client client = Client.Find(clientId);

      Stylist stylist = Stylist.Find(stylistId);

      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("client", client);
      model.Add("stylist", stylist);
      return new EmptyResult();
    }

  }
}
