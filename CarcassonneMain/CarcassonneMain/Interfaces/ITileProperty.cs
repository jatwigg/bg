using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarcassonneMain.Interfaces
{
    public interface ITileProperty
    {
        // so a start tile can be overridded by river tiles (as an example)
        int PriorityOfProperty { get; } // higher the number, the more important! this could be negative. 
        bool ShouldOverrideLowerPriorityProperty { get; } 
    }
}
