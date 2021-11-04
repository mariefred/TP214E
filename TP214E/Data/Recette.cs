using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;

namespace TP214E.Data
{
    public class Recette
    {
        private ObjectId id;
        private string nomrecette;
        private List<Ingredient> listeIngredients;
        private List<string> instructions;
        private double rendement;
        private decimal coutant;
        private decimal vendant;
        private decimal margeProfit;


        public ObjectId Id
        {
            get { return id; }
            set { id = value; }
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
