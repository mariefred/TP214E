using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace TP214E.Data
{
    public class ArticleCommande
    {
        [BsonId]
        private ObjectId id;

        
        private int quantiteArticle;

        
        private Recette article;

        
        private decimal coutArticle;

        
        public ArticleCommande(int pQuantiteArticle, Recette pArticle)
        {
            quantiteArticle = pQuantiteArticle;
            article = pArticle;
            CalculerCoutArticle();
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

        public void CalculerCoutArticle()
        {
            coutArticle = quantiteArticle * CoutArticle;
        }
    }
}
