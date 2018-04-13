using Contacts.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contacts;
using System.Data;
using System.Diagnostics;
using EvalASPNET.classes;

namespace EvalASPNET.WebForm
{
    public partial class PageListeContacts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var c = HttpContext.Current;
            User u = c.Session["userApi"] as User;
        }
        
        protected void GridViewListeContact_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Debug.Write("gg");
            User u = Session["userApi"] as User;

            GestionContact.SaveContactAPI(u, e.OldValues, e.NewValues);
        }
    }
}