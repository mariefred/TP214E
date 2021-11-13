using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP214E.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using MongoDB.Driver;
using Autofac.Extras.Moq;
using MongoDB.Bson;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class AccesDonneesTests
    {
        [TestMethod]
        public void Tester_Connexion_Client_Valide()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Mock<MongoClient> mockClient = new Mock<MongoClient>();

                mock.Mock<IAccesDonnees>()
                    .Setup(x => x.OuvrirConnexion())
                    .Returns(mockClient.Object);

                var connection = mock.Create<IAccesDonnees>();
                var test = connection.OuvrirConnexion();
                var attendu = mockClient;

                Assert.IsTrue(test != null);
                Assert.AreEqual(attendu.Object, test);
            }
        }

        [TestMethod]
        public void Tester_Connexion_Base_Donnees_Valide()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Mock<IMongoDatabase> mockBD = new Mock<IMongoDatabase>();

                mock.Mock<IAccesDonnees>()
                    .Setup(x => x.ConnecterBaseDonnees())
                    .Returns(mockBD.Object);

                var connection = mock.Create<IAccesDonnees>();
                var test = connection.ConnecterBaseDonnees();
                var attendu = mockBD;

                Assert.IsTrue(test != null);
                Assert.AreEqual(attendu.Object, test);
            }
        }

        [TestMethod]
        public void Tester_Obtenir_Collection_Aliments()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IAccesDonnees>()
                    .Setup(x => x.ObtenirCollectionAliments())
                    .Returns(ObtenirMockCollectionAliments());

                var aliment = mock.Create<IAccesDonnees>();
                var donneesAttendues = ObtenirMockCollectionAliments();

                var actuel = aliment.ObtenirCollectionAliments();

                Assert.IsTrue(actuel != null);
                Assert.AreEqual(donneesAttendues.Count, actuel.Count);

                for (int i = 0; i < donneesAttendues.Count; i++)
                {
                    Assert.AreEqual(donneesAttendues[i].Nom, actuel[i].Nom);
                    Assert.AreEqual(donneesAttendues[i].Nom, actuel[i].Nom);
                }
            }
        }

        private List<Aliment> ObtenirMockCollectionAliments()
        {
            List<Aliment> mockCollectionAliments = new List<Aliment>
            {
                new Aliment
                {
                    Nom = "Concombre",
                    Quantite = 12,
                    UniteMesure = Enumeration.UniteMesure.unite,
                    CoutVente = (decimal)0.89
                },
                new Aliment
                {
                    Nom = "Mayonnaise",
                    Quantite = 16,
                    UniteMesure = Enumeration.UniteMesure.litre,
                    CoutVente = (decimal)35.67
                },
                new Aliment
                {
                    Nom = "Boeuf haché",
                    Quantite = 10,
                    UniteMesure = Enumeration.UniteMesure.kilogramme,
                    CoutVente = (decimal)26.42
                }
            };
            return mockCollectionAliments;
        }

    }
}
