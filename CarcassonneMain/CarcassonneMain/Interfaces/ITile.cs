using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarcassonneMain.Interfaces
{
    public interface ITile
    {
        Type LeftType { get; }
        Type RightType { get; }
        Type TopType { get; }
        Type BottomType { get; }

        int PositionX { get; }
        int PositionY { get; }

        bool IsStart { get; }
    }
}
