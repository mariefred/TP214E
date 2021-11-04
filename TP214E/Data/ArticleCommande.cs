using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class ArticleCommande
    {
        private ObjectId id;
        private int quantiteArticle;
        private string nomArticle;
        private string noCommande;
        private decimal coutArticle;

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
