using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;

namespace TP214E.Data
{
    public class Recette
    {
        private ObjectId id { get; set; }
        private string nomrecette { get; set; }
        private List<Ingredient> listeIngredients { get; set; }
        private List<string> instructions { get; set; }
        private double rendement { get; set; }
        private decimal coutant { get; set; }
        private decimal vendant { get; set; }
        private decimal margeProfit { get; set; }

        public Recette(string pNomRecette)
        {
            nomrecette = pNomRecette;
        }

        public decimal CalculerCoutant()
        {
            foreach (Ingredient ingredient in listeIngredients)
            {
                coutant += ingredient.NomAliment.CoutAliment;
            }

            return coutant;
        }

        public decimal CalculerVendant()
        {
            return vendant = coutant + (coutant * margeProfit);
        }
    }
}
