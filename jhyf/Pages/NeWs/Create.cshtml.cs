using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using jhyf.Data;
using jhyf.Data.Identity;

namespace jhyf.Pages.NeWs
{
    public class CreateModel : PageModel
    {
        private readonly jhyf.Data.ApplicationDbContext _context;

        IWebHostEnvironment _appEnvironment;

        public CreateModel(jhyf.Data.ApplicationDbContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AddNews AddNews { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync([Bind("Id,...ImageNews")] AddNews news, IFormFile Image)
        {
            if (!ModelState.IsValid)
            {
                return Page();

                //if (Image!=null)
                //{
                //    if(Image.Length > 0)
                //    {
                //        byte[] p1 = null;
                //        using (var fs1 = Image.OpenReadStream())
                //        {
                //            using (var ms1 = new MemoryStream())
                //            {
                //                fs1.CopyTo(ms1);
                //                p1 = ms1.ToArray();
                //            }
                //            AddNews.ImageNews = p1;
                //        }
                //    }
                //}
            }

            _context.News.Add(AddNews);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        //[HttpPost]
        //public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        //{
        //    if (uploadedFile != null)
        //    {
        //        string path = "/Files/" + uploadedFile.FileName;

        //        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
        //        {
        //            await uploadedFile.CopyToAsync(fileStream);
        //        }

        //        AddNews file = new AddNews { NameFile = uploadedFile.FileName, ImageNews = path };
        //        _context.News.Add(file);
        //        _context.SaveChanges();
        //    }

        //    return RedirectToAction("Index");
        //}
    }
}
