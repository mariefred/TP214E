using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
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
using System.Windows.Threading;
using TP214E.Data;

namespace TP214E.Pages
{
    /// <summary>
    /// Logique d'interaction pour PageCommandes.xaml
    /// </summary>
    public partial class PageCommandes : Page
    {
        private Commande commande;
        private DispatcherTimer dispatcherTimer;

        public PageCommandes()
        {
            InitializeComponent();
            AjouterPlatsAEcran();
            InitialiserMinuteurConfirmationCommande();
        }

        private void BtnHistorique_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/PageHistoriqueCommandes.xaml", UriKind.Relative));

        }
        private void BtnRetourAccueil_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/PageAccueil.xaml", UriKind.Relative));
        }

        private void AjouterPlatsAEcran()
        {
            foreach (Recette plat in PageAccueil._recettes)
            {
                LstPlats.Items.Add(plat);
            }
        }

        private void BtnEffacer_Click(object sender, RoutedEventArgs e)
        {
            LstCommande.Items.Clear();
            CalculerTotalCommandeEnCours();
        }

        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            int index = LstPlats.SelectedIndex;
            if (index != -1)
            {
                // TODO : Ajouter validation pour ne pas mettre 2x le même plat
                Recette recetteSelectionnee = (Recette)LstPlats.Items[index];
                ArticleCommande article = new ArticleCommande(1, recetteSelectionnee);
                LstCommande.Items.Add(article);
                CalculerTotalCommandeEnCours();
            }
        }

        private void BtnAugmenter_Click(object sender, RoutedEventArgs e)
        {
            int index = LstCommande.SelectedIndex;
            if (index != -1)
            {
                ((ArticleCommande)LstCommande.Items[index]).QuantiteArticle++;
                LstCommande.Items.Refresh();
                CalculerTotalCommandeEnCours();
            }
        }

        private void BtnDiminuer_Click(object sender, RoutedEventArgs e)
        {
            int index = LstCommande.SelectedIndex;
            if (index != -1)
            {
                if (((ArticleCommande)LstCommande.Items[index]).QuantiteArticle == 1)
                {
                    LstCommande.Items.RemoveAt(index);
                }
                else
                {
                    ((ArticleCommande)LstCommande.Items[index]).QuantiteArticle--;
                }

                LstCommande.Items.Refresh();
                CalculerTotalCommandeEnCours();
            }
        }

        private void BtnCommander_Click(object sender, RoutedEventArgs e)
        {
            // TODO : Trouver une manière de créer un no.Commande automatique unique-facile
            string noCommande = PageAccueil._commandes.Count.ToString();
            commande = new Commande("NO" + noCommande);
            foreach (ArticleCommande article in LstCommande.Items)
            {
                commande.ListeArticleCommande.Add(article);
            }

            commande.CalculerVendantCommande();
            PageAccueil._commandes.Add(commande);
            ReinitialiserApresCommande();
        }

        private void CalculerTotalCommandeEnCours()
        {
            decimal total = 0;
            foreach (ArticleCommande article in LstCommande.Items)
            {
                total += article.CalculerVendantArticle();
            }

            LblTotalCommande.Content = String.Format("{0:c}", total);
        }

        private void InitialiserMinuteurConfirmationCommande()
        {
            LblConfirmCommande.Visibility = System.Windows.Visibility.Collapsed;
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("Commande créée");
            LblConfirmCommande.Visibility = System.Windows.Visibility.Collapsed;
            dispatcherTimer.IsEnabled = false;
        }

        private void ReinitialiserApresCommande()
        {
            LblConfirmCommande.Visibility = System.Windows.Visibility.Visible;
            dispatcherTimer.Start();
            LstCommande.Items.Clear();
            CalculerTotalCommandeEnCours();
        }

    }
}
