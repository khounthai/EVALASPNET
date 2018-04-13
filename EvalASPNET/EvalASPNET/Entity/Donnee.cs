using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvalASPNET.Entity
{
    public class Donnee
    {
        public int iddonnee { get; set; }
        public int iduser { get; set; }
        public int idcontact { get; set; }
        public string libelleChamp { get; set; }
        public string valeur { get; set; }
        public int ordre { get; set; }
        public bool accueil { get; set; }
    }
}