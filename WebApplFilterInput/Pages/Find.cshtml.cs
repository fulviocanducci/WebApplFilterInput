using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplFilterInput.Model;

namespace WebApplFilterInput.Pages
{
    public class FindModel : PageModel
    {
        public readonly DataContext DataContext;

        public FindModel(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {

        }

        public async Task<IActionResult> OnGetResultAsync(string word)
        {
            return new JsonResult(await GetResult(word));
        }

        public async Task<IActionResult> OnPostResultAsync(string word)
        {
            return new JsonResult(await GetResult(word));
        }

        public async Task<dynamic> GetResult(string word)
        {            
            return await DataContext
                .Car
                .FromSql($"SELECT * FROM Car WHERE Title LIKE @p0 COLLATE NOCASE ORDER BY Title ASC", $"%{word}%")
                .Select(x => new
                {
                    id = x.Id,
                    name = x.Title
                })
                .ToListAsync();
        }
    }
}