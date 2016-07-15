using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalon
{
  public class Stylist
  {
    private int _id;
    private string _stylist;

    public Stylist(string stylist, int id = 0)
    {
      _id = id;
      _stylist = stylist;
    }
    public int GetId()
    {
      return _id;
    }
    public string GetStylist()
    {
      return _stylist;
    }
    public void SetStylist(string newStylist)
    {
      _stylist = newStylist;
    }
    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist>{};

      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistStylist = rdr.GetString(1);
        Stylist newStylist = new Stylist(stylistStylist, stylistId);
        allStylists.Add(newStylist);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allStylists;
    }
  }
}
