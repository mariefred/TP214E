using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP214E.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class RecetteTests
    {
        [TestMethod()]
        public void Test_constructeur_avec_parametre()
        {
            string nomRecette = "Bruger BLT";
            Recette recette = new Recette(nomRecette, 100);

            Assert.AreEqual(nomRecette, recette.NomRecette);
            Assert.IsNotNull(recette.ListeIngredients);
        }


        [TestMethod()]
        public void Test_exception_si_nom_vide()
        {
            Recette recette = new Recette();

            Assert.ThrowsException<ArgumentException>(() => recette.NomRecette = "");
        }

        [TestMethod()]
        public void Test_exception_si_nom_seulement_espaces()
        {
            Recette recette = new Recette();

            Assert.ThrowsException<ArgumentException>(() => recette.NomRecette = "  ");
        }

        [TestMethod()]
        public void Test_exception_si_vendant_est_negatif()
        {
            decimal vendant = -100;

            Recette recette = new Recette();

            Assert.ThrowsException<ArgumentException>(() => recette.Vendant = vendant);
        }

        [TestMethod()]
        public void Test_exception_si_quantite_ingredient_est_negatif()
        {
            Recette burgerBLT = new Recette();

            var bacon = new Mock<IAliment>();
            var laitue = new Mock<IAliment>();
            var tomate = new Mock<IAliment>();

            List<(double, Aliment)> alimentsBurgerBLT = new List<(double, Aliment)>();

            alimentsBurgerBLT.Add((3, (Aliment)bacon.Object));
            alimentsBurgerBLT.Add((4, (Aliment)laitue.Object));
            alimentsBurgerBLT.Add((-5, (Aliment)tomate.Object));


            Assert.ThrowsException<ArgumentException>(() => burgerBLT.ListeIngredients = alimentsBurgerBLT);
        }


        [TestMethod()]
        public void Test_methode_to_string()
        {
            Recette burgerBLT = new Recette("Burger BLT", 100);

            Assert.AreEqual("100,00 $ - Burger BLT", burgerBLT.ToString());
        }


    }
}