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

namespace TP214E.Pages
{
    /// <summary>
    /// Logique d'interaction pour PageCommandes.xaml
    /// </summary>
    public partial class PageCommandes : Page
    {
        public PageCommandes()
        {
            InitializeComponent();
            AjouterPlatsAEcran();
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
            foreach (Recette plat in PageAccueil.listeRecettes)
            {
                LstPlats.Items.Add(plat);
            }
        }


    }
}
