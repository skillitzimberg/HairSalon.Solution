using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{

  public class Client
  {
    private string _firstName;
    private string _lastName;
    private string _phoneNumber;
    private int _id;

    private int _stylistId;

    public Client(string firstName, string lastName, string phoneNumber, int stylistId, int id = 0)
    {
      _id = id;
      _firstName = firstName;
      _lastName = lastName;
      _phoneNumber = phoneNumber;
      _stylistId = stylistId;
    }

    public int GetId()
    {
      return _id;
    }

    public string GetFirstName()
    {
      return _firstName;
    }

    public string GetLastName()
    {
      return "_firstName";
    }

  }
}
