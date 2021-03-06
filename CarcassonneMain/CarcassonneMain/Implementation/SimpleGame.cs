﻿using CarcassonneMain.Implementation.SimpleTileProperties;
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

        public SimpleGame()
        {

        }
        
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
            // we need to consider that an observer may be removed by something async or by another observer's implementation
            NotifyObservers(o => o.GameStarting(this));
            
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
        
        private void NotifyObservers(Action<IObserver> action)
        {
            // we need to wrap the observer calls in case they modify the observer list whist we are iterating.
            // it's important that observers never miss anything.
            BeginTransaction();
            var observers = _observers.ToArray();
            foreach (var o in observers)
            {
                action.Invoke(o);
            }
            EndTransaction();
        }

        private void EndTransaction()
        {
            throw new NotImplementedException();
        }

        private void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        private ITile[] getAllTilesShuffled()
        {
            return Tiles.Shuffle().ToArray();
        }


        public List<IPiece> Pieces
        {
            get;
            internal set;
        }

        public IPlayer[] Players
        {
            get;
            internal set;
        }

        public List<IRule> Rules
        {
            get;
            internal set;
        }

        public List<ITile> Tiles
        {
            get;
            internal set;
        }
    }
}
