using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarcassonneMain.Interfaces
{
    public interface IObserver
    {
        void GameStarting(IGame game);
        void GameStarted(IGame game, ITile[] startTiles);

        void TilePlaced(IGame game, IPlayer player, ITile tile);
        void PersonPlaced(IGame game, IPlayer player, ITile tile, IPerson person);

        /// <summary>
        /// IPlayer will have it's points. int points will be the number awarded and message will be something like "John scored 8 for completing his city!"
        /// </summary>
        /// <param name="game"></param>
        /// <param name="player"></param>
        /// <param name="points"></param>
        /// <param name="message"></param>
        void PointsAwarded(IGame game, IPlayer player, int points, string message);

        void GameOver(IGame game);
    }
}
