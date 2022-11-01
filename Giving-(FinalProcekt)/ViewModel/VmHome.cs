using Giving__FinalProcekt_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.ViewModel
{
    public class VmHome:VmLayout
    {
        public List<Cause> Causes { get; set; }
        public List<HomeSlider> HomeSlider { get; set; }
        public List<Event> Events { get; set; }
        public Cause Cause { get; set; }
        public List<Donate> Donates { get; set; }
        public List<Volunteer> Volunteers { get; set; }
        public Volunteer Volunteer { get; set; }
        public Contact Contact { get; set; }
        public About About { get; set; }
    }
}
