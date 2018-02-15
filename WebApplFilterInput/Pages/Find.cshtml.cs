using System;
using System.Collections.Generic;
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

        public async Task<IActionResult> OnPostResultAsync(string word)
        {
            //var result = await DataContext
            //    .Car
            //    .Where(x => x.Title.Contains(word))
            //    .Select(x => new
            //    {
            //        id = x.Id,
            //        name = x.Title
            //    })
            //    .ToListAsync();

            var result = await DataContext
                .Car
                .FromSql($"SELECT * FROM Car WHERE Title LIKE @p0 COLLATE NOCASE ORDER BY Title ASC", $"%{word}%")
                .Select(x => new
                {
                    id = x.Id,
                    name = x.Title
                })
                .ToListAsync();

            return new JsonResult(result);
        }
    }
}