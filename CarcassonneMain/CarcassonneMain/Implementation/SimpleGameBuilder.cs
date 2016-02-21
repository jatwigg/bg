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

            //todo: sort tiles and piece properties by priority and remove where applicable

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
