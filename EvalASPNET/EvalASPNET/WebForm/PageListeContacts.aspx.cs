using Contacts.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contacts;
using System.Data;

namespace EvalASPNET.WebForm
{
    public partial class PageListeContacts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var c = HttpContext.Current;
            User u = c.Session["user"] as User;
            if (u!=null)
            {
                List<Contact> liste = EvalASPNET.classes.GestionContact.ChagerListeContacts(u);
                DataTable table = ListeContactsForm.GetDataTableFromListContacts(liste);

                //ajoute image add et remove

                DataColumn col = null;

                //ajoute la colonne des idcontact
              
                Image img1= new Image();
                Image img2 = new Image();

                string url1 = @"~/Ressources/imgs/add.png";
                string url2 = @"~/Ressources/imgs/remove.png";

                img1.ImageUrl =url1;
                img2.ImageUrl =url2;

                col = new DataColumn("add",typeof(Image));
                table.Columns.Add(col);

                col = new DataColumn("remove", typeof(Image));                
                table.Columns.Add(col);
                foreach (DataRow r in table.Rows)
                {
                    r["add"] = img1;
                    r["remove"] = img2;
                }
                //

                GridViewListeContact.DataSource = table;
              
                GridViewListeContact.DataBind();

                img1.ImageUrl = url1;
                img2.ImageUrl = url2;

                // GridViewListeContact.Columns[0].Visible = false;
            }

        }
    }
}