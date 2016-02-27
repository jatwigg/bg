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
            var game = new SimpleGame
            {
                Players = _players.ToArray()
            };

            var tiles = new List<ITile>();
            var pieces = new List<IPiece>();
            foreach (IRule rule in _rules)
            {
                tiles.AddRange( rule.BuildTiles() );
                pieces.AddRange( rule.BuildPieces() );
            }

#warning todo
            //todo: sort tiles and piece properties by priority and remove where applicable
            var groupedByProp = new Dictionary<Type, List<ITile>>();
            foreach(var tile in tiles)
            {
                var properties = tile.TileProperties;
                foreach (var prop in properties)
                {
                    if (groupedByProp.ContainsKey(prop.GetType()))
                    {
                        groupedByProp[prop.GetType()].Add(tile);
                    }
                    else
                    {
                        groupedByProp.Add(prop.GetType(), new List<ITile>(new[] { tile }));
                    }
                }
            }

            var final = groupedByProp.Select(kvp => 
            {
                var type = kvp.Key;
                var orderedTiles = kvp.Value.OrderBy(t => t.TileProperties.First(tp => tp.GetType() == type).PriorityOfProperty);
                var removeAllThatShouldBeReplaced = orderedTiles.TakeWhile(t => !t.TileProperties.First(tp => tp.GetType() == type).ShouldOverrideLowerPriorityProperty);
                bool remove = false;
                foreach(var tile in orderedTiles)
                {
                    var prop = tile.TileProperties.First(tp => tp.GetType() == type);
                    if (!remove)
                    {
                        remove = prop.ShouldOverrideLowerPriorityProperty;
                    }
                    else
                    {
                        // ideally we should remove the property
                        // todo:
                        //tile.DeactivateProperty(prop);
                    }
                }
                return kvp;
            });

            throw new NotImplementedException();
            return game;
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
