using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camps.Views
{
    public class CampsView
    {
        public long campID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<short> Capacity { get; set; }
        public string FullAddress { get; set; }
    }
}
