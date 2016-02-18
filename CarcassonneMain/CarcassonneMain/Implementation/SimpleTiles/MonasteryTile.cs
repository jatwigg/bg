using CarcassonneMain.Implementation.SimpleTileProperties;
using CarcassonneMain.Implementation.SimpleTileTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarcassonneMain.Interfaces;

namespace CarcassonneMain.Implementation.SimpleTiles
{
    class MonasteryTile : SimpleTile
    {
        public MonasteryTile()
        {
            LeftType = new FieldTileType();
            TopType = new FieldTileType();
            RightType = new FieldTileType();
            BottomType = new FieldTileType();
            TileProperties = new[] { new MonasteryTileProperty() };
        }
    }
}
