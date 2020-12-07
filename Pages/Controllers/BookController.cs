using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooklistRazor.Model;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            return Json(new { data = _db.Book.ToList() });  
        }
    }
}
