using CarcassonneMain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarcassonneMain.Implementation.RemoteGame
{
    public class RemoteGame : IGame
    {
        /*
        Need some 'remote game builder' locally and then probably use a simple game on the server wrapped in this.
            */
        public void AddObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}
