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
      return _lastName;
    }

    public string GetPhoneNumber()
    {
      return _phoneNumber;
    }

    public int GetStylistId()
    {
      return _stylistId;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
       conn.Dispose();
      }
    }

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientFirstName = rdr.GetString(1);
        string clientLastName = rdr.GetString(2);
        string clientPhoneNumber = rdr.GetString(3);
        int stylistId = rdr.GetInt32(4);
        Client newClient = new Client(clientFirstName, clientLastName, clientPhoneNumber, stylistId, clientId);
        allClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allClients;
    }

  }
}
