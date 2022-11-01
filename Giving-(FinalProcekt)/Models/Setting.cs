using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.Models
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Logo { get; set; }
        [NotMapped]
        public IFormFile LogoFile { get; set; }

        [MaxLength(50),Required]
        public string Email { get; set; }

        [MaxLength(50),Required]
        public string Phone { get; set; }

        [MaxLength(250),Required]
        public string Adress { get; set; }

        [MaxLength(1000),Required]
        public string IframeLink { get; set; }
    }
}
