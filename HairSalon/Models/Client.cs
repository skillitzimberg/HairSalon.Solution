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

    // public override bool Equals(System.Object otherClient)
    // {
    //   if (!(otherClient is Client))
    //   {
    //     return false;
    //   }
    //   else
    //   {
    //     Client newClient = (Client) otherClient;
    //     bool idEquality = (this.GetId() == newClient.GetId());
    //     bool firstNameEquality = (this.GetFirstName() == newClient.GetFirstName());
    //     bool lastNameEquality = (this.GetLastName() == newClient.GetLastName());
    //     bool phoneNumberEquality = (this.GetPhoneNumber() == newClient.GetPhoneNumber());
    //     bool stylistEquality = this.GetStylistId() == newClient.GetStylistId();
    //     return (idEquality && firstNameEquality && lastNameEquality && phoneNumberEquality && stylistEquality);
    //   }
    // }

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

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (first_name, last_name, phone_number, stylist_id) VALUES (@ClientFirstName, @ClientLastName, @ClientPhoneNumber, @StylistId);";

      MySqlParameter clientFirstName = new MySqlParameter();
      clientFirstName.ParameterName = "@ClientFirstName";
      clientFirstName.Value = this._firstName;
      cmd.Parameters.Add(clientFirstName);

      MySqlParameter clientLastName = new MySqlParameter();
      clientLastName.ParameterName = "@ClientLastName";
      clientLastName.Value = this._lastName;
      cmd.Parameters.Add(clientLastName);

      MySqlParameter clientPhoneNumber = new MySqlParameter();
      clientPhoneNumber.ParameterName = "@ClientPhoneNumber";
      clientPhoneNumber.Value = this._phoneNumber;
      cmd.Parameters.Add(clientPhoneNumber);

      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@StylistId";
      stylistId.Value = this._stylistId;
      cmd.Parameters.Add(stylistId);

      //Add this command for above 3 lines of code
      cmd.Parameters.AddWithValue("@ClientFirstName", this._firstName);
      cmd.Parameters.AddWithValue("@ClientLastName", this._lastName);
      cmd.Parameters.AddWithValue("@ClientPhoneNumber", this._phoneNumber);
      cmd.Parameters.AddWithValue("@StylistId", this._stylistId);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      //To fail Saves to database method - declare method and keep it empty
      //To fail Save AssignsId test -
      //do not add the "_id = (int) cmd.LastInsertedId;" line
    }


  }
}
