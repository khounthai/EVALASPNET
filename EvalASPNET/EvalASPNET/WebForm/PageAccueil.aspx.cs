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
        
        }

        protected void ButtonConnexion_Click(object sender, EventArgs e)
        {
            User u = GestionContact.GetUser(TextBoxlogin.Text.Trim(), TextBoxMPD.Text.Trim());
         
            if (u != null)
            {
                Entity.User user =new Entity.User()
                {
                    iduser = (int)u.getIduser(),
                    login = u.getLogin(),
                    password = TextBoxMPD.Text.Trim()
                };
                
                //enregistre user dans la base locale
                EvalASPNET.dao.DaoUser.saveUser(user);
                                
                //charge une liste des contacts avec leurs données via l'API
                List<EvalASPNET.Entity.Donnee> liste = GestionContact.ChagerListeContacts(u);
                
                if (liste != null && liste.Count > 0)
                {
                    //supprime les contacts de la base locale
                     dao.DaoContact.deleteContactByIDUser(user.iduser);
                    
                    //enregistre les données de l'API vers la base locale
                    dao.DaoContact.saveContacts(liste);
                }

                Session["userApi"] = u;
                Session["userLocal"] = user;
                Server.Transfer("PageListeContacts.aspx", true);
            }else
            {
                Entity.User user =dao.DaoUser.findByLoginAndPassword(TextBoxlogin.Text.Trim(), TextBoxMPD.Text.Trim());
                if (user != null)
                {
                    Session["userLocal"] = user;
                    Server.Transfer("PageListeContacts.aspx", true);
                }
            }
            
        }
    }
}