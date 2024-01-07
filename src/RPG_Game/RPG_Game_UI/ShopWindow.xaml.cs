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
using Engine.Models.Items.Misc;

namespace RPG_Game_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ShopWindow : Window
    {
        public GameSession Session => DataContext as GameSession;
        public ShopWindow()
        {
            InitializeComponent();
        }
        private void OnClick_Sell(object sender, RoutedEventArgs e)
        {
            GameItemGroup? item = ((FrameworkElement)sender).DataContext as GameItemGroup;

            if (item is null)
            {
                return;
            }

            Session.OnClick_Sell(new(item.Item, 1));
        }
        private void OnClick_Buy(object sender, RoutedEventArgs e)
        {
            GameItemGroup? item = ((FrameworkElement)sender).DataContext as GameItemGroup;

            if (item is null)
            {
                return;
            }

            Session.OnClick_Buy(new(item.Item, 1));
        }
        private void OnClick_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
