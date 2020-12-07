using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooklistRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BooklistRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        // need ApplicationDbContext to get books from database
        // dependency injection is used here, do no need to create an object and all the other things

        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // return a list of IEnumerable of books
        public IEnumerable<Book> Books {get; set;}

        // async - await :varja meg amig betoltodnek a konyvek. Szerintem....
        // this is the GET handler
        // in MVC this would be Action method. But here in Razor pages we have handlers inside the page model
        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync(); 
        }

        // Delete custom posthandler. Use IActionResult here, because we will be redirecting to a page (same page)
             
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            _db.Book.Remove(book);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }

    }
}
