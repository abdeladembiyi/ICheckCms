using System;
using System.Collections.Generic;

namespace iCheckAPI.Models
{
    public partial class TypePermis
    {
        public TypePermis()
        {
            Conducteur = new HashSet<Conducteur>();
        }

        public int Idpermis { get; set; }
        public string Libelle { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Conducteur> Conducteur { get; set; }
    }
}
