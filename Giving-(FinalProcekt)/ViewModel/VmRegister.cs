using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.ViewModel
{
    public class VmRegister
    { 

        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Surname { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }

        //[MaxLength(50)]
        //public string PhoneNumber { get; set; }

        //[MaxLength(15), Required]
        //public string UserName { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
    }
}
