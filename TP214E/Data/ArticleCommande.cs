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

        [BsonElement ("quantiteArticle")]
        private int quantiteArticle;

        [BsonElement ("nomArticle")]
        private Recette article;

        [BsonElement ("coutArticle")]
        private decimal coutArticle;

        [BsonConstructor]
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
