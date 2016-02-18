using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarcassonneMain.Interfaces
{
    public interface ITile
    {
        ITileSideType LeftType { get; }
        ITileSideType RightType { get; }
        ITileSideType TopType { get; }
        ITileSideType BottomType { get; }

        ITileProperty[] TileProperties { get; }

        int PositionX { get; }
        int PositionY { get; }

        // make this a ITileProperty instead : bool IsStart { get; } 
    }
}
