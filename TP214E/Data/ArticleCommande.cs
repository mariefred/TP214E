using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class ArticleCommande
    {
        private ObjectId id { get; set; }
        private int quantiteArticle { get; set; }
        private string nomArticle { get; set; }
        private string noCommande { get; set; }
        private decimal coutArticle { get; set; }

        public ArticleCommande(int pQuantiteArticle, string pNomArticle)
        {
            quantiteArticle = pQuantiteArticle;
            nomArticle = pNomArticle;
        }

        public decimal CoutArticle
        {
            get { return coutArticle; }
            set { coutArticle = value; }
        }

    }
}
