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
        void GameStarted();

        void TilePlaced(IPlayer player, ITile tile);
        void PersonPlaced(IPlayer player, ITile tile, IPerson person);

        /// <summary>
        /// IPlayer will have it's points. int points will be the number awarded and message will be something like "John scored 8 for completing his city!"
        /// </summary>
        /// <param name="player"></param>
        /// <param name="points"></param>
        /// <param name="message"></param>
        void PointsAwarded(IPlayer player, int points, string message);

        void GameOver();
    }
}
