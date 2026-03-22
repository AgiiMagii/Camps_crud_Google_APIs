using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camps.Views
{
    public class SheetDataView
    {
        public int RowIndex { get; set; }
        public string Date { get; set; }

        public string Camp { get; set; }

        public string ChildName { get; set; }
        public string ChildSurname { get; set; }
        public string Gender { get; set; }
        public short BirthYear { get; set; }

        public string Interests { get; set; } = string.Empty;
        public string Avoidances { get; set; } = string.Empty;
        public string EatingHabits { get; set; } = string.Empty;

        public string ParentName { get; set; }
        public string ParentSurname { get; set; }
        public string ParentType { get; set; }
        public string ParentEmail { get; set; }
        public string ParentPhone { get; set; }
        public string ParentAddress { get; set; }

        public string ParentName1 { get; set; } = string.Empty;
        public string ParentSurname1 { get; set; } = string.Empty;
        public string ParentType1 { get; set; } = string.Empty;
        public string ParentPhone1 { get; set; } = string.Empty;
    }
}
