using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Aliment
    {
        private ObjectId id { get; set; }
        private string nom { get; set; }
        private int quantite { get; set; }
        private string uniteMesure { get; set; }
        private DateTime dateExpiration { get; set; }

        private decimal coutAliment;

        public Aliment(string pNom, int pQuantite, string pUniteMesure, DateTime pDateExpiration, decimal pCoutAliment)
        {
            nom = pNom;
            quantite = pQuantite;
            uniteMesure = pUniteMesure;
            dateExpiration = pDateExpiration;
            coutAliment = pCoutAliment;
        }

        public decimal CoutAliment
        {
            get { return coutAliment; }
            set { coutAliment = value; }
        }


        public void AugmenterQuantite(int pQuantite)
        {
            quantite += pQuantite;
        }

        public void DiminuerQuantite(int pQuantite)
        {
            quantite -= pQuantite;
        }


    }
}
