using Book.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Book.Model.DataModel
{
  public  class Favorites
    {
        [Key]
        public int FavId { get; set; }
        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public virtual BookDetails BookDetails { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
