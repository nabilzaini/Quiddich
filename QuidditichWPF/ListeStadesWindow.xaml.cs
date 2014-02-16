﻿using BusinessLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuidditichWPF
{
    /// <summary>
    /// Logique d'interaction pour ListestadeesWindow.xaml
    /// </summary>
    public partial class ListestadesWindow : Window
    {
        private CoupeManager cm = new CoupeManager();
        public ListestadesWindow()
        {
            InitializeComponent();
            Pilotage.LoadPreferences(this);
            CoupeManager cm = new CoupeManager();
            ListeStades.ItemsSource = cm.allStades();
            Stade stade = new Stade();
            this.DataContext = stade;
        }

        protected override void OnClosed(EventArgs e)
        {
            Pilotage.SavePreferences(this);
            base.OnClosed(e);
        }

        private void ListeStades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.DataContext = ListeStades.SelectedItem;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListeStades.Items.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int nbrePlaces;
            double percent;
            Int32.TryParse(places.Text, out nbrePlaces);
            Double.TryParse(pourcentage.Text, out percent);
            cm.addStade(nom.Text, adresse.Text, nbrePlaces, percent);
            ListeStades.ItemsSource = cm.allStades();
            ListeStades.Items.Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            cm.deleteStade((Stade)ListeStades.SelectedItem);
            ListeStades.ItemsSource = cm.allStades();
            ListeStades.Items.Refresh();
        }
    }
}