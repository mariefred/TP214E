using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
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
    /// Logique d'interaction pour Inventaire.xaml
    /// </summary>
    public partial class PageInventaire : Page
    {
        private bool estPourAjouter = false;
        private bool estPourModifier = false;
        private bool estPourSupprimer = false;

        public PageInventaire(AccesDonnees dal)
        {
            InitializeComponent();
            AjouterAlimentsAEcran();
        }

        private void AjouterAlimentsAEcran()
        {
            foreach (Aliment aliment in PageAccueil.listeAliments)
            {
                LstAliments.Items.Add(aliment);
            }
        }

        private void BtnRetourAccueil_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/PageAccueil.xaml", UriKind.Relative));
        }

        private void LstAliments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = LstAliments.SelectedIndex;
            if (index != -1)
            {
                Aliment aliment = (Aliment)LstAliments.Items[index];
                TxTNom.Text = aliment.Nom;
                TxtQuantite.Text = aliment.Quantite.ToString();
                TxtCoutVente.Text = aliment.CoutVente.ToString();
                switch (aliment.UniteMesure)
                {
                    case UniteMesure.gramme:
                        OptGramme.IsChecked = true;
                        break;
                    case UniteMesure.kilogramme:
                        OptKilogramme.IsChecked = true;
                        break;
                    case UniteMesure.millilitre:
                        OptMillilitre.IsChecked = true;
                        break;
                    case UniteMesure.litre:
                        OptLitre.IsChecked = true;
                        break;
                    case UniteMesure.unite:
                        OptUnite.IsChecked = true;
                        break;
                }
            }
        }

        private void ViderInformationsAlimentAEcran()
        {
            TxTNom.Text = "";
            TxtQuantite.Text = "";
            TxtCoutVente.Text = "";
            OptGramme.IsChecked = false;
            OptKilogramme.IsChecked = false;
            OptMillilitre.IsChecked = false;
            OptLitre.IsChecked = false;
            OptUnite.IsChecked = false;
            LblTitreActionChoisiPourAliment.Content = "";
            LblTitreActionChoisiPourAliment.Background = new SolidColorBrush(Colors.Black);
        }

        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            ViderInformationsAlimentAEcran();
            LblTitreActionChoisiPourAliment.Content = "AJOUTER UN ALIMENT";
            LblTitreActionChoisiPourAliment.Background = new SolidColorBrush(Colors.GreenYellow);
            estPourAjouter = true;
            estPourModifier = false;
            estPourSupprimer = false;
        }

        private void BtnModifier_Click(object sender, RoutedEventArgs e)
        {
            ViderInformationsAlimentAEcran();
            LblTitreActionChoisiPourAliment.Content = "MODIFIER UN ALIMENT";
            LblTitreActionChoisiPourAliment.Background = new SolidColorBrush(Colors.GreenYellow);
            estPourAjouter = false;
            estPourModifier = true;
            estPourSupprimer = false;
        }

        private void BtnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            ViderInformationsAlimentAEcran();
            LblTitreActionChoisiPourAliment.Content = "SUPPRIMER UN ALIMENT";
            LblTitreActionChoisiPourAliment.Background = new SolidColorBrush(Colors.GreenYellow);
            estPourAjouter = false;
            estPourModifier = false;
            estPourSupprimer = true;
        }
        private void BtnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            ViderInformationsAlimentAEcran();
            LblTitreActionChoisiPourAliment.Content = "";
            LblTitreActionChoisiPourAliment.Background = new SolidColorBrush(Colors.Black);
            LstAliments.SelectedIndex = -1;
            estPourAjouter = false;
            estPourModifier = false;
            estPourSupprimer = false;
        }

        private void BtnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            if (TxTNom.Text != "" && TxtCoutVente.Text != "" && TxtQuantite.Text != "" 
                && OptGramme.IsChecked.Value || OptKilogramme.IsChecked.Value ||
                OptMillilitre.IsChecked.Value || OptLitre.IsChecked.Value || OptUnite.IsChecked.Value)
            {
                if (estPourAjouter)
                {
                    AjouterAliment();
                }

                if (estPourModifier)
                {
                    // TODO : valider si on peut modifier un aliment.
                    AjouterAliment();
                    SupprimerAliment();
                }

                if (estPourSupprimer)
                {
                    SupprimerAliment();
                }
                ViderInformationsAlimentAEcran();
                estPourAjouter = false;
                estPourModifier = false;
                estPourSupprimer = false;
            }
        }

        private void AjouterAliment()
        {
            string nom = TxTNom.Text.Trim();
            double quantite = double.Parse(TxtQuantite.Text.Trim());
            decimal coutVente = decimal.Parse(TxtCoutVente.Text.Trim());
            UniteMesure unite;
            if (OptGramme.IsChecked.Value)
            {
                unite = UniteMesure.gramme;
            }
            else if (OptKilogramme.IsChecked.Value)
            {
                unite = UniteMesure.kilogramme;
            }
            else if (OptMillilitre.IsChecked.Value)
            {
                unite = UniteMesure.millilitre;
            }
            else if (OptLitre.IsChecked.Value)
            {
                unite = UniteMesure.litre;
            }
            else
            {
                unite = UniteMesure.unite;
            }

            Aliment aliment = new Aliment(nom, quantite, unite, coutVente);
            LstAliments.Items.Add(aliment);
        }

        private void SupprimerAliment()
        {
            int index = LstAliments.SelectedIndex;
            if (index != -1)
            {
                LstAliments.Items.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("Veuillez choisir un aliment");
            }
        }

    }
}
