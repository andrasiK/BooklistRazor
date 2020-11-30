using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooklistRazor.Model
{
    public class Book
    {
       [Key]               // This is a data annotation
        public int Id { get; set; }

        [Required]        // display attribute. Means 'Name' cannot be NULL
        public string Name { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

    }
}
