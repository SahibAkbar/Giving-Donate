using Giving__FinalProcekt_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.ViewModel
{
    public class VmEvent:VmLayout
    {
        public List<Event> Events { get; set; }
        public Event Event { get; set; }
        public Banner Banner { get; set; }
        public List<TagEvent> TagEvents { get; set; }
        public Event Relevent { get; set; }
        public List<Event> PastEvents { get; set; }

        public VmSearch Search { get; set; }
    }
}
