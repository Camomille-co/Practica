using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using jhyf.Data;
using jhyf.Data.Identity;
using jhyf.FileUploadServiice;
using System.ComponentModel.DataAnnotations;

namespace jhyf.Pages.NeWs
{
    public class CreateModel : PageModel
    {
        private readonly jhyf.Data.ApplicationDbContext _context;

        IWebHostEnvironment _appEnvironment;

        private readonly IFileUploadService fileUploadService;

        public string FilePath;

        public CreateModel(jhyf.Data.ApplicationDbContext context, IWebHostEnvironment appEnvironment, IFileUploadService _fileUploadService)
        {
            _context = context;
            _appEnvironment = appEnvironment;
            fileUploadService = _fileUploadService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AddNews AddNews { get; set; } = default!;

        //public class InputModel
        //{
        //    [Display(Name = "Заголовок")]
        //    public string Title { get; set; }

        //    [Display(Name = "Путь фотографии")]
        //    public string NameFile { get; set; }

        //    [Display(Name = "Фото")]
        //    public byte[] ImageNews { get; set; }

        //    [Display(Name = "Ссылка на новость")]
        //    public string LinkImage { get; set; }

        //    [Display(Name = "Текст новости")]
        //    public string Description { get; set; }

        //    [Display(Name = "Название файла")]
        //    public string NameDoc { get; set; }

        //    [Display(Name = "Ссылка на файл из google диска")]
        //    public string LinkFile { get; set; }
        //}

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (file != null)
            {
                FilePath = await fileUploadService.UploadFileAsync(file);
            }

            AddNews = new AddNews
            {
                Title = AddNews.Title,
                NameFile = FilePath,
                ImageNews = AddNews.ImageNews,
                LinkImage = AddNews.LinkImage,
                Description = AddNews.Description,
                NameDoc = AddNews.NameDoc,
                LinkFile = AddNews.LinkFile
            };

            _context.News.Add(AddNews);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        //public async Task<IActionResult> OnPostAsync(IFormFile file)
        //{
        //    if(file != null)
        //    {
        //        FilePath = await fileUploadService.UploadFileAsync(file);
        //    }

        //    return RedirectToPage("./Index");
        //}

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
