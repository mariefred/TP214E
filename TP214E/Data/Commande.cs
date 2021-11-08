﻿using MongoDB.Bson;
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

        [BsonElement("noCommande")]
        private int noCommande;

        [BsonElement("listeArticleCommande")]
        private List<ArticleCommande> listeArticleCommande;

        [BsonElement("coutTotalCommande")]
        private decimal coutTotalCommande;

        public Commande(int pNoCommande)
        {
            NoCommande = pNoCommande;
            ListeArticleCommande = new List<ArticleCommande>();
        }

        [BsonConstructor]
        public Commande()
        {
        }

        public ObjectId Id
        {
            get { return id; }
            set { id = value; }
        }

        public int NoCommande
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
            set
            {
                if (value >= 0)
                {
                    coutTotalCommande = value;
                }
                else
                {
                    throw new ArgumentException("Le coût de la commande ne doit pas être un nobre négatif.");
                }
            }
        }

        public decimal CalculerVendantCommande()
        {
            foreach (ArticleCommande article in ListeArticleCommande)
            {
                CoutTotalCommande += article.CalculerVendantArticle();
            }
            return CoutTotalCommande;
        }

        public override string ToString()
        {
            return String.Format("{0} = {1:c}", NoCommande, CoutTotalCommande);
        }

    }
}
