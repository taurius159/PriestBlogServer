using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class ArticleDto
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEdited { get; set; }
        public string? ArticleType { get; set; }
    }
}
