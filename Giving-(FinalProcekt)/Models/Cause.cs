using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.Models
{
    public class Cause
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [MaxLength(50),Required]
        public string Title  { get; set; }

        [Column(TypeName ="ntext"),Required]
        public string Content { get; set; }

        [MaxLength(250),Required]
        public string Address { get; set; }

        public int CauseNeed { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<CauseGallery> CauseGalleries { get; set; }
        public List<Comment1> Comments { get; set; }
        public List<DonatePrice> DonatePrices { get; set; }
    }
}
