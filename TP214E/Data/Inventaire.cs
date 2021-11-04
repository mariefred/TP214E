using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace TP214E.Data
{
    public class Inventaire
    {
        private List<Aliment> listeAliments;

        public List<Aliment> ListeAliments
        {
            get { return listeAliments; }
            set { listeAliments = value; }
        }

        [BsonConstructor]
        public Inventaire()
        {
            listeAliments = new List<Aliment>();
        }
    }
}
