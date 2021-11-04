using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using TP214E.Enumeration;

namespace TP214E.Data
{
    public class Ingredient
    {
        private Aliment aliment;
        private double quantite;
        private UniteMesure uniteDeMesure;

        public Ingredient(Aliment pAliment, double pQuantite, UniteMesure pUniteDeMesure)
        {
            this.aliment = pAliment;
            this.quantite = pQuantite;
            this.uniteDeMesure = pUniteDeMesure;
        }

        public Aliment Aliment
        {
            get { return aliment; }
            set { aliment = value; }
        }

        public double Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }

        public UniteMesure UniteDeMesure
        {
            get { return uniteDeMesure; }
            set { uniteDeMesure = value; }
        }
    }
}
