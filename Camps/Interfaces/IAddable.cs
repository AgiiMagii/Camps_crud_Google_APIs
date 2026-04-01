using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camps.Interfaces
{
    public interface IAddable
    {
        void Add();
        bool CanAdd { get; }
    }
}
