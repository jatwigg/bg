using System;
using System.Windows.Controls;
using CarcassonneMain.Interfaces;
using System.Windows.Media;

namespace CarcassonneWPFGame
{
    internal class CanvasObserver : IObserver
    {
        private Canvas _canvas;

        public CanvasObserver(Canvas canvas)
        {
            _canvas = canvas;
        }
        public void GameStarting(IGame game)
        {
            _canvas.Background = Brushes.Green;
        }
        public void GameStarted()
        {
            throw new NotImplementedException();
        }

        public void GameOver()
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

        public void TilePlaced(IPlayer player, ITile tile)
        {
            throw new NotImplementedException();
        }
    }
}