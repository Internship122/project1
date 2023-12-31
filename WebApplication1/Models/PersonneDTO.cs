﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class PersonneDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Prename { get; set; }
        public int Age { get; set; }
    }
}
