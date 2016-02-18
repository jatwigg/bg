using CarcassonneMain.Implementation.SimpleTileProperties;
using CarcassonneMain.Implementation.SimpleTileTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarcassonneMain.Implementation.SimpleTiles
{
    class StartTile : SimpleTile
    {
        public StartTile()
        {
            LeftType = new RoadTileType();
            TopType = new CityTileType();
            RightType = new RoadTileType();
            BottomType = new FieldTileType();
            TileProperties = new[] { new StartTileProperty() };
        }
    }
}
