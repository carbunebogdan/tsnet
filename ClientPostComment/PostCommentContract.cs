using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PostComment
{
    [ServiceContract]
    public interface IPostCommentService : IPostsService, ICommentsService
    {

    }

    [DataContract]
    public class PostDto
    {
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Domain { get; set; }
    }

    [DataContract]
    public class CommentDto
    {
        [DataMember]
        public string Text { get; set; }
    }

    [ServiceContract]
    public interface ICommentsService
    {
        [OperationContract]
        void AddPostComment(Guid postId, CommentDto commentDto);

        [OperationContract]
        void AddCommentComment(Guid commentId, CommentDto commentDto);

        [OperationContract]
        void DeleteComment(Guid commentId);
    }

    [ServiceContract]
    public interface IPostsService
    {
        [OperationContract]
        void AddPost(PostDto postDto);

        [OperationContract]
        void UpdatePost(Guid id, PostDto postDto);

        [OperationContract]
        void DeletePost(Guid id);
    }
}
