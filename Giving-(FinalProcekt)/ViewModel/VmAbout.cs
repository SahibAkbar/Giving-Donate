using Giving__FinalProcekt_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.ViewModel
{
    public class VmAbout:VmLayout
    {
        public About About { get; set; }
        public Banner Banner { get; set; }
        public Cause Cause { get; set; }
        public Cause Cause1 { get; set; }
        public List<Partner> Partners { get; set; }
        public List<AboutOption> AboutOptions { get; set; }
    }
}
