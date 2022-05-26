using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class ArticleForCreationDto
    {
        [Required(ErrorMessage = "Description is required")]
        [StringLength(60, ErrorMessage = "Description can't be longer than 100 characters")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Content is required")]
        public string? Content { get; set; }
        [Required(ErrorMessage = "AuthorId is required")]
        public Guid AuthorId { get; set; }
        [Required(ErrorMessage = "DateCreated is required")]
        public DateTime DateCreated { get; set; }
        [Required(ErrorMessage = "DateEdited is required")]
        public DateTime DateEdited { get; set; }
        [Required(ErrorMessage = "ArticleType is required")]
        public string? ArticleType { get; set; }

    }
}
