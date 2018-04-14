using Contacts.classes;
using Contacts.entity;
using EvalASPNET.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactClasse = Contacts.classes;
using ContactEntity = Contacts.entity;
using EvalEntity = EvalASPNET.Entity;


namespace EvalASPNET.classes
{
    public class GestionContact
    {
        public static ContactEntity.User GetUser(string login, string password)
        {
            ContactEntity.User u = null;
            string strJson;
            strJson = ContactClasse.ApiContact.GetStringJSonUser(login, password);
            u = ContactClasse.GestionContacts.GetUser(strJson);
            return u;
        }

        public static List<EvalEntity.Donnee> ChagerListeContacts(ContactEntity.User user)
        {
            string strJson = ContactClasse.ApiContact.GetStringJSonContacts(user);
            List<ContactEntity.Contact> ListeContacts = ContactClasse.GestionContacts.GetContacts(strJson);
            List<EvalEntity.Donnee> liste = new List<EvalEntity.Donnee>();

            Dictionary<int, EvalEntity.Champ> listeChamp = new Dictionary<int, EvalEntity.Champ>();

            foreach (ContactEntity.Contact c in ListeContacts)
            {
                foreach (ContactEntity.Donnee cd in c.getDonnees())
                {
                    EvalEntity.Donnee d = new EvalEntity.Donnee()
                    {
                        iduser = (int)c.getIduser(),
                        iddonnee = (int)cd.getIddonnee(),
                        idcontact = (int)c.getIdcontact(),
                        libelleChamp = cd.getLibellechamp(),
                        valeur = cd.getValeur(),
                        ordre = (int)cd.getOrdre(),
                        accueil = cd.isAccueil()
                    };
                    liste.Add(d);

                    //remplit la liste des champs
                    if (!listeChamp.ContainsKey((int)cd.getIdchamp()))
                    {
                        listeChamp.Add((int)cd.getIdchamp(), new EvalEntity.Champ() { idchamp = (int)cd.getIdchamp(), libelle = cd.getLibellechamp() });
                    }
                }
            }

            //enregitre les champs dans la table locale, pour gestion des mises à jours                
            dao.DaoChamp.saveChamps(listeChamp.Values.ToList());

            return liste;
        }

        public static void SaveContactAPI(ContactEntity.User user, System.Collections.Specialized.IOrderedDictionary oldValues, System.Collections.Specialized.IOrderedDictionary newValues)
        {
            if (user == null)
                return;

            //charge la liste des contacts par l'API
            string strJson = ContactClasse.ApiContact.GetStringJSonContacts(user);
            List<ContactEntity.Contact> ListeContacts = ContactClasse.GestionContacts.GetContacts(strJson);
            List<EvalEntity.Champ> listeChamp = dao.DaoChamp.GetChamps();

            int idcontact = 0;

            if (oldValues != null)
                idcontact = Int32.Parse(oldValues["idcontact"] as string);

            Template template = GestionContacts.GetTemplate(ApiContact.GetStringJSonTemplate(user));
            
            if (template != null && ListeContacts != null)
            {
                ContactEntity.Contact c = ListeContacts.Where(x => x.getIdcontact() == idcontact).FirstOrDefault();

                if (c != null)
                {
                    List<ContactEntity.Donnee> donnees = SetListeDonnees(newValues);
                  
                    c.setIduser(user.getIduser());
                    c.setDtcreation(DateTime.Now);
                    c.setFavoris(false);
                    c.setActif(true);
                    c.setDonnees(donnees);

                    c.setIduser(user.getIduser());
                    ContactWrapper cw = new ContactWrapper();
                    cw.setContact(c);
                    cw.setIdtemplate(template.getIdtemplate());
                    ApiContact.SetContact(cw);
                }
            }
        }
        
        public static bool AjouterContactAPI(ContactEntity.User user, System.Collections.Specialized.IOrderedDictionary newValues)
        {
            ContactEntity.Contact c = new ContactEntity.Contact();
          
            Template template = GestionContacts.GetTemplate(ApiContact.GetStringJSonTemplate(user));
            c.setIdcontact(0);
            c.setIduser(template.getIduser());
            c.setDtcreation(DateTime.Now);
            c.setFavoris(false);
            c.setActif(true);

            if (c != null)
            {
                List<ContactEntity.Donnee> donnees = SetListeDonnees(newValues);
               
                c.setIduser(user.getIduser());
                c.setDtcreation(DateTime.Now);
                c.setFavoris(false);
                c.setActif(true);
                c.setDonnees(donnees);

                c.setIduser(user.getIduser());
                ContactWrapper cw = new ContactWrapper();
                cw.setContact(c);
                cw.setIdtemplate(template.getIdtemplate());
                ApiContact.SetContact(cw);
                return true;
            }

            return false;
        }

        private static List<ContactEntity.Donnee> SetListeDonnees(System.Collections.Specialized.IOrderedDictionary newValues)
        {
            List<EvalEntity.Champ> listeChamp = dao.DaoChamp.GetChamps();
            List<ContactEntity.Donnee> donnees = new List<ContactEntity.Donnee>();
            int idChamp = 0;

            foreach (string key in newValues.Keys)
            {
                string valeur = newValues[key] as string;

                //recherche l'idChamp
                EvalEntity.Champ ch = null;

                if (key == "Prenom")
                {
                    ch = listeChamp.Where(x => x.libelle == "Prénom").FirstOrDefault();
                }
                else if (key == "DateNaissance")
                {
                    try
                    {
                        ch = listeChamp.Where(x => x.libelle == "Date de naissance").FirstOrDefault();
                        DateTime d = DateTime.Parse(valeur);
                        valeur = d.ToString("yyyy-MM-dd");
                    }
                    catch
                    {
                        valeur = null;
                    }
                }
                else
                {
                    ch = listeChamp.Where(x => x.libelle == key).FirstOrDefault();
                }

                if (ch != null)
                {
                    idChamp = ch.idchamp;
                    ContactEntity.Donnee d = new ContactEntity.Donnee();
                    d.setIdchamp(idChamp);
                    d.setValeur(valeur);
                    donnees.Add(d);
                }
            }
            return donnees;
        }

    }
}