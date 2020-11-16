using Book.Data.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Model.DataModel
{
    public class BookDetails
    {
        [Key]
        public int BookId { get; set; }
        [Required(ErrorMessage = "Book  Name is required")]
        public string BookName { get; set; }
        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }
        [Required(ErrorMessage = "BSN is required")]
        public int BSN { get; set; }


        public virtual Favorites Favorites { get; set; }
        public virtual Review Review { get; set; }
        public virtual History History { get; set; }
    }
}
