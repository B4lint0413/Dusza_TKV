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
using DuszaTKVGameLib;

namespace DuszaWpfApp
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class AdminGameWindow : Window
    {
        private const int CARD_HEIGHT = 125;
        private const int CARD_WIDTH = 320;
        
        public AdminGameWindow()
        {
            InitializeComponent();
            foreach (var game in App.Games.GetOwnGames("Pintyő István"))
            {
                GameCardContainer.Children.Add(CreateCard(game));
            }
        }
        private Canvas CreateCard(Game game)
        {
            return new Canvas()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = CARD_WIDTH,
                Height = CARD_HEIGHT + game.Events.DistinctBy(x => x.Name).Count() * 25,
                Margin = new Thickness(10, 10, 10, 10),
                Children = { new Border()
                    {
                        BorderBrush = Brushes.Blue,
                        BorderThickness = new Thickness(2, 2, 2, 2),
                        CornerRadius = new CornerRadius(15, 15, 15, 20),
                        Margin = new Thickness(5, 5, 5, 5),
                        Width = CARD_WIDTH - 10,
                        Height = CARD_HEIGHT - 10 + game.Events.DistinctBy(x => x.Name).Count() * 25,
                        Child = new Grid()
                        {
                            Width = CARD_WIDTH - 10,
                            Height = CARD_HEIGHT - 10 + game.Events.DistinctBy(x => x.Name).Count() * 25,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            Children = { CreateHeader(game.Name), CreateBody(game.Events), CreateButton(game.Name) }
                        } 
                    }
                }
            };
        }
        private TextBlock CreateHeader(string header)
        {
            return new TextBlock()
            {
                Margin = new Thickness(5, 5, 5, 5),
                FontSize = 25,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center,
                Text = header
            };
        }
        private StackPanel CreateBody(IEnumerable<Event> events)
        {
            var container = new StackPanel()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            foreach (var e in events.DistinctBy(x => x.Name))
            {
                container.Children.Add(new TextBlock()
                {
                    Margin = new Thickness(5, 5, 5, 5),
                    FontSize = 14,
                    Text = e.Name   
                });
            }
            return container;
        }

        private Button CreateButton(string name)
        {
            var btn = new Button()
            {
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(20, 10, 20, 10),
                Height = 25,
                Content = "End Game",
            };
            btn.Click += new RoutedEventHandler((object o, RoutedEventArgs args) => EndGame(name));
            return btn;
        }

        private void EndGame(string name)
        {
            GameCardContainer.Children.Add(new TextBlock() { Text = name });
        }

        private void CreateNewGame(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
