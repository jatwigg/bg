using CarcassonneMain.Implementation.SaveLoading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarcassonneMain.Interfaces;
using CarcassonneMain.Implementation;
using CarcassonneMain.Implementation.SimpleRules;
using WPF_Tools;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows;

namespace CarcassonneWPFGame
{
    class MainWindowViewModel : ViewModel, IObserver
    {
        private IGame _game;

        public MainWindowViewModel()
        {
            SaveCommand = new AutoCanExecuteRelayCommand(save);
            LoadCommand = new AutoCanExecuteRelayCommand(load);
            StartCommand = new AutoCanExecuteRelayCommand(start);
            PauseCommand = new AutoCanExecuteRelayCommand(pause);
            Player = new LocalPlayer { Name = "Local Guy" };
        }
        
        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }
        public ICommand StartCommand { get; }
        public ICommand PauseCommand { get; }

        public string SaveString
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public LocalPlayer Player
        {
            get { return Get<LocalPlayer>(); }
            set { Set(value); }
        }

        public Canvas Canvas { get; set; }

        private void draw()
        {
            Rectangle rect1 = new System.Windows.Shapes.Rectangle();
            rect1.Stroke = System.Windows.Media.Brushes.Black;
            rect1.Fill = System.Windows.Media.Brushes.Red;
            rect1.VerticalAlignment = VerticalAlignment.Center;
            rect1.Height = 50;
            rect1.Width = 70;
            Canvas.Children.Add(rect1);
        }

        private void save()
        {
            // save a game like this
            StringSerialiser saveSerializer = new StringSerialiser();
            SaveString = saveSerializer.Save(_game);
        }

        private void load()
        {
            // load a game like this
            StringSerialiser saveSerializer = new StringSerialiser();
            _game = saveSerializer.Load(SaveString);
        }

        private void start()
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
                .WithPlayer(Player)
                // build the game
                .Build();

            // attach an observer of the game (UI representation)
            _game.AddObserver(this);

            // play a game like this
            _game.Start();
        }

        private void pause()
        {

        }

        public void GameStarting(IGame game)
        {
            throw new NotImplementedException();
        }

        public void GameStarted()
        {
            throw new NotImplementedException();
        }

        public void TilePlaced(IPlayer player, ITile tile)
        {
            if (tile.Bottom != null)
            {

            }
            else if (tile.Top != null)
            {

            }
            else if (tile.Left != null)
            {

            }
            else if (tile.Right != null)
            {

            }
        }

        public void PersonPlaced(IPlayer player, ITile tile, IPerson person)
        {
            throw new NotImplementedException();
        }

        public void PointsAwarded(IPlayer player, int points, string message)
        {
            throw new NotImplementedException();
        }

        public void GameOver()
        {
            throw new NotImplementedException();
        }
    }
}
