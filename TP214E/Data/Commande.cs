using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace TP214E.Data
{
    public class Commande
    {
        [BsonId]
        private ObjectId id;

        [BsonElement ("noCommande")]
        private string noCommande;

        [BsonElement ("listeArticleCommande")]
        private List<ArticleCommande> listeArticleCommande;

        [BsonElement ("coutTotalCommande")]
        private decimal coutTotalCommande;

        [BsonConstructor]
        public Commande(string pNoCommande)
        {
            NoCommande = pNoCommande;
            ListeArticleCommande = new List<ArticleCommande>();
            
        }

        public ObjectId Id
        {
            get { return id; }
            set { id = value; }
        }

        public string NoCommande
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
