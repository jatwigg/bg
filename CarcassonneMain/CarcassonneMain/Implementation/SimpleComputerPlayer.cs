using CarcassonneMain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarcassonneMain.Implementation
{
    public class SimpleComputerPlayer : IPlayer
    {
        public string Name { get; set; }

        public int Score { get; }
    }
}
