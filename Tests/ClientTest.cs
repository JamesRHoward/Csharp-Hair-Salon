using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseIsEmpty()
    {
      int result = Client.GetAll().Count;

      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_ReturnsTrueIfClientIsTheSame()
    {
      Client firstClient = new Client("Sammy");
      Client secondClient = new Client("Sammy");

      Assert.Equal(firstClient, secondClient);
    }

    [Fact]
    public void Test_SaveMethod_SavesToDatabase()
    {
      Client testClient = new Client("Mike");

      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_SaveMethod_GivesIdToObject()
    {
      Client testClient = new Client("Mike");

      testClient.Save();
      Client savedClient = Client.GetAll()[0];

      int restult = savedClient.GetId();
      int testId = testClient.GetId();

      Assert.Equal(testId, restult);
    }

    [Fact]
    public void Test_FindMethodLocatesObjectInDataBase()
    {
      Client testClient = new Client("Dave");
      testClient.Save();

      Client foundClient = Client.Find(testClient.GetId());

      Assert.Equal(testClient, foundClient);
    }

    [Fact]
    public void Test_UpdateClientNameInDatabase()
    {
      string clientName = "Dave";
      Client testClient = new Client(clientName);
      testClient.Save();
      string newClientName = "David";

      testClient.Update(newClientName);

      string result = testClient.GetClientName();

      Assert.Equal(newClientName, result);
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
