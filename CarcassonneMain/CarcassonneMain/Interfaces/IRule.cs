using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarcassonneMain.Implementation;

namespace CarcassonneMain.Interfaces
{
    public interface IRule
    {
        ITile[] BuildTiles();
        IPiece[] BuildPieces();
    }
}
