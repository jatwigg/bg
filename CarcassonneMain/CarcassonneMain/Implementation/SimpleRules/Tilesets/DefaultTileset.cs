using CarcassonneMain.Implementation.SimpleTileProperties;
using CarcassonneMain.Implementation.SimpleTiles;
using CarcassonneMain.Implementation.SimpleTileTypes;
using CarcassonneMain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarcassonneMain.Implementation.SimpleRules.Tilesets
{
    class DefaultTileset : IRule
    {
        public ITile[] BuildTiles()
        {
            var tiles = new List<ITile>();

            // 1 start tile
            tiles.Add(new StartTile());

            // 4 monastery tiles
            tiles.AddRange(new MonasteryTile().Duplicate(4));

            // 2 monastery with road at bottom
            tiles.AddRange(new MonasteryTile
            {
                BottomType = new RoadTileType()
            }.Duplicate(2)
            );

            // 5 city at top, field elsewhere
            tiles.AddRange(new SimpleTile
            {
                TopType = new CityTileType(),
                LeftType = new FieldTileType(),
                RightType = new FieldTileType(),
                BottomType = new FieldTileType(),
                TileProperties = new ITileProperty[] { }
            }.Duplicate(5)
            );

            // fields and city mix:

            // --city left, right - city joined
            tiles.Add(new SimpleTile
            {
                TopType = new FieldTileType(),
                LeftType = new CityTileType(),
                RightType = new CityTileType(),
                BottomType = new FieldTileType(),
                TileProperties = new[] { new CityJoinedProperty() }
            });

            // -- 2 city (with shield) left, right  - city joined
            tiles.AddRange(new SimpleTile
            {
                TopType = new FieldTileType(),
                LeftType = new CityTileType(),
                RightType = new CityTileType(),
                BottomType = new FieldTileType(),
                TileProperties = new ITileProperty[] { new CityJoinedProperty(), new CityHasShieldProperty() }
            }.Duplicate(2)
            );

            // -- 3 city top, right - city joined
            tiles.AddRange(new SimpleTile
            {
                TopType = new CityTileType(),
                LeftType = new FieldTileType(),
                RightType = new CityTileType(),
                BottomType = new FieldTileType(),
                TileProperties = new ITileProperty[] { new CityJoinedProperty() }
            }.Duplicate(3)
            );

            // -- 2 city (with shield) top, right - city joined
            tiles.AddRange(new SimpleTile
            {
                TopType = new CityTileType(),
                LeftType = new FieldTileType(),
                RightType = new CityTileType(),
                BottomType = new FieldTileType(),
                TileProperties = new ITileProperty[] { new CityJoinedProperty(), new CityHasShieldProperty() }
            }.Duplicate(2)
            );

            // -- 3 city top, bottom
            tiles.AddRange(new SimpleTile
            {
                TopType = new CityTileType(),
                LeftType = new FieldTileType(),
                RightType = new FieldTileType(),
                BottomType = new CityTileType(),
                TileProperties = new ITileProperty[] { }
            }.Duplicate(3)
            );

            // -- 2 city top, right
            tiles.AddRange(new SimpleTile
            {
                TopType = new CityTileType(),
                LeftType = new FieldTileType(),
                RightType = new CityTileType(),
                BottomType = new FieldTileType(),
                TileProperties = new ITileProperty[] { }
            }.Duplicate(2)
            );

            // -- 3 city left,top,right joined
            tiles.AddRange(new SimpleTile
            {
                TopType = new CityTileType(),
                LeftType = new CityTileType(),
                RightType = new CityTileType(),
                BottomType = new FieldTileType(),
                TileProperties = new ITileProperty[] { new CityJoinedProperty() }
            }.Duplicate(3)
            );

            // -- 1 city left,top,right joined with shield
            tiles.Add(new SimpleTile
            {
                TopType = new CityTileType(),
                LeftType = new CityTileType(),
                RightType = new CityTileType(),
                BottomType = new FieldTileType(),
                TileProperties = new ITileProperty[] { new CityJoinedProperty(), new CityHasShieldProperty() }
            });

            // -- 1 city left,top,right,bottom joined with shield
            tiles.Add(new SimpleTile
            {
                TopType = new CityTileType(),
                LeftType = new CityTileType(),
                RightType = new CityTileType(),
                BottomType = new CityTileType(),
                TileProperties = new ITileProperty[] { new CityJoinedProperty(), new CityHasShieldProperty() }
            });
        }

        private ITile[] build<TLeft, TTop, TRight, TBottom>()
        {
            throw new NotImplementedException();
        }
    }
}
