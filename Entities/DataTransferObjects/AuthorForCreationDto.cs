using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class AuthorForCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Country of residence is required")]
        [StringLength(60, ErrorMessage = "Country of residence can't be longer than 45 characters")]
        public string? CountryOfResidence { get; set; }
        [Required(ErrorMessage = "Country of origin is required")]
        [StringLength(60, ErrorMessage = "Country of origin can't be longer than 45 characters")]
        public string? CountryOfOrigin { get; set; }
    }
}
