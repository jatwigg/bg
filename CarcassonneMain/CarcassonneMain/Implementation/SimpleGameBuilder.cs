using CarcassonneMain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarcassonneMain.Implementation
{
    public class SimpleGameBuilder : IGameBuilder
    {
        private List<IRule> _rules = new List<IRule>();
        private List<IPlayer> _players = new List<IPlayer>();

        public IGame Build()
        {
            var tiles = new List<ITile>();
            var pieces = new List<IPiece>();
            foreach (IRule rule in _rules)
            {
                tiles.AddRange( rule.BuildTiles() );
                pieces.AddRange( rule.BuildPieces() );
            }
            
            // get all tile properties that exist
            var allPropertyTypes = tiles.SelectMany(t => t.TileProperties.Select(tp => tp.GetType())).Distinct();
            // foreach property, get all tiles that have that property and order by priority
            // loop through each ordered list of tiles until one overrides the rest, then deactivate the rest
            foreach (var type in allPropertyTypes)
            {
                var tilesThatHaveTypeOrdered = tiles.Where(t => t.TileProperties.Any(tp => tp.GetType() == type)).OrderByDescending(t => t.TileProperties.First(tp => tp.GetType() == type).PriorityOfProperty).ToArray();
                bool @override = false;
                foreach (var tile in tilesThatHaveTypeOrdered)
                {
                    var prop = tile.TileProperties.First(tp => tp.GetType() == type);
                    if (@override)
                    {
                        tile.DeactivateProperty(prop);
                    }
                    else if (prop.ShouldOverrideLowerPriorityProperty)
                    {
                        @override = true;
                    }
                }                
            }

            return new SimpleGame
            {
                Players = _players.ToArray(),
                Rules = _rules,
                Tiles = tiles,
                Pieces = pieces
            };
        }

        public IGameBuilder WithPlayer(IPlayer player)
        {
            var builder = new SimpleGameBuilder();
            builder._rules.AddRange(this._rules);
            builder._players.AddRange(this._players);
            builder._players.Add(player);
            return builder;
        }

        public IGameBuilder WithPlayer<T>() where T : IPlayer, new()
        {
            return WithPlayer(new T());
        }

        public IGameBuilder WithRule(IRule rule)
        {
            var builder = new SimpleGameBuilder();
            builder._rules.AddRange(this._rules);
            builder._players.AddRange(this._players);
            builder._rules.Add(rule);
            return builder;
        }

        public IGameBuilder WithRule<T>() where T : IRule, new()
        {
            return WithRule(new T());
        }
    }
}
