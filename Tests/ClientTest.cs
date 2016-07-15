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
    public void Test_ReturnsTrueIfStylistIsTheSame()
    {
      Client firstClient = new Client("Sammy");
      Client secondClient = new Client("Sammy");

      Assert.Equal(firstClient, secondClient);
    }

    public void Dispose()
    {
      // Client.DeleteAll();
    }
  }
}
