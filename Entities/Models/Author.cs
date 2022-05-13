using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("author")]
    public class Author
    {
        [Column("AuthorId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "CountryOfResidence is required")]
        [StringLength(45, ErrorMessage = "CountryOfResidence cannot be longer than 45 characters")]
        public string? CountryOfResidence { get; set; }

        [Required(ErrorMessage = "CountryOfOrigin is required")]
        [StringLength(45, ErrorMessage = "CountryOfOrigin cannot be longer than 45 characters")]
        public string? CountryOfOrigin { get; set; }

        public ICollection<Article>? Articles { get; set; }
    }
}