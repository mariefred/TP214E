using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace TP214E.Data
{
    public class Commande
    {
        private ObjectId id;

        private int noCommande;

        private List<ArticleCommande> listeArticleCommande;

        private decimal coutTotalCommande;

        public Commande()
        {
            listeArticleCommande = new List<ArticleCommande>();
        }


        public Commande(int pNoCommande)
        {
            NoCommande = pNoCommande;
            ListeArticleCommande = new List<ArticleCommande>();

        }

        public ObjectId Id
        {
            get { return id; }
            set { id = value; }
        }

        public int NoCommande
        {
            get { return noCommande; }
            set { noCommande = value; }
        }

        public List<ArticleCommande> ListeArticleCommande
        {
            get { return listeArticleCommande; }
            set { listeArticleCommande = value; }
        }

        public decimal CoutTotalCommande
        {
            get { return coutTotalCommande; }
            set { coutTotalCommande = value; }
        }


        public decimal CalculerVendantCommande()
        {
            foreach (ArticleCommande article in listeArticleCommande)
            {
                coutTotalCommande += article.CalculerVendantArticle();
            }

            return coutTotalCommande;
        }

        public override string ToString()
        {
            return String.Format("{0} = {1:c}", NoCommande, CoutTotalCommande);
        }

    }
}
