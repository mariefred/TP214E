using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Commande
    {
        private ObjectId id { get; set; }
        private string noCommande { get; set; }
        private List<ArticleCommande> listeArticleCommande { get; set; }
        private decimal coutTotalCommande { get; set; }

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
