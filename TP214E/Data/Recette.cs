using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace TP214E.Data
{
    public class Recette : IRecette
    {
        private ObjectId id;

        private string nomRecette;

        private decimal vendant;

        public Recette()
        {
        }

        public Recette(string pNomrecette, decimal pVendant)
        {
            NomRecette = pNomrecette;
            Vendant = pVendant;
        }

        public ObjectId Id
        {
            get { return id; }
            set { id = value; }
        }

        public string NomRecette
        {
            get { return nomRecette; }
            set
            {
                if (value != "")
                {
                    nomRecette = value;
                }
                else
                {
                    throw new ArgumentException("Le nom de la recette est vide.");
                }
            }
        }

        public decimal Vendant
        {
            get { return vendant; }
            set
            {
                if (value >= 0)
                {
                    vendant = value;
                }
                else
                {
                    throw new ArgumentException("Le vendant de la recette ne doit pas être un nobre négatif.");
                }
            }
        }

        public override string ToString()
        {
            return String.Format("{1}", Vendant, NomRecette);
        }
    }
}
