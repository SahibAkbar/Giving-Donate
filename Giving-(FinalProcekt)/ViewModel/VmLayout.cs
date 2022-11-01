using Giving__FinalProcekt_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.ViewModel
{
    public class VmLayout
    {
        public List<Social> Socials { get; set; }
        public Setting Setting { get; set; }
        public Subscribe Subscribe { get; set; }
        public  List<HappyFaces>HappyFaces { get; set; }
        public  List<HomeSlider>HomeSliders { get; set; }
        public Subscribe Subscribes { get; set; }
    }
}
