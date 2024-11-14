using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gesdette15.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Surnom { get; set; }
        public string Telephone { get; set; }
        public string Adresse { get; set; }
        public List<Dette> Dettes { get; set; } = new List<Dette>();

        public void AddDette(Dette dette)
        {
            Dettes.Add(dette);
            dette.Client = this;
        }

        public override string ToString()
        {
            return $"Client[id={Id}, surnom={Surnom}, telephone={Telephone}, adresse={Adresse}]";
        }

        public bool Equals(Client other)
        {
            if (this == other) return true;
            if (other == null) return false;
            return Id == other.Id &&
                   Surnom == other.Surnom &&
                   Telephone == other.Telephone &&
                   Adresse == other.Adresse;
        }
    }

   
}
