using CarcassonneMain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarcassonneMain.Implementation.SimpleTileProperties
{
    class MonasteryTileProperty : ITileProperty
    {
        public int PriorityOfProperty { get; } = 0;

        public bool ShouldOverrideLowerPriorityProperty { get; } = false;
    }
}
