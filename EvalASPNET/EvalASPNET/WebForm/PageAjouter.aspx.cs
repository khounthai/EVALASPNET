using Contacts.entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contacts;
using EvalASPNET.classes;

namespace EvalASPNET.WebForm
{
    public partial class PagAjouter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var c = HttpContext.Current;
            User u = c.Session["userApi"] as User;
            SqlDataSource1.ConnectionString = dao.DaoBD.MyConnection.ConnectionString;
            Label1.Text = u.getIduser().ToString();
        }

        protected void ButtonRetour_Click(object sender, EventArgs e)
        {
            Server.Transfer("PageListeContacts.aspx", true);
        }

        protected void FormView1_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            User u = Session["userApi"] as User;
            if (u == null)
                return;

            Debug.Write(e.ToString());
            GestionContact.AjouterContactAPI(u, e.Values);

            //charge une liste des contacts avec leurs données via l'API
            List<EvalASPNET.Entity.Donnee> liste = GestionContact.ChagerListeContacts(u);

            if (liste != null && liste.Count > 0)
            {
                //enregistre les données de l'API vers la base locale
                dao.DaoContact.saveContacts(liste);
            }

        }

        protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {

        }

        protected void ButtonDeconnexion_Click(object sender, EventArgs e)
        {
            Session["userApi"] = null;
            Session["userLocal"] = null;
            Server.Transfer("PageAccueil.aspx", true);
        }
    }
}