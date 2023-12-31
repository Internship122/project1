﻿using System;
using System.ComponentModel.DataAnnotations;
using HotChocolate.Data;

namespace WebApplication1.Models
{
    public class Personne
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Enter a Name")]
        [StringLength(50)]
        [UseSorting]
        public string Name { get; set; }
        [Required(ErrorMessage ="Enter a Prename")]
        public string Prename { get; set; }
        [DataType(DataType.Date)]
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
