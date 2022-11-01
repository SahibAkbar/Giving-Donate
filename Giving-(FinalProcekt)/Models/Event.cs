using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [MaxLength(100)]
        public string Title  { get; set; }

        [Column(TypeName ="ntext")]
        public string Content { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }

        [MaxLength(1000)]
        public string IframeLink { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<TagToEvent> TagToEvents { get; set; }

        [NotMapped]
        public string Base64 { get; set; }
        [NotMapped]
        public List<int> TagEventId { get; set; }
    }
}
