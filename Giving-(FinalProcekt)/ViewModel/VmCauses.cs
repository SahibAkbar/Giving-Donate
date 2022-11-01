using Giving__FinalProcekt_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.ViewModel
{
    public class VmCauses:VmLayout
    {
        public Cause Cause { get; set; }
        public List<Cause> Causes { get; set; }
        public Banner Banner { get; set; }
        public Donate Donate { get; set; }
        public List<CauseGallery> CauseGalleries { get; set; }
        public CauseGallery CauseGalleri { get; set; }
        public List<Comment1> Comments { get; set; }
        public Comment1 Comment { get; set; }
        public CommentPost1 CommentPost { get; set; }
        public VmDonate VmDonate { get; set; }
        public VmSearch vmSearch { get; set; }
    }
}
