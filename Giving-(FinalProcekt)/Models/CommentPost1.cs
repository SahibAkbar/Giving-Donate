using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.Models
{
    public class CommentPost1
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(60),Required]
        public string Name { get; set; }

        [MaxLength(50),Required]
        public string Email { get; set; }

        [Required]
        public string Content { get; set; }

        [NotMapped]
        public int CauseId { get; set; }

        [NotMapped]
        public int CommentId { get; set; }

        public List<Comment1> Comment { get; set; }

    }
}
