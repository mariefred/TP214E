using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace TP214E.Data
{
    public class ArticleCommande
    {
        private ObjectId id;

        private int quantiteArticle;

        private Recette article;

        private decimal coutArticle;
        
        public ArticleCommande(int pQuantiteArticle, Recette pArticle)
        {
            QuantiteArticle = pQuantiteArticle;
            Article = pArticle;
        }

        public ObjectId Id
        {
            get { return id; }
            set { id = value; }
        }

        public int QuantiteArticle
        {
            get { return quantiteArticle; }
            set { quantiteArticle = value; }
        }

        public Recette Article
        {
            get { return article; }
            set { article = value; }
        }

        public decimal CoutArticle
        {
            get { return coutArticle; }
            set { coutArticle = value; }
        }

        public decimal CalculerVendantArticle()
        {
            return coutArticle = QuantiteArticle * Article.Vendant;
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} = {2:c}", QuantiteArticle, Article, coutArticle);
        }
    }
}
