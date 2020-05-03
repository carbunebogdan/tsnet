using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gRPC_si_EF_DATA.Entities
{
    public sealed class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public System.Guid PostId { get; set; }

        public string Description { get; set; }

        public string Domain { get; set; }

        public string Date { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}