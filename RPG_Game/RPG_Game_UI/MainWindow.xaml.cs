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
        private readonly GameSession _gameSession;

        public MainWindow()
        {
            InitializeComponent();
            _gameSession = new GameSession();
            GameMessage.OnMessageRaised += OnGameMessageRaised;
            DataContext = _gameSession;
        }

        private void OnClick_Move(object sender, RoutedEventArgs e)
        {
            _gameSession.OnClick_Move();
        }

        private void OnClick_Shop(object sender, RoutedEventArgs e)
        {
            _gameSession.OnClick_Shop();
        }

        // TODO: change to general 'use' button, that either attacks with weapon or uses consumable
        private void OnClick_Attack(object sender, RoutedEventArgs e)
        {
            _gameSession.OnClick_Attack();
        }

        private void OnGameMessageRaised(object sender, GameMessageEventArgs e)
        {
            GameMessages.Document.Blocks.Add(new Paragraph(new Run(e.Message)));
            GameMessages.ScrollToEnd();
        }
    }
}
