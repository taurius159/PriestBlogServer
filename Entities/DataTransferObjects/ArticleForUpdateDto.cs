using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class ArticleForUpdateDto
    {
        [Required(ErrorMessage = "Description is required")]
        [StringLength(100, ErrorMessage = "Description can't be longer than 100 characters")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Content is required")]
        public string? Content { get; set; }
        [Required(ErrorMessage = "DateCreated is required")]
        public DateTime DateCreated { get; set; }
        [Required(ErrorMessage = "DateEdited is required")]
        public DateTime DateEdited { get; set; }
        [Required(ErrorMessage = "ArticleType is required")]
        [StringLength(45, ErrorMessage = "ArticleType can't be longer than 45 characters")]
        public string? ArticleType { get; set; }
    }
}
