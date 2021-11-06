﻿using System;
using System.Collections.Generic;
using System.Windows;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
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
            List<Commande> listeCommandes;
            try
            {
                collectionCommande = baseDonnees.GetCollection<Commande>("Commandes");
                listeCommandes = collectionCommande.Aggregate().ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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

    }
}