using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camps.Views
{
    public class ContractsView
    {
        public long contractID { get; set; }
        public string CampName { get; set; }
        public string ChildFullName { get; set; }
        public string ParentFullName { get; set; }
        public string ParentFullName2 { get; set; } = string.Empty;
        public string ParentPhone { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<decimal> Balance { get; set; }
    }
}
