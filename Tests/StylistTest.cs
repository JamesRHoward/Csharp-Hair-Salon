using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseIsEmpty()
    {
      int result = Stylist.GetAll().Count;

      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_ReturnsTrueIfStylistIsTheSame()
    {
      Stylist firstStylist = new Stylist("Sammy");
      Stylist secondStylist = new Stylist("Sammy");

      Assert.Equal(firstStylist, secondStylist);
    }

    [Fact]
    public void Test_SaveMethod_SavesToDatabase()
    {
      Stylist testStylist = new Stylist("Mike");

      testStylist.Save();
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_SaveMethod_GivesIdToObject()
    {
      Stylist testStylist = new Stylist("Mike");

      testStylist.Save();
      Stylist savedStylist = Stylist.GetAll()[0];

      int restult = savedStylist.GetId();
      int testId = testStylist.GetId();

      Assert.Equal(testId, restult);
    }

    [Fact]
    public void Test_FindMethodLocatesObjectInDataBase()
    {
      Stylist testStylist = new Stylist("Dave");
      testStylist.Save();

      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      Assert.Equal(testStylist, foundStylist);
    }

    [Fact]
    public void Test_UpdateStylistNameInDatabase()
    {
      string stylistName = "Dave";
      Stylist testStylist = new Stylist(stylistName);
      testStylist.Save();
      string newStylistName = "David";

      testStylist.Update(newStylistName);

      string result = testStylist.GetStylistName();

      Assert.Equal(newStylistName, result);
    }

    [Fact]
    public void Test_DeleteMethodRemovesStylistFromDatabase()
    {
      List<Stylist> TestStylists = new List<Stylist>{};

      Stylist testStylist1 = new Stylist("Jim");
      testStylist1.Save();
      Stylist testStylist2 = new Stylist("Reggie");
      testStylist2.Save();

      Client TestClient1 = new Client("Bobbet", testStylist1.GetId());
      TestClient1.Save();
      Client TestClient2 = new Client("Hank", testStylist2.GetId());
      TestClient2.Save();

      testStylist1.Delete();
      TestClient1.Delete();

      List<Stylist> resultStylists = Stylist.GetAll();
      List<Stylist> testStylists = new List<Stylist> {testStylist2};

      List<Client> resultClients = Client.GetAll();
      List<Client> testClients = new List<Client> {TestClient2};

      Console.WriteLine(resultStylists);
      Console.WriteLine(testStylists);
      Assert.Equal(resultStylists, testStylists);
      Assert.Equal(resultClients, testClients);
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }
  }
}
