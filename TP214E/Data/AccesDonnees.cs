using System;
using System.Collections.Generic;
using System.Windows;
using MongoDB.Driver;

namespace TP214E.Data
{
    public class AccesDonnees
    {
        public MongoClient mongoDBClient;
        public IMongoDatabase baseDonnees;
        public IMongoCollection<Aliment> collectionAliment;
        public IMongoCollection<Commande> collectionCommande;
        public IMongoCollection<Recette> collectionRecettes;

        public AccesDonnees()
        {
            mongoDBClient = OuvrirConnexion();
            baseDonnees = ConnecterBaseDonnees();
        }

        private MongoClient OuvrirConnexion()
        {
            MongoClient dbClient = null;
            try
            {
                dbClient = new MongoClient("mongodb://localhost:27017/");
            }
            catch (Exception ex) //Inscrire la bonne exception?
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return dbClient;
        }

        private IMongoDatabase ConnecterBaseDonnees()
        {
            IMongoDatabase bdCourante = null;

            try
            {
                bdCourante = mongoDBClient.GetDatabase("TP2DB");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }

            return bdCourante;
        }

        public List<Aliment> ObtenirCollectionAliments()
        {
            List<Aliment> listeAliments = new List<Aliment>();
            try
            {
                collectionAliment = baseDonnees.GetCollection<Aliment>("Aliments");
                listeAliments = collectionAliment.Aggregate().ToList();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return listeAliments;
        }

        public List<Commande> ObtenirCollectionCommandes()
        {
            List<Commande> listeCommandes = new List<Commande>();
            try
            {
                collectionCommande = baseDonnees.GetCollection<Commande>("Commandes");
                listeCommandes = collectionCommande.Aggregate().ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return listeCommandes;
        }

        public List<Recette> ObtenirCollectionRecettes()
        {
            List<Recette> listeRecettes = new List<Recette>();
            try
            {
                collectionRecettes = baseDonnees.GetCollection<Recette>("Recettes");
                listeRecettes = collectionRecettes.Aggregate().ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return listeRecettes;
        }

        //Faire gestion erreurs?
        public void CreerCommande(Commande pCommande)
        {
            collectionCommande.InsertOne(pCommande);
        }

        public void CreerAliment(Aliment pAliment)
        {
            collectionAliment.InsertOne(pAliment);
        }

        public void SupprimerAliment(Aliment pAliment)
        {
            var alimentRecherche = Builders<Aliment>.Filter.Eq(aliment => aliment.Id, pAliment.Id);
            collectionAliment.DeleteOne(alimentRecherche);
        }

        public void MettreAJourAliment(Aliment pAliment)
        {
            var alimentRecherche = Builders<Aliment>.Filter.Eq(aliment => aliment.Id, pAliment.Id);
            var miseAJour = Builders<Aliment>.Update
                .Set("Nom", pAliment.Nom)
                .Set("Quantite", pAliment.Quantite)
                .Set("CoutVente", pAliment.CoutVente)
                .Set("UniteMesure", pAliment.UniteMesure);
            var documentAJour = collectionAliment.UpdateOne(alimentRecherche, miseAJour);
        }
    }
}
