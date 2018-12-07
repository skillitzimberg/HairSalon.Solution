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

  }
}
