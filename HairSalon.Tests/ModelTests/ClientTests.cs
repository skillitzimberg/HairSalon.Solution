using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.TestTools
{
  [TestClass]
  public class ClientTest
  {
    // public void Dispose()
    // {
    //    : IDisposable
    //     Client.ClearAll();
    // }
    //
    // public ClientTest()
    // {
    //   DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=scott_bergler_test;";
    // }

    [TestMethod]
    public void ClientConstructor_CreatesInstanceOfClient_Client()
    {
      Client newClient = new Client("Scott", "Bergler", "5038905118", 1, 1);
      Assert.AreEqual(typeof(Client), newClient.GetType());
    }

    [TestMethod]
    public void GetId_ReturnsId_Int()
    {
      int expectedId = 1;
      Client newClient = new Client("Scott", "Bergler", "5038905118", 1, expectedId);

      int actualId = newClient.GetId();

      Assert.AreEqual(expectedId, actualId);
    }

    [TestMethod]
    public void GetFirstName_ReturnsFirstName_String()
    {
      string expectedFirstName = "Scott";
      Client newClient = new Client(expectedFirstName, "Bergler", "5038905118", 1, 1);

      string actualFirstName = newClient.GetFirstName();

      Assert.AreEqual(expectedFirstName, actualFirstName);
    }

    [TestMethod]
    public void GetLastName_ReturnsLastName_String()
    {
      string expectedLastName = "Scott";
      Client newClient = new Client(expectedLastName, "Bergler", "5038905118", 1, 1);

      string actualLastName = newClient.GetLastName();

      Assert.AreEqual(expectedLastName, actualLastName);
    }

  }
}
