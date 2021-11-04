using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TP214E.Enumeration;

namespace TP214E.Data
{
    public class Ingredient
    {
        [BsonId]
        private ObjectId id;

        [BsonElement ("aliment")]
        private Aliment aliment;

        [BsonElement ("quantite")]
        private double quantite;

        [BsonElement ("uniteDeMesure")]
        private UniteMesure uniteDeMesure;

        [BsonConstructor]
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
