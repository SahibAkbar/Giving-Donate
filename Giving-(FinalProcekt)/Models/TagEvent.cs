using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.Models
{
    public class TagEvent
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50),Required]
        public string Name  { get; set; }

        public List<TagToEvent> TagToEvents { get; set; }
    }
}
