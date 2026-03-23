using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camps.Views
{
    public class ParticipiantView
    {
        public long childID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public Nullable<short> BirthYear { get; set; }
        public List<ParentsView> Parents { get; set; } = new List<ParentsView>();
    }
}
