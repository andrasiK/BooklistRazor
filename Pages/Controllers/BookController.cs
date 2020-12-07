using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooklistRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooklistRazor.Pages.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        
            // need the ApplicationDbContext here also to work wih DB

       private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        // implement HTTP GET
        [HttpGet]
        public async Task<IActionResult>  GetAll()
        {
            return Json(new { data = await _db.Book.ToListAsync() });  
        }


        //delete with API
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb = await _db.Book.FirstOrDefaultAsync(u => u.Id == id);
            if (bookFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Book.Remove(bookFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successfull"});
        
        }
    }
}
