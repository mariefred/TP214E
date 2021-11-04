using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using TP214E.Enumeration;


namespace TP214E.Data
{
    public class Aliment
    {
        private ObjectId id;
        private string nom;
        private double quantite;
        private UniteMesure uniteMesure;

        private decimal coutAchat;
        private decimal coutVente;

        public Aliment(string pNom, int pQuantite, UniteMesure pUniteMesure, decimal pCoutAliment)
        {
            nom = pNom;
            quantite = pQuantite;
            uniteMesure = pUniteMesure;
            coutAchat = pCoutAliment;
        }

        public ObjectId Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public double Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }

        public UniteMesure UniteDeMesure
        {
            get { return uniteMesure; }
            set { uniteMesure = value; }
        }

        public decimal CoutAchat
        {
            get { return coutAchat; }
            set { coutAchat = value; }
        }

        public decimal CoutVente
        {
            get { return coutVente; }
            set { coutVente = value; }
        }
    }
}
