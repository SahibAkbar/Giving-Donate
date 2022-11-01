using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.Models
{
    public class FAQ
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title  { get; set; }

        [Column(TypeName ="ntext")]
        public string Content { get; set; }
    }
}
