using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.Models
{
    public class CustomUser : IdentityUser
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string Title { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }


        [NotMapped]
        public string RoleId { get; set; }
    }
}
