using Book.Infrastructure;
using Book.Model.DataModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book.Data.DataModel
{
   public class History
    {

        [Key]
        public int ReviewId { get; set; }
        public string Status  { get; set; }

        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public virtual BookDetails BookDetails { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
