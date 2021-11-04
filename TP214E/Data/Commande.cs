using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Commande
    {
        private ObjectId id;
        private string noCommande;
        private List<ArticleCommande> listeArticleCommande;
        private decimal coutTotalCommande;

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
