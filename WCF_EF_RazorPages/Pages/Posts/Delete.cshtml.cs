using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using WCF_EF_RazorPages.Models;
using ServiceReferencePostComment;

namespace WCF_EF_RazorPages.Pages.Posts
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public PostDTO PostDTO { get; set; }
        PostCommentClient pcc = new PostCommentClient();
        public DeleteModel()
        {

        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();
            var post = await pcc.GetPostByIdAsync(id.Value);
            if (post != null)
            {
                PostDTO = PostCommentDTO.GetPostDTO(post);
                return Page();
            }
            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            int result = 0;

            try
            {
                result = await pcc.DeletePostAsync(id.Value);
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error");
            }

            return RedirectToPage("./Index");
        }
    }
}