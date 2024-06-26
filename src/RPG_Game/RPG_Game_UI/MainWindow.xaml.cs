﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Engine.Controllers;
using Engine.EventArgs;

namespace RPG_Game_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly GameSession _gameSession = new();

        public MainWindow()
        {
            InitializeComponent();
            GameMessage.OnMessageRaised += OnGameMessageRaised;
            DataContext = _gameSession;
        }

        private void OnClick_Move(object sender, RoutedEventArgs e)
        {
            _gameSession.OnClick_Move();
        }

        private void OnClick_DisplayShopWindow(object sender, RoutedEventArgs e)
        {
            ShopWindow shopWindow = new()
            {
                Owner = this,
                DataContext = _gameSession
            };
            shopWindow.ShowDialog();
        }

        // TODO: change to general 'use' button, that either attacks with weapon or uses consumable
        private void OnClick_Use(object sender, RoutedEventArgs e)
        {
            _gameSession.OnClick_Use();
        }

        private void OnGameMessageRaised(object sender, GameMessageEventArgs e)
        {
            GameMessages.Document.Blocks.Add(new Paragraph(new Run(e.Message)));
            GameMessages.ScrollToEnd();
        }
    }
}
