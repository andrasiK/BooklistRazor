using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BooklistRazor.Model;

namespace BooklistRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        // can use bind property here
        
            private ApplicationDbContext _db;

                public EditModel(ApplicationDbContext db)
            {
                _db = db;
            }

        [BindProperty]
        public Book Book { get; set; }
        

        // get an ID passed from Index screen. Based on this integer will retrive the book from DB
        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);

        }

        // here we use IActionresult because we want to redirect to a page
        public async Task<IActionResult> OnPost()
        {
            // retrive the book from DB to update
            if (ModelState.IsValid)
            {
                var BookFromDb = await _db.Book.FindAsync(Book.Id);
                BookFromDb.Name = Book.Name;
                BookFromDb.Author = Book.Author; 
                BookFromDb.ISBN = Book.ISBN;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return RedirectToPage();

        }

    }
}
