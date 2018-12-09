using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {
    public void Dispose()
    {
      Client.ClearAll();
    }

    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=scott_bergler_test;";
    }

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
      string expectedLastName = "Bergler";
      Client newClient = new Client("Scott", expectedLastName, "5038905118", 1, 1);

      string actualLastName = newClient.GetLastName();

      Assert.AreEqual(expectedLastName, actualLastName);
    }

    [TestMethod]
    public void GetClientName_ReturnsFullName_String()
    {
      string expectedClientName = "Dudley Doorite";
      Client newStylist = new Client("Dudley", "Doorite", "555-555-5555", 1, 1);

      string actualClientName = newStylist.GetClientName();

      Assert.AreEqual(expectedClientName, actualClientName);
    }
    //
    // [TestMethod]
    // public void GetPhoneNumber_ReturnsPhoneNUmber_String()
    // {
    //   string expectedPhoneNumber = "5038905118";
    //   Client newClient = new Client("Scott", "Bergler", expectedPhoneNumber, 1, 1);
    //
    //   string actualPhoneNumber = newClient.GetPhoneNumber();
    //
    //   Assert.AreEqual(expectedPhoneNumber, actualPhoneNumber);
    // }
    //
    // [TestMethod]
    // public void GetStylistId_ReturnsStylistId_Int()
    // {
    //   int expectedStylistId = 1;
    //   Client newClient = new Client("Scott", "Bergler", "5038905118", expectedStylistId, 1);
    //
    //   int actualStylistId = newClient.GetStylistId();
    //
    //   Assert.AreEqual(expectedStylistId, actualStylistId);
    // }
    //
    // [TestMethod]
    // public void GetAll_ReturnsEmptyList_List()
    // {
    //   List<Client> expectedClientList = new List<Client> { };
    //
    //   List<Client> actualClientList = Client.GetAll();
    //
    //   CollectionAssert.AreEqual(expectedClientList, actualClientList);
    // }
    //
    // [TestMethod]
    // public void Save_SavesToDatabase_ClientList()
    // {
    //   Client newClient = new Client("Scott", "Bergler", "5038905118", 1);
    //   List<Client> expectedClientList = new List<Client>{newClient};
    //
    //   newClient.Save();
    //   List<Client> actualClientList = Client.GetAll();
    //
    //   CollectionAssert.AreEqual(expectedClientList, actualClientList);
    // }
    //
    // [TestMethod]
    // public void GetAll_ReturnsAllClients_ClientList()
    // {
    //   Client clientOne = new Client("Scott", "Bergler", "5038905118", 1);
    //   Client clientTwo = new Client("Millicent", "Zimdars", "5034217832", 2);
    //   List<Client> expectedClientList = new List<Client>{ clientOne, clientTwo };
    //
    //   clientOne.Save();
    //   clientTwo.Save();
    //   List<Client> actualClientList = Client.GetAll();
    //
    //   CollectionAssert.AreEqual(expectedClientList, actualClientList);
    // }
    //
    // [TestMethod]
    // public void Save_AssignsId_Int()
    // {
    //   Client clientOne = new Client("Scott", "Bergler", "5038905118", 1);
    //   Client clientTwo = new Client("Millicent", "Zimdars", "5034217832", 2);
    //   List<Client> expectedClientList = new List<Client>{ clientOne, clientTwo };
    //
    //   clientOne.Save();
    //   clientTwo.Save();
    //   List<Client> actualClientList = Client.GetAll();
    //
    //   Assert.AreEqual(expectedClientList[1].GetId(), actualClientList[1].GetId());
    // }
    //
    // [TestMethod]
    // public void Find_ReturnsCorrectClientFromDatabase_Client()
    // {
    //   Client clientOne = new Client("Scott", "Bergler", "5038905118", 1);
    //   Client clientTwo = new Client("Millicent", "Zimdars", "5034217832", 2);
    //
    //   clientOne.Save();
    //   clientTwo.Save();
    //   Client foundClient = Client.Find(clientTwo.GetId());
    //
    //   Assert.AreEqual(clientTwo, foundClient);
    // }

  }
}
