using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

using gRPC_si_EF_DATA.API;

namespace gRPC_si_EF_SERVICIU
{

    public class PostCommentService : Greeter.GreeterBase
    {
        private readonly ILogger<PostCommentService> _logger;
        private readonly CommentRepository _commentRepository;
        private readonly PostRepository _postRepository;

        public PostCommentService(ILogger<PostCommentService> logger)
        {
            _logger = logger;
        }

        public bool AddComment(Comment comment)
        {
            return _commentRepository.AddComment(new gRPC_si_EF_DATA.Entities.Comment
            {
                CommentId = Guid.Parse(comment.CommentId),
                Text = comment.Text,
                PostPostId = Guid.Parse(comment.PostPostId)
            });
        }

        public bool AddPost(Post post)
        {
            return _postRepository.AddPost(new gRPC_si_EF_DATA.Entities.Post
            {
                PostId = Guid.Parse(post.PostId),
                Description = post.Description,
                Domain = post.Domain,
                Date = post.Date
            });
        }

        public int DeletePost(Guid id)
        {
            return _postRepository.DeletePost(id);
        }

        public Comment GetCommentById(Guid id)
        {
            var comment = _commentRepository.GetCommentById(id);
            return new Comment
            {
                CommentId = comment.CommentId.ToString(),
                Text = comment.Text,
                PostPostId = comment.PostPostId.ToString()
            };
        }

        public Post GetPostById(Guid id)
        {
            Console.WriteLine("GetPostById. Id = {0}", id);
            var post = _postRepository.GetPostById(id);
            Console.WriteLine("Post returnat. Id = {0} , Description = {1}", post.PostId, post.Description);

            return new Post
            {
                PostId = post.PostId.ToString(),
                Description = post.Description,
                Domain = post.Domain,
                Date = post.Date
            };
        }

        public List<Post> GetPosts()
        {
            var posts = _postRepository.GetAllPosts();
            var newPosts = new List<Post>();
            posts.ForEach(post => newPosts.Add(new Post
            {
                PostId = post.PostId.ToString(),
                Description = post.Description,
                Domain = post.Domain,
                Date = post.Date
            }));

            return newPosts;
        }

        public Comment UpdateComment(Comment newComment)
        {
            var comment = _commentRepository.UpdateComment(new gRPC_si_EF_DATA.Entities.Comment
            {
                CommentId = Guid.Parse(newComment.CommentId),
                Text = newComment.Text,
                PostPostId = Guid.Parse(newComment.PostPostId)
            });

            return new Comment
            {
                CommentId = comment.CommentId.ToString(),
                Text = comment.Text,
                PostPostId = comment.PostPostId.ToString()
            };
        }

        public Post UpdatePost(Post newPost)
        {
            var post = _postRepository.UpdatePost(new gRPC_si_EF_DATA.Entities.Post
            {
                PostId = Guid.Parse(newPost.PostId),
                Description = newPost.Description,
                Domain = newPost.Domain,
                Date = newPost.Date,
            });

            return new Post
            {
                PostId = post.PostId.ToString(),
                Description = post.Description,
                Domain = post.Domain,
                Date = post.Date,
            };
        }
    }
}
