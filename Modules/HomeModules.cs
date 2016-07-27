using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;
using System.Linq;

namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };
      Get["/stylist/new"] = _ => {
        return View["stylist_form"];
      };
      Post["/stylist/new"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["stylist_name"]);
        newStylist.Save();
        return View["succsess.cshtml"];
      };
      Get
      // Post["/stylists/new"] = _ => {
      //   Stylist newStylist = new Stylist(Request.Form["stylist_name"]);
      //   newStylist.Save();
      //   List<Stylist> allStylists = Stylist.GetAll();
      //   return View["index.cshtml", allStylists];
      // };
      // Get["/clients/new"] = _ => {
      //   List<Client> allClients = Client.GetAll();
      //   return View["clients.cshtml", allClients];
      // };
      // Post["/clients/new"] = _ => {
      //   Client newClient = new Client(Request.Form["client_name"]);
      //   newClient.Save();
      //   List<Client> allClients = Client.GetAll();
      //   return View["clients.cshtml", allClients];
      // };
      // Get["clients/{id}"] = parameters => {
      //   Dictionary<string, object> Model = new Dictionary<string, object>();
      //   Client SelectedClient = Client.Find(parameters.id);
      //   List<Stylist> foundClient = SelectedClient.GetStylist();
      //   List<Stylist> foundStylist = Stylist.GetAll();
      //   Model.Add("client", SelectedClient);
      //   Model.Add("clientStylist", foundClient);
      //   Model.Add("stylist", foundStylist);
      //   return View["clients.cshtml", Model];
      // };
      // Get["stylist/{id}"] = parameters => {
      //   Dictionary<string, object> Model = new Dictionary<string, object>();
      //   Stylist SelectedStylist = Stylist.Find(parameters.id);
      //   List<Client> foundStylist = SelectedStylist.GetClient();
      //   List<Client> foundClient = Client.GetAll();
      //   Model.Add("stylist", SelectedStylist);
      //   Model.Add("stylistClients", foundStylist);
      //   Model.Add("client", foundClient);
      //   return View["stylist.cshtml", Model];
      // };
      // Get["/client/new"] = _ => {
      //   List<Client> allClients = Client.GetAll();
      //   return View["stylist.cshtml", allClients];
      // };
      // Get["client/{id}"] = parameters => {
      //   Dictionary<string, object> Model = new Dictionary<string, object>();
      //   var foundClient = Client.Find(parameters.id);
      //   var foundStylist = foundClient.GetId();
      //   Model.Add("client", foundClient);
      //   Model.Add("stylist", foundStylist);
      //   return View["stylist.cshtml", Model];
      // };
      // Post["/client/new"] = _ => {
      //   Client newClient = new Client(Request.Form["client_name"]);
      //   newClient.Save();
      //   List<Client> allClients = Client.GetAll();
      //   return View["stylist.cshtml", allClients];
      // };
    }
  }
}
