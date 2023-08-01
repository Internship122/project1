﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Personne
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Prename { get; set; }
  
        public DateTime BirthDate { get; set ; }
        

        public Personne(int id, string name, string prename, DateTime birthDate)
        {
            Id = id;

            Name = name;

            Prename = prename;

            BirthDate = birthDate;

        }

        public int Age(DateTime BirthDate)
        {
            var age = Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(BirthDate.Year);
            return age;
        }


    }

   
    
}
