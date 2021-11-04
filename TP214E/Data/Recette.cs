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
        private string nomrecette;

        [BsonElement ("listeIngredients")]
        private List<Ingredient> listeIngredients;

        [BsonElement ("instructions")]
        private List<string> instructions;

        [BsonElement ("rendement")]
        private double rendement;

        [BsonElement ("coutant")]
        private decimal coutant;

        [BsonElement ("vendant")]
        private decimal vendant;

        [BsonElement ("margeProfit")]
        private decimal margeProfit;

        [BsonConstructor]
        public Recette(string pNomrecette)
        {
            this.nomrecette = pNomrecette;
        }

        public string Nomrecette
        {
            get { return nomrecette; }
            set { nomrecette = value; }
        }

        public List<Ingredient> ListeIngredients
        {
            get { return listeIngredients; }
            set { listeIngredients = value; }
        }

        public List<string> Instructions
        {
            get { return instructions; }
            set { instructions = value; }
        }

        public double Rendement
        {
            get { return rendement; }
            set { rendement = value; }
        }

        public decimal Coutant
        {
            get { return coutant; }
            set { coutant = value; }
        }

        public decimal Vendant
        {
            get { return vendant; }
            set { vendant = value; }
        }

        public decimal MargeProfit
        {
            get { return margeProfit; }
            set { margeProfit = value; }
        }

        //public decimal CalculerCoutant()
        //{
        //    foreach (Ingredient ingredient in listeIngredients)
        //    {
        //        coutant += ingredient.Aliment.CoutAliment;
        //    }

        //    return coutant;
        //}

        public decimal CalculerVendant()
        {
            return vendant = coutant + (coutant * margeProfit);
        }
    }
}
