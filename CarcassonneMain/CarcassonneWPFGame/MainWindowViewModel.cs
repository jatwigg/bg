using CarcassonneMain.Implementation.SaveLoading;
using CarcassonneWPFGame.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarcassonneMain.Interfaces;
using CarcassonneMain.Implementation;
using CarcassonneMain.Implementation.SimpleRules;

namespace CarcassonneWPFGame
{
    class MainWindowViewModel : ViewModel, IObserver
    {
        private IGame _game;

        public MainWindowViewModel()
        {
            SaveCommand = new RelayCommand(save);
            LoadCommand = new RelayCommand(load);
            StartCommand = new RelayCommand(start);
            PauseCommand = new RelayCommand(pause);
            Player = new LocalPlayer { Name = "Local Guy" };
        }

        public TestAppObserverAndPlayerViewModel TestAppObserverAndPlayerViewModel { get; }
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
            throw new NotImplementedException();
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
