using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Tile.NET.Model;

namespace Tile.NET.Example.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TileClient? _tileClient;
        private IEnumerable<TileTracker>? _tiles;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((string)_loginBtn.Content == "Login")
            {
                _loginBtn.IsEnabled = false;
                _tileClient = new TileClient(_emailTextBox.Text, _passwordPwdBox.Password);
                try
                {
                    await _tileClient.Initialize();

                    _tiles = await _tileClient.GetTiles();
                    _tilesListBox.ItemsSource = _tiles;

                    _loginBtn.Content = "Logout";

                    _refreshTilesBtn.IsEnabled = true;

                    _emailTextBox.IsEnabled = false;
                    _passwordPwdBox.IsEnabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                _loginBtn.IsEnabled = true;
            }
            else if ((string)_loginBtn.Content == "Logout")
            {
                _tilesListBox.ItemsSource = null;
                _tiles = null;
                _tileClient = null;

                _passwordPwdBox.Password = string.Empty;

                _loginBtn.Content = "Login";

                _refreshTilesBtn.IsEnabled = false;

                _emailTextBox.IsEnabled = true;
                _passwordPwdBox.IsEnabled = true;
            }
        }

        private void OpenInGoogleMapsButton_Click(object sender, RoutedEventArgs e)
        {
            var tile = ((sender as Button)!.DataContext as TileTracker)!;

            var lat = tile.Latitude.ToString().Replace(',', '.');
            var lng = tile.Longitude.ToString().Replace(',', '.');

            var proc = new Process();
            proc.StartInfo.FileName = $"https://maps.google.com/?q={lat},{lng}";
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }

        private async void RefreshTilesBtn_Click(object sender, RoutedEventArgs e)
        {
            _refreshTilesBtn.IsEnabled = false;
            try
            {
                _tilesListBox.ItemsSource = null;
                _tiles = await _tileClient!.GetTiles();
                _tilesListBox.ItemsSource = _tiles;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            _refreshTilesBtn.IsEnabled = true;
        }
    }
}
