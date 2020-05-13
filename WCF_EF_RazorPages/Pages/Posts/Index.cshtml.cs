using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceReferencePostComment;
using WCF_EF_RazorPages.Models;

namespace WCF_EF_RazorPages.Pages.Posts
{
        public class IndexModel : PageModel
        {
            PostCommentClient pcc = new PostCommentClient();
            public List<PostDTO> Posts { get; set; }

            public IndexModel()
            {
                Posts = new List<PostDTO>();
            }

            public async Task OnGetAsync()
            {
                var posts = await pcc.GetPostsAsync();
                foreach (var post in posts)
                {
                    Posts.Add(PostCommentDTO.GetPostDTO(post));
                }
            }
        }
    
}