using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.Models
{
    public class Comment1
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("ParentComment")]
        public int? ParentCommentId { get; set; }
        public Comment1 ParentComment { get; set; }

        [ForeignKey("Cause")]
        public int CauseId { get; set; }
        public Cause Cause { get; set; }

        [ForeignKey("CommentPost")]
        public int CommentPostId { get; set; }
        public CommentPost1 CommentPost { get; set; }

    }
}
