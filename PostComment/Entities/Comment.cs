using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostComment.Entities
{
    public sealed class EComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CommentId { get; set; }

        public string Text { get; set; }

        public int PostPostId { get; set; }

        public Post Post { get; set; }
    }
}
