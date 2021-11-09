using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization;

namespace TP214E.Data
{
    public class Recette
    {
        private ObjectId id;

        private string nomRecette;

        private List<(double, Aliment)> listeIngredients;

        private decimal vendant;

        public Recette()
        {
        }

        public Recette(string pNomrecette)
        {
            NomRecette = pNomrecette;
            ListeIngredients = new List<(double, Aliment)>();
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

        public ObjectId Id
        {
            get { return id; }
            set { id = value; }
        }

        public List<(double, Aliment)> ListeIngredients
        {
            get { return listeIngredients; }
            set { listeIngredients = value; }
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
            return String.Format("{0:c} - {1}", Vendant, NomRecette);
        }
    }
}
