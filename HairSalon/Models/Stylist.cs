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
      _firstName = firstName;
      _lastName = lastName;
      _id = id;
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

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
       conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = (this.GetId() == newStylist.GetId());
        bool firstNameEquality = (this.GetFirstName() == newStylist.GetFirstName());
        bool lastNameEquality = (this.GetLastName() == newStylist.GetLastName());

        return (idEquality && firstNameEquality && lastNameEquality);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists (first_name, last_name) VALUES (@StylistFirstName, @StylistLastName);";

      MySqlParameter stylistFirstName = new MySqlParameter();
      stylistFirstName.ParameterName = "@StylistFirstName";
      stylistFirstName.Value = this._firstName;
      cmd.Parameters.Add(stylistFirstName);

      MySqlParameter stylistLastName = new MySqlParameter();
      stylistLastName.ParameterName = "@StylistLastName";
      stylistLastName.Value = this._lastName;
      cmd.Parameters.Add(stylistLastName);

      //Add this command for above 3 lines of code
      cmd.Parameters.AddWithValue("@StylistFirstName", this._firstName);
      cmd.Parameters.AddWithValue("@StylistLastName", this._lastName);
      cmd.ExecuteNonQuery();
      // _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistFirstName = rdr.GetString(1);
        string stylistLastName = rdr.GetString(2);
        Stylist newStylist = new Stylist(stylistFirstName, stylistLastName, stylistId);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }

  }
}
