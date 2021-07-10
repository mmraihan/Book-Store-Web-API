using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Model
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please add Book's Title")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
