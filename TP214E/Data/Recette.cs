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

        //[BsonElement ("instructions")]
        //private List<string> instructions;

        //[BsonElement ("rendement")]
        //private double rendement;

        //[BsonElement ("coutant")]
        //private decimal coutant;

        [BsonElement ("vendant")]
        private decimal vendant;

        [BsonConstructor]
        public Recette(string pNomrecette)
        {
            this.nomRecette = pNomrecette;
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

        //public List<string> Instructions
        //{
        //    get { return instructions; }
        //    set { instructions = value; }
        //}

        //public double Rendement
        //{
        //    get { return rendement; }
        //    set { rendement = value; }
        //}

        //public decimal Coutant
        //{
        //    get { return coutant; }
        //    set { coutant = value; }
        //}

        public decimal Vendant
        {
            get { return vendant; }
            set { vendant = value; }
        }

        //public void CalculerCoutant()
        //{
        //    foreach ((double quantite, Aliment aliment) in listeIngredients)
        //    {
        //        coutant += aliment.CoutAchat;
        //    }
        //}
    }
}
