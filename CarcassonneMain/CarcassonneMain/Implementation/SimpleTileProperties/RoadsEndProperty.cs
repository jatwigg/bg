using CarcassonneMain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarcassonneMain.Implementation.SimpleTileProperties
{
    class RoadsEndProperty : ITileProperty
    {
        public int PriorityOfProperty { get; }

        public bool ShouldOverrideLowerPriorityProperty { get; }
    }
}
