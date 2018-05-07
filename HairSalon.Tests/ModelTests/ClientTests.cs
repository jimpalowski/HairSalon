using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTests : IDisposable
  {
    public void Dispose()
    {
      Client.DeleteAll();
      Stylist.DeleteAll();
    }

    public ClientTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=hairsalon_test";
    }
    [TestMethod]
    public void ClientsName_EqualTheSameWithDate()
  {
    // Arrange
    Client firstClient = new Client("Rock", "2003-01-01");
    Client secondClient = new Client("Rock", "2003-01-01");

    //Act
    firstClient.Save();
    secondClient.Save();

    // Assert
    Assert.AreEqual(true, firstClient.GetName().Equals(secondClient.GetName()));
  }

  [TestMethod]
  public void Find_ClientInside_DataBase()
  {
    //Arrange
    Client testClient = new Client("Rock", "2003-01-01");
    testClient.Save();

    //Act
    Client foundClient = Client.Find(testClient.GetId());

    //Assert
    Assert.AreEqual(testClient, foundClient);
  }
    [TestMethod]
    public void Delete_AllCLientDelete()
    {
      //arrange
       Client newClient = new Client("Rock", "2003-01-01");

       //act
       Client.DeleteAll();
       int result = Client.GetAll().Count;

       //assert
       Assert.AreEqual(0, result);
    }

  }
}
