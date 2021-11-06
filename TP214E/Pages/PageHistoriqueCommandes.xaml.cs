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
    /// Logique d'interaction pour PageHistoriqueCommandes.xaml
    /// </summary>
    public partial class PageHistoriqueCommandes : Page
    {
        public PageHistoriqueCommandes()
        {
            InitializeComponent();
            AjouterCommandesAEcran();
        }

        private void BtnRetourAccueil_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/PageCommandes.xaml", UriKind.Relative));

        }

        private void AjouterCommandesAEcran()
        {
            foreach (Commande commande in PageAccueil._commandes)
            {
                LstHistoriqueCommandes.Items.Add(commande);
            }
        }

        private void LstHistoriqueCommandes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = LstHistoriqueCommandes.SelectedIndex;
            if (index != -1)
            {
                LblNoCommande.Content = PageAccueil._commandes[index].NoCommande;
                foreach (ArticleCommande article in PageAccueil._commandes[index].ListeArticleCommande)
                {
                    LblArticles.Content += article.Article.Nomrecette + "\n";
                }
                LblTotal.Content = PageAccueil._commandes[index].CoutTotalCommande;
            }
        }
    }
}
