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

        public static bool ChagerListeContacts(ContactEntity.User user)
        {
            if (user == null)
            {

            }
            else
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

                //supprime les contacts
                dao.DaoContact.deleteContact((int) user.getIduser());

                //enregistre les contacts dans la base locale
                dao.DaoContact.saveContacts(liste);
            }
            return true;
        }

        public static void SaveContactAPI(ContactEntity.User user, System.Collections.Specialized.IOrderedDictionary oldValues, System.Collections.Specialized.IOrderedDictionary newValues)
        {
            if (user == null)
                return;

            //charge la liste des contacts par l'API
            string strJson = ContactClasse.ApiContact.GetStringJSonContacts(user);
            List<ContactEntity.Contact> ListeContacts = ContactClasse.GestionContacts.GetContacts(strJson);
            List<EvalEntity.Champ> listeChamp = dao.DaoChamp.GetChamps();

            int idcontact = Int32.Parse(oldValues["idcontact"] as string);

            Template template = GestionContacts.GetTemplate(ApiContact.GetStringJSonTemplate(user));

            int idChamp = 0;

            if (template != null && ListeContacts != null)
            {

                ContactEntity.Contact c = ListeContacts.Where(x => x.getIdcontact() == idcontact).FirstOrDefault();

                if (c != null)
                {
                    List<ContactEntity.Donnee> donnees = new List<ContactEntity.Donnee>();
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
                            ch = listeChamp.Where(x => x.libelle == "Date de naissance").FirstOrDefault();
                            DateTime d = DateTime.Parse(valeur);
                            valeur = d.ToString("yyyy-MM-dd");
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

        public static bool SaveToLocalBD(ContactEntity.User user, System.Collections.Specialized.IOrderedDictionary oldValues, System.Collections.Specialized.IOrderedDictionary newValues)
        {
            bool b;
            List<EvalEntity.Donnee> liste = new List<Donnee>();

            foreach (string key in newValues.Keys)
            {
                string valeur = newValues[key] as string;

                foreach (string prop in typeof(EvalEntity.Contact).GetProperties())
                {
                }

             
            }

           dao.DaoContact.saveContacts(lst)

            return b;
        }
     
    }
}