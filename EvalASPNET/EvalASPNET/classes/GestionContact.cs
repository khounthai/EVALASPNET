using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contacts.classes;
using Contacts.entity;


namespace EvalASPNET.classes
{
    public class GestionContact
    {
        public static User GetUser(string login, string password)
        {
            User u = null;
            string strJson;
            strJson = ApiContact.GetStringJSonUser(login, password);
            u = GestionContacts.GetUser(strJson);
            return u;
        }

        public static List<Contact> ChagerListeContacts(User user)
        {
            List<Contact> ListeContacts = null;
            string strJson;
            if (user != null)
            {

            }
            else
            {
                strJson = ApiContact.GetStringJSonContacts(user);
                ListeContacts = GestionContacts.GetContacts(strJson);
            }

            strJson = ApiContact.GetStringJSonContacts(user);
            ListeContacts = GestionContacts.GetContacts(strJson);

            return ListeContacts;
        }
    }
}