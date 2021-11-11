using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP214E.Data;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using Moq;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class CommandeTests
    {
        [TestMethod()]
        public void Test_constructeur_avec_parametre()
        {
            int noCommande = 1000;

            Commande commande = new Commande(noCommande);

            Assert.AreEqual(noCommande, commande.NoCommande);
            Assert.IsNotNull(commande.ListeArticleCommande);
        }

        [TestMethod()]
        public void Test_constructeur_sans_parametre()
        {

            Commande commande = new Commande();

            Assert.IsNotNull(commande.ListeArticleCommande);
        }

        [TestMethod()]
        public void Test_execption_sur_constructeur_si_no_commande_plus_petit_que_1000()
        {
            int noCommande = 999;

            Commande commande;

            Assert.ThrowsException<ArgumentException>(() => commande = new Commande(noCommande));

        }

        [TestMethod()]
        public void Test_execption_si_cout_total_commande_est_negatif()
        {
            var commande = new Commande();

            Assert.ThrowsException<ArgumentException>(() => commande.CoutTotalCommande = -1000);
        }

        [TestMethod()]
        public void Test_execption_si_date_commande_est_pas_aujourdhui()
        {
            var commande = new Commande();
            DateTime hier = DateTime.Today.AddDays(-1);
            DateTime demain = DateTime.Today.AddDays(1);

            Assert.ThrowsException<ArgumentException>(() => commande.DateCommande = hier);
            Assert.ThrowsException<ArgumentException>(() => commande.DateCommande = demain);
        }

        [TestMethod()]
        public void Test_methode_to_string()
        {
            DateTime aujourdhui = DateTime.Today;

            Commande commande1000 = new Commande(1000);
            commande1000.DateCommande = aujourdhui;

            var mockBurgerBLT = new Mock<IRecette>("Burger BLT");
            mockBurgerBLT.Object.Vendant = 100;

            var mockPoutine = new Mock<IRecette>("Poutine");
            mockPoutine.Object.Vendant = 50;

            List<ArticleCommande> mockArticleCommande1000 = new List<ArticleCommande>();

            var mockBurgerBLTArticle = new Mock<IArticleCommande>(2, (Recette)mockBurgerBLT.Object);
            mockBurgerBLTArticle.Object.CalculerVendantArticle();

            var mockPoutineArticle = new Mock<IArticleCommande>(1, (Recette)mockPoutine.Object);
            mockPoutineArticle.Object.CalculerVendantArticle();

            mockArticleCommande1000.Add((ArticleCommande)mockPoutineArticle.Object);
            mockArticleCommande1000.Add((ArticleCommande)mockBurgerBLTArticle.Object);

            commande1000.ListeArticleCommande = mockArticleCommande1000;

            commande1000.CalculerVendantCommande();

            Assert.AreEqual(aujourdhui + " - 1000 = 250,00 $", commande1000.ToString());
        }
    }
}

