using CarcassonneMain.Implementation;
using CarcassonneMain.Implementation.SaveLoading;
using CarcassonneMain.Implementation.SimpleRules;
using CarcassonneMain.Interfaces;
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

namespace CarcassonneWPFGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IPlayer _localPlayer;
        private IGame _game;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // build a game like this
            _game = new SimpleGameBuilder()
                // rules define cards and stuff that can use properties of cards
                .WithRule<City>()
                .WithRule<Farmers>()
                .WithRule<Priests>()
                .WithRule<Highwayman>()
                // with players
                .WithPlayer<SimpleComputerPlayer>()
                .WithPlayer(_localPlayer = new LocalPlayer { Name = "Local Guy" })
                // build the game
                .Build();


            // attach an observer of the game (UI representation)
            _game.AddObserver(new CanvasObserver(canvas));

            // play a game like this
            _game.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // save a game like this
            StringSerialiser saveSerializer = new StringSerialiser();
            string save = saveSerializer.Save(_game);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // load a game like this
            StringSerialiser saveSerializer = new StringSerialiser();
            _game = saveSerializer.Load("todo");
        }
    }
}
