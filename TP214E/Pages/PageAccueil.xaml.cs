using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TP214E.Data;
using TP214E.Enumeration;

namespace TP214E
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class PageAccueil : Page
    {
        private DAL dal;
        public PageAccueil()
        {
            InitializeComponent();
            dal = new DAL();
        }

        private void BoutonInventaire_Click(object sender, RoutedEventArgs e)
        {
            PageInventaire frmInventaire = new PageInventaire(dal);

            this.NavigationService.Navigate(frmInventaire);

            
        }
        private void BoutonCommandes_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/PageCommandes.xaml", UriKind.Relative));
        }

        // Créer des recettes pour tester l'affichage
        public void CreerRecettes()
        {
            List<Aliment> aliments = new List<Aliment>();
            aliments.Add(new Aliment("Pains burger", 12, UniteMesure.gramme, (decimal)15.75));
            aliments.Add(new Aliment("Boeuf haché", 5000, UniteMesure.gramme, (decimal)56.60));
            aliments.Add(new Aliment("Laitue", 1000, UniteMesure.gramme, (decimal)10.42));
            aliments.Add(new Aliment("Tomates", 4540, UniteMesure.gramme, (decimal)27.05));
            aliments.Add(new Aliment("Bacon", 4000, UniteMesure.gramme, (decimal)35.62));
            aliments.Add(new Aliment("Mayonnaise", 16, UniteMesure.litre, (decimal)50.67));

            Recette burgerBLT = new Recette("Burger BLT");
            
            List<(double, Aliment)> burgerBLTIngredients = new List<(double, Aliment)>();
            burgerBLTIngredients.Add((70,aliments[1])); // pain burger
            burgerBLTIngredients.Add((150, aliments[2])); // boeuf haché
            burgerBLTIngredients.Add((50, aliments[5])); // bacon
            burgerBLTIngredients.Add((15, aliments[3])); // laitue
            burgerBLTIngredients.Add((25, aliments[4])); // tomate
            burgerBLTIngredients.Add((60, aliments[6])); // mayo
            





        }
    }
}
