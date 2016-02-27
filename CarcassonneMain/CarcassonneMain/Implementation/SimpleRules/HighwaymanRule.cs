using CarcassonneMain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarcassonneMain.Implementation.SimpleRules
{
    public class HighwaymanRule : IRule
    {
        public IPiece[] BuildPieces()
        {
            return new IPiece[] { };
        }

        public ITile[] BuildTiles()
        {
            return new ITile[] { };
        }
    }
}
