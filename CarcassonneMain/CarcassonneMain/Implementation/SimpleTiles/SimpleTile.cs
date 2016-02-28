using CarcassonneMain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarcassonneMain.Implementation
{
    class SimpleTile : ITile
    {
        public ITileProperty[] TileProperties { get; internal set; }
        
        public ITileSideType TopType { get; internal set; }

        public ITileSideType BottomType { get; internal set; }

        public ITileSideType LeftType { get; internal set; }

        public ITileSideType RightType { get; internal set; }

        public int PositionX { get; internal set; }

        public int PositionY { get; internal set; }

        /// <summary>
        /// Create clones of this instance.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        internal IEnumerable<ITile> Duplicate(int numberOfTilesInTotal)
        {
            List<ITile> tiles = new List<ITile>();
            tiles.Add(this);
            for (int i = 1; i < numberOfTilesInTotal;++i)
            {
                // new up a copy of this type
                var copy = (SimpleTile)Activator.CreateInstance(this.GetType());
                copy.TopType = this.TopType;
                copy.BottomType = this.BottomType;
                copy.LeftType = this.LeftType;
                copy.RightType = this.RightType;
                copy.PositionX = this.PositionX;
                copy.PositionY = this.PositionY;
                copy.TileProperties = this.TileProperties;

                tiles.Add(copy);
            }
            return tiles;
        }

        public void DeactivateProperty(ITileProperty prop)
        {
            TileProperties = TileProperties.Except(new[] { prop }).ToArray();
        }
    }
}
