using CarcassonneMain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarcassonneMain.Implementation.SaveLoading
{
    public class StringSerialiser : ISaveSource<string>, ILoadSource<string>
    {
        public IGame Load(string game)
        {
            throw new NotImplementedException();
        }

        public string Save(IGame game)
        {
            throw new NotImplementedException();
        }
    }
}
