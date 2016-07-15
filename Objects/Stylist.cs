using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalon
{
  public class Stylist
  {
    private int _id;
    private string _stylistName;

    public Stylist(string stylistName, int id = 0)
    {
      _id = id;
      _stylistName = stylistName;
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
        bool stylistEquality = (this.GetStylistName() == newStylist.GetStylistName());
        return (stylistEquality);
      }
    }

    public int GetId()
    {
      return _id;
    }
    public string GetStylistName()
    {
      return _stylistName;
    }
    public void SetStylistName(string newStylistName)
    {
      _stylistName = newStylistName;
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
        string stylistName = rdr.GetString(1);
        Stylist newStylist = new Stylist(stylistName, stylistId);
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
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr;
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO stylists (stylist) OUTPUT INSERTED.id VALUES (@stylistName);", conn);

      SqlParameter stylistParameter = new SqlParameter();
      stylistParameter.ParameterName = "@stylistName";
      stylistParameter.Value = this.GetStylistName();
      cmd.Parameters.Add(stylistParameter);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }
    public static Stylist Find(int id)
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists WHERE id = @stylistId;", conn);

      SqlParameter stylistIdParameter = new SqlParameter();
      stylistIdParameter.ParameterName = "@stylistId";
      stylistIdParameter.Value = id.ToString();

      cmd.Parameters.Add(stylistIdParameter);
      rdr = cmd.ExecuteReader();

      int foundStylistId = 0;
      string foundStylistName = null;

      while (rdr.Read())
      {
        foundStylistId = rdr.GetInt32(0);
        foundStylistName = rdr.GetString(1);
      }
      Stylist foundStylist = new Stylist(foundStylistName, foundStylistId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundStylist;
    }
    public void Update(string newStylist)
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr;
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE stylists SET stylist = @newStylist OUTPUT INSERTED.stylist WHERE id = @stylistId;", conn);

      SqlParameter newStylistParameter = new SqlParameter();
      newStylistParameter.ParameterName = "@newStylist";
      newStylistParameter.Value = newStylist;
      cmd.Parameters.Add(newStylistParameter);

      SqlParameter stylistIdParameter = new SqlParameter();
      stylistIdParameter.ParameterName = "@stylistId";
      stylistIdParameter.Value = this.GetId();
      cmd.Parameters.Add(stylistIdParameter);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._stylistName = rdr.GetString(0);
      }
      if (conn != null)
      {
        conn.Close();
      }
      if (rdr != null)
      {
        rdr.Close();
      }
    }
    public List<Client> GetClient()
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists WHERE client_id = @clientId;", conn);
      SqlParameter clientIdParameter = new SqlParameter();
      clientIdParameter.ParameterName = "@clientId";
      clientIdParameter.Value = this.GetId();
      cmd.Parameters.Add(clientIdParameter);
      rdr = cmd.ExecuteReader();

      List<Client> clients = new List<Client>{};
      while (rdr.Read())
      {
        int foundClientId = rdr.GetInt32(0);
        string foundClientName = rdr.GetString(1);
        Client newClient = new Client(foundClientName, foundClientId, this.GetId());
        clients.Add(newClient);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return clients;
    }
    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM stylists WHERE id = @stylistId;", conn);

      SqlParameter stylistIdParameter = new SqlParameter();
      stylistIdParameter.ParameterName = "@stylistId";
      stylistIdParameter.Value = this.GetId();

      cmd.Parameters.Add(stylistIdParameter);
      cmd.ExecuteNonQuery();

      if (conn != null);
      {
        conn.Close();
      }
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM stylists;", conn);
      cmd.ExecuteNonQuery();
    }
  }
}
