﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? CountryOfResidence { get; set; }
        public string? CountryOfOrigin { get; set; }

    }
}
