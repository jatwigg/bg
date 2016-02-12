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
        public IGame Build()
        {
            throw new NotImplementedException();
        }

        public IGameBuilder WithPlayer(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public IGameBuilder WithPlayer<T>() where T : IPlayer
        {
            throw new NotImplementedException();
        }

        public IGameBuilder WithRule(IRule rule)
        {
            throw new NotImplementedException();
        }

        public IGameBuilder WithRule<T>() where T : IRule
        {
            throw new NotImplementedException();
        }
    }
}
