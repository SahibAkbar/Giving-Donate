using Giving__FinalProcekt_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.ViewModel
{
    public class VmVolunteer:VmLayout
    {
        public List<Volunteer> Volunteers { get; set; }
        public Volunteer Volunteer { get; set; }
        public Banner Banner { get; set; }
    }
}
