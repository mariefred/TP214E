﻿using System;
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
        }

        private void BtnRetourAccueil_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/PageCommandes.xaml", UriKind.Relative));

        }
    }
}
