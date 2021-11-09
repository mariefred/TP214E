﻿using MongoDB.Bson;
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

        public ArticleCommande()
        { }

        public ArticleCommande(int pQuantiteArticle, Recette pArticle)
        {
        }

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
            set
            {
                if (value >= 0)
                {
                    quantiteArticle = value;
                }
                else
                {
                    throw new ArgumentException("La quantité de l'article ne doit pas être un nombre négatif.");
                }
            }
        }

        public Recette Article
        {
            get { return article; }
            set
            {
                if (value != null)
                {
                    article = value;
                }
                else
                {
                    throw new ArgumentNullException("La recette est nulle.", (Exception)null);
                }
            }
        }

        public decimal CoutArticle
        {
            get { return coutArticle; }
            set
            {
                if (value >= 0)
                {
                    coutArticle = value;
                }
                else
                {
                    throw new ArgumentException("Le coût de l'article ne doit pas être un nombre négatif.");
                }
            }
        }

        public decimal CalculerVendantArticle()
        {
            return CoutArticle = QuantiteArticle * Article.Vendant;
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} = {2:c}", QuantiteArticle, Article, CoutArticle);
        }
    }
}
