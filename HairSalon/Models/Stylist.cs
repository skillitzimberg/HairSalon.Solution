using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
    private string _firstName;
    private string _lastName;
    private int _id;

    public Stylist(string firstName, string lastName, int id = 0)
    {
      _id = id;
      _firstName = firstName;
      _lastName = lastName;
    }

  }

}
