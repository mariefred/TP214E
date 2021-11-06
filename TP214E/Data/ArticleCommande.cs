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
            //coutArticle = quantiteArticle * CoutArticle;
            // TODO : C'est peut-être pas une méthode utile ici. On calcul un cout mais seulement 1 fois lorsque le constrcuteur est créer.
            coutArticle = QuantiteArticle * Article.Vendant;
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
