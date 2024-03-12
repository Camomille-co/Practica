﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jhyf.Data;
using jhyf.Data.Identity;

namespace jhyf.Pages.Lectures
{
    public class DetailsModel : PageModel
    {
        private readonly jhyf.Data.ApplicationDbContext _context;

        public DetailsModel(jhyf.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public AddLectures AddLectures { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addlectures = await _context.Lectures.FirstOrDefaultAsync(m => m.Id == id);
            if (addlectures == null)
            {
                return NotFound();
            }
            else
            {
                AddLectures = addlectures;
            }
            return Page();
        }
    }
}
