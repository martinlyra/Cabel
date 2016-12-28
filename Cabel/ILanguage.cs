using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabel
{
    // TODO: Integrate this into the language classes
    interface ILanguage
    {
        string Name { get; }
        IEnumerable<string> Words { get; }
    }
}
