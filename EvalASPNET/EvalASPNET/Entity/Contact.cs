using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvalASPNET.Entity
{
    public class Contact
    {
        public int idcontact { set; get; }
        public int iduser { set; get; }
        public string Civilite { set; get; }
        public string Nom { set; get; }
        public string Prenom { set; get; }
        public string DateNaissance { set; get; }
        public string Adresse { set; get; }
        public string CP { set; get; }
        public string Ville { set; get; }
        public string Pays { set; get; }
        public string Telephone { set; get; }
        public string Portable { set; get; }
        public string Email { set; get; }
    }
}