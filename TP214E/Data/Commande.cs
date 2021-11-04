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
            this.noCommande = pNoCommande;
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


        public void AjouterArticleACommande(ArticleCommande pArticle)
        {
            listeArticleCommande.Add(pArticle);
        }

        public void RetirerArticleACommande(ArticleCommande pArticle)
        {
            listeArticleCommande.Remove(pArticle);
        }

        public decimal CalculerCoutCommande(List<ArticleCommande> pListe)
        {
            foreach (ArticleCommande article in listeArticleCommande)
            {
                coutTotalCommande += article.CoutArticle;
            }
            return coutTotalCommande;  
        }

    }
}
