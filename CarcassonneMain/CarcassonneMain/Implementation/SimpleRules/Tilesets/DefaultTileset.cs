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
    public class DefaultTileset : IRule
    {
        public IPiece[] BuildPieces()
        {
            throw new NotImplementedException();
        }

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

            // 1 city left,top,right joined with road at bottom
            tiles.Add(new SimpleTile
            {
                TopType = new CityTileType(),
                LeftType = new CityTileType(),
                RightType = new CityTileType(),
                BottomType = new RoadTileType(),
                TileProperties = new ITileProperty[] { new CityJoinedProperty() }
            });

            // 2 city left,top,right joined with road at bottom with shield
            tiles.AddRange(new SimpleTile
            {
                TopType = new CityTileType(),
                LeftType = new CityTileType(),
                RightType = new CityTileType(),
                BottomType = new RoadTileType(),
                TileProperties = new ITileProperty[] { new CityJoinedProperty(), new CityHasShieldProperty() }
            }.Duplicate(2)
            );

            // 8 road left right, grass top bottom
            tiles.AddRange(new SimpleTile
            {
                TopType = new FieldTileType(),
                LeftType = new RoadTileType(),
                RightType = new RoadTileType(),
                BottomType = new FieldTileType(),
                TileProperties = new ITileProperty[] { }
            }.Duplicate(8)
            );

            // 4 road left right, grass bottom, city top
            tiles.AddRange(new SimpleTile
            {
                TopType = new CityTileType(),
                LeftType = new RoadTileType(),
                RightType = new RoadTileType(),
                BottomType = new FieldTileType(),
                TileProperties = new ITileProperty[] { }
            }.Duplicate(4)
            );

            // 3 road left bottom, city top right joined
            tiles.AddRange(new SimpleTile
            {
                TopType = new CityTileType(),
                LeftType = new RoadTileType(),
                RightType = new CityTileType(),
                BottomType = new RoadTileType(),
                TileProperties = new ITileProperty[] { new CityJoinedProperty() }
            }.Duplicate(3)
            );

            // 2 road left bottom, city top right joined with shield
            tiles.AddRange(new SimpleTile
            {
                TopType = new CityTileType(),
                LeftType = new RoadTileType(),
                RightType = new CityTileType(),
                BottomType = new RoadTileType(),
                TileProperties = new ITileProperty[] { new CityJoinedProperty(), new CityHasShieldProperty() }
            }.Duplicate(2)
            );

            // 9 road left bottom, grass top right
            tiles.AddRange(new SimpleTile
            {
                TopType = new FieldTileType(),
                LeftType = new RoadTileType(),
                RightType = new FieldTileType(),
                BottomType = new RoadTileType(),
                TileProperties = new ITileProperty[] { }
            }.Duplicate(9)
            );

            // 3 road left bottom, grass right, city top
            tiles.AddRange(new SimpleTile
            {
                TopType = new CityTileType(),
                LeftType = new RoadTileType(),
                RightType = new FieldTileType(),
                BottomType = new RoadTileType(),
                TileProperties = new ITileProperty[] { }
            }.Duplicate(3)
            );

            // 3 road right bottom, grass left, city top
            tiles.AddRange(new SimpleTile
            {
                TopType = new CityTileType(),
                LeftType = new FieldTileType(),
                RightType = new RoadTileType(),
                BottomType = new RoadTileType(),
                TileProperties = new ITileProperty[] { }
            }.Duplicate(3)
            );

            // 4 road left right bottom, grass top. ends road due to village
            tiles.AddRange(new SimpleTile
            {
                TopType = new FieldTileType(),
                LeftType = new RoadTileType(),
                RightType = new RoadTileType(),
                BottomType = new RoadTileType(),
                TileProperties = new ITileProperty[] { new RoadsEndProperty() }
            }.Duplicate(4)
            );

            // 3 road left right bottom ends road due to village, city top
            tiles.AddRange(new SimpleTile
            {
                TopType = new CityTileType(),
                LeftType = new RoadTileType(),
                RightType = new RoadTileType(),
                BottomType = new RoadTileType(),
                TileProperties = new ITileProperty[] { new RoadsEndProperty() }
            }.Duplicate(3)
            );
            
            // 1 road left right top bottom, road ends due to village
            tiles.Add(new SimpleTile
            {
                TopType = new RoadTileType(),
                LeftType = new RoadTileType(),
                RightType = new RoadTileType(),
                BottomType = new RoadTileType(),
                TileProperties = new ITileProperty[] { new RoadsEndProperty() }
            });

            return tiles.ToArray();
        }
    }
}
