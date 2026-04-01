using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camps.Interfaces
{
    internal interface IDeletable
    {
        void Delete();
        bool CanDelete { get; }

    }
}
