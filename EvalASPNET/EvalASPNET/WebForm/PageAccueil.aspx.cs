using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EvalASPNET.classes;
using Contacts.entity;

namespace EvalASPNET.WebForm
{
    public partial class PageAccueil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           /* MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = dao.DaoBD.MyConnection;
            cmd.CommandText = "select idcontact,dtcreation from contact";
            cmd.Connection.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            while(r.Read())
            {
                Debug.WriteLine(r.GetInt32(0) + "; " + r.GetDateTime(1).ToShortDateString());
            }
            r.Close();
            cmd.Connection.Close();*/

          
        }

        protected void ButtonConnexion_Click(object sender, EventArgs e)
        {
            User u = GestionContact.GetUser(TextBoxlogin.Text.Trim(), TextBoxMPD.Text.Trim());
            Session["user"] = u;
            Server.Transfer("PageListeContacts.aspx",true);
        }
    }
}