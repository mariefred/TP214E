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
        private string nomArticle;

        [BsonElement ("noCommande")]
        private string noCommande;

        [BsonElement ("coutArticle")]
        private decimal coutArticle;

        [BsonConstructor]
        public ArticleCommande(int pQuantiteArticle, string pNomArticle)
        {
            quantiteArticle = pQuantiteArticle;
            nomArticle = pNomArticle;
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

        public string NomArticle
        {
            get { return nomArticle; }
            set { nomArticle = value; }
        }

        public string NoCommande
        {
            get { return noCommande; }
            set { noCommande = value; }
        }

        public decimal CoutArticle
        {
            get { return coutArticle; }
            set { coutArticle = value; }
        }
    }
}
