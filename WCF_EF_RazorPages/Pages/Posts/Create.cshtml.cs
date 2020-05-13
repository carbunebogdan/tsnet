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
    public class CreateModel : PageModel
    {
        PostCommentClient pcc = new PostCommentClient();
        [BindProperty]
        public PostDTO PostDTO { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            var result = await pcc.AddPostAsync(PostCommentDTO.GetPost(PostDTO));

            if (!result)
                return RedirectToAction("Error");
            return RedirectToPage("./Index");
        }
    }
}