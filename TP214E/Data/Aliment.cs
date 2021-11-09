﻿using MongoDB.Bson;
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
            UniteDeMesure = pUniteMesure;
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
            set
            {
                if (value != "")
                {
                    nom = value;
                }
                else
                {
                    throw new ArgumentException("Le nom ne doit pas être vide.");
                }
            }
        }

        public double Quantite
        {
            get { return quantite; }
            set
            {
                if (value >= 0)
                {
                    quantite = value;
                }
                else
                {
                    throw new ArgumentException("La quantité ne doit pas être un nombre négatif.");
                }
            }
        }

        public UniteMesure UniteDeMesure
        {
            get { return uniteMesure; }
            set { uniteMesure = value; }
        }

        public decimal CoutVente
        {
            get { return coutVente; }
            set
            {
                if (value >= 0)
                {
                    coutVente = value;
                }
                else
                {
                    throw new ArgumentException("Le cout ne doit pas être un nombre négatif.");
                }
            }
        }

        public override string ToString()
        {
            return String.Format("{0} - {1:c} - {2}", Nom, CoutVente, UniteDeMesure);
        }
    }
}
