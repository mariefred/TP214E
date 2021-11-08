using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
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

        private decimal coutVente;

        public Aliment()
        {
        }

        public Aliment(string pNom, double pQuantite, UniteMesure pUniteMesure, decimal pcoutVente)
        {
            Nom = pNom;
            Quantite = pQuantite;
            UniteMesure = pUniteMesure;
            CoutVente = pcoutVente;
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

        public UniteMesure UniteMesure
        {
            get { return uniteMesure; }
            set { uniteMesure = value; }
        }

        public decimal CoutVente
        {
            get { return coutVente; }
            set { coutVente = value; }
        }

        public override string ToString()
        {
            return String.Format("{0} - {1:c} - {2}", Nom, CoutVente, uniteMesure);
        }
    }
}
