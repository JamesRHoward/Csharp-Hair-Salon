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

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
