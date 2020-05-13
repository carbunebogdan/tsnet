using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceReferencePostComment;

namespace WCF_EF_RazorPages.Models
{
    public static class PostCommentDTO
    {
        public static PostDTO GetPostDTO(Post post)
        {
            PostDTO postDTO = new PostDTO()
            {
                PostId = post.PostId,
                Description = post.Description,
                Date = post.Date,
                Domain = post.Domain,
            };
            foreach (var comment in post.Comments)
            {
                postDTO.Comments.Add(GetCommentDTO(comment));
            }
            return postDTO;
        }

        public static CommentDTO GetCommentDTO(Comment comm)
        {
            return new CommentDTO()
            {
                PostPostId = comm.PostPostId,
                Text = comm.Text
            };
        }

        public static Post GetPost(PostDTO postDTO)
        {
            return new Post()
            {
                Domain = postDTO.Domain,
                Description = postDTO.Description,
                Date = postDTO.Date
            };
        }

        public static Comment GetComment(CommentDTO commDTO)
        {
            return new Comment()
            {

            };
        }
    }
}
