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
        private Aliment nomAliment;
        private double quantite { get; set; }

        private UniteMesure uniteDeMesure;

        public Ingredient(Aliment pNomAliment)
        {
            nomAliment = pNomAliment;
        }

        public Aliment NomAliment
        {
            get { return nomAliment; }
            set { nomAliment = value; }
        }

    }
}
