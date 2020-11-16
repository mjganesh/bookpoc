using Book.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book.Model.DataModel
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public virtual BookDetails BookDetails { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string Status { get; set; }

    }
} 

