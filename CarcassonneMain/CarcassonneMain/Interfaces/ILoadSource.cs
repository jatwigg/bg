using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarcassonneMain.Interfaces
{
    public interface ILoadSource<T>
    {
        IGame Load(T game);
    }
}
