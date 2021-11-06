using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TP214E.Data
{
    public class Recette
    {
        [BsonId]
        private ObjectId id;

        [BsonElement ("nomRecette")]
        private string nomRecette;

        [BsonElement ("listeIngredients")]
        private List<(double, Aliment)> listeIngredients;

        [BsonElement ("vendant")]
        private decimal vendant;

        public Recette()
        {
        }
        
        public Recette(string pNomrecette)
        {
            this.nomRecette = pNomrecette;
            this.ListeIngredients = new List<(double, Aliment)>();
        }

        public string Nomrecette
        {
            get { return nomRecette; }
            set { nomRecette = value; }
        }

        public List<(double, Aliment)> ListeIngredients
        {
            get { return listeIngredients; }
            set { listeIngredients = value; }
        }

        public decimal Vendant
        {
            get { return vendant; }
            set { vendant = value; }
        }

        public override string ToString()
        {
            return String.Format("{0:c} - {1}", Vendant, Nomrecette);
        }
    }
}
