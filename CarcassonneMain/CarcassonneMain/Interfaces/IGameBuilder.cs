﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarcassonneMain.Interfaces
{
    public interface IGameBuilder
    {
        IGameBuilder WithRule<T>() where T : IRule, new();
        IGameBuilder WithRule(IRule rule);

        IGameBuilder WithPlayer<T>() where T : IPlayer, new();
        IGameBuilder WithPlayer(IPlayer player);

        IGame Build();
    }
}
