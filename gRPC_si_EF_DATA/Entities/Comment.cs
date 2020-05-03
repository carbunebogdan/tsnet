using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gRPC_si_EF_DATA.Entities
{
    public sealed class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public System.Guid CommentId { get; set; }

        public string Text { get; set; }

        public System.Guid PostPostId { get; set; }

        public Post Post { get; set; }
    }
}
