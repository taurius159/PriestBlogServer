using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("article")]
    public class Article
    {
        [Column("ArticleId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(45, ErrorMessage = "Description cannot be longer than 100 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Content is required")]
        public string? Content { get; set; }

        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }
        public Author? Author { get; set; }

        [Required(ErrorMessage = "Date created is required")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Date edited is required")]
        public DateTime DateEdited { get; set; }

        [Required(ErrorMessage = "Article type is required")]
        public string? ArticleType { get; set; }
    }
}