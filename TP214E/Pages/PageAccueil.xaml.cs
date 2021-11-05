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
using TP214E.Pages;

namespace TP214E
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class PageAccueil : Page
    {
        public static List<Recette> _recettes;
        public static List<Aliment> _inventaire;
        private DAL dal;

        public PageAccueil()
        {
            InitializeComponent();
            dal = new DAL();
            _recettes = new List<Recette>();
            _inventaire = new List<Aliment>();
            CreerRecetteBurgerBLT();
            CreerRecetteFishNChips();
        }

        private void BoutonInventaire_Click(object sender, RoutedEventArgs e)
        {
            PageInventaire frmInventaire = new PageInventaire(dal);

            this.NavigationService.Navigate(frmInventaire);
        }

        private void BoutonCommandes_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/PageCommandes.xaml", UriKind.Relative), _recettes);
        }


        public void AjouterIngredientDansRecette(string pNomIngredient, double pQuantite, List<(double, Aliment)> pQuantiteAliment, List<Aliment> inventaire)
        {
            pQuantiteAliment.Add((pQuantite, inventaire.Find(ingredient => ingredient.Nom == pNomIngredient)));
        }

        // Créer des recettes pour tester l'affichage
        public void CreerRecetteBurgerBLT()
        {
            _inventaire.Add(new Aliment("Pains burger", 12, UniteMesure.unite, (decimal)15.75));
            _inventaire.Add(new Aliment("Boeuf haché", 5000, UniteMesure.gramme, (decimal)56.60));
            _inventaire.Add(new Aliment("Laitue", 1000, UniteMesure.gramme, (decimal)10.42));
            _inventaire.Add(new Aliment("Tomates", 4540, UniteMesure.gramme, (decimal)27.05));
            _inventaire.Add(new Aliment("Bacon", 4000, UniteMesure.gramme, (decimal)35.62));
            _inventaire.Add(new Aliment("Mayonnaise", 16, UniteMesure.litre, (decimal)50.67));

            Recette burgerBLT = new Recette("Burger BLT");
            burgerBLT.Vendant = (decimal)17.99;
            
            AjouterIngredientDansRecette("Pains burger", 1, burgerBLT.ListeIngredients, _inventaire);
            AjouterIngredientDansRecette("Boeuf haché", 150, burgerBLT.ListeIngredients, _inventaire);
            AjouterIngredientDansRecette("Bacon", 50, burgerBLT.ListeIngredients, _inventaire);
            AjouterIngredientDansRecette("Laitue", 15, burgerBLT.ListeIngredients, _inventaire);
            AjouterIngredientDansRecette("Tomates", 25, burgerBLT.ListeIngredients, _inventaire);
            AjouterIngredientDansRecette("Mayonnaise", 25, burgerBLT.ListeIngredients, _inventaire);

            _recettes.Add(burgerBLT);
        }

        public void CreerRecetteFishNChips()
        {
            _inventaire.Add(new Aliment("Morue panée", 24, UniteMesure.unite, (decimal)115.75));
            _inventaire.Add(new Aliment("Frites", 6000, UniteMesure.gramme, (decimal)37.60));
            _inventaire.Add(new Aliment("Sauce tartare", 5000, UniteMesure.millilitre, (decimal)60.42));
            _inventaire.Add(new Aliment("Salade verte", 4540, UniteMesure.gramme, (decimal)37.15));
            _inventaire.Add(new Aliment("Vinaigrette", 5000, UniteMesure.gramme, (decimal)45.62));

            Recette fishNChips = new Recette("Fish and chips");
            fishNChips.Vendant = (decimal) 21.99;

            AjouterIngredientDansRecette("Morue panée", 1, fishNChips.ListeIngredients, _inventaire);
            AjouterIngredientDansRecette("Frites", 140, fishNChips.ListeIngredients, _inventaire);
            AjouterIngredientDansRecette("Sauce tartare", 60, fishNChips.ListeIngredients, _inventaire);
            AjouterIngredientDansRecette("Salade verte", 150, fishNChips.ListeIngredients, _inventaire);
            AjouterIngredientDansRecette("Vinaigrette", 60, fishNChips.ListeIngredients, _inventaire);

            _recettes.Add(fishNChips);
        }

    }
}
