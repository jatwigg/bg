using CarcassonneMain.Implementation.SimpleTileProperties;
using CarcassonneMain.Implementation.SimpleTileTypes;
using CarcassonneMain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarcassonneMain.Implementation
{
    public class SimpleGame : IGame
    {
        private List<IObserver> _observers = new List<IObserver>();

        public SimpleGame(IPlayer[] players)
        {
            Players = players;
        }

        public IPlayer[] Players { get; }

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
#warning todo:
            // should i bring them up to speed? perhaps like this:
            // observer.BeginCatchup();
            // foreach (previous game event)
            //   observer.some method
            // observer.EndCatchup();
        }

        public void Start()
        {
            _observers.ForEach(o => o.GameStarting(this));

            var tilesLeft = getAllTilesShuffled();
            var startTiles = tilesLeft.Where(t => t.TileProperties.Any(p => p.GetType().Equals(typeof(StartTileProperty)) ) ).ToArray();
            tilesLeft = tilesLeft.Except(startTiles).ToArray();
            bool @continue = true;

            // assume the start tiles know where they are placed (i,e traditional start is at 0,0, extra stuff may be 0,1 or a waterfall formation at a position)
            
            // put down start card
            _observers.ForEach(o => o.GameStarted(this, startTiles));

            do
            {
                foreach (IPlayer player in Players)
                {
                    // player gets a random card

                    // player places card (check if correct and don't allow if not -> out message from rule as to why)
                    // -> check if caused city/road/monestry to close and collect points

                    // player optionally places person (if they have any people left) (check if legal move before advancing)

                    // quit if end of cards
                    @continue = tilesLeft.Any();
                }
            }
            while (@continue);
        }

        private ITile[] getAllTilesShuffled()
        {
            throw new NotImplementedException();
        }
    }
}
