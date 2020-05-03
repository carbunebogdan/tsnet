using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostComment.Entities
{
    public sealed class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PostId { get; set; }

        public string Description { get; set; }

        public string Domain { get; set; }

        public string Date { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
