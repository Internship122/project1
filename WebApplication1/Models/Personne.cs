using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Personne
    {
        [Key]

        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Prename { get; set; }

        public DateTime BirthDate { get; set ; }

        //public Personne(int id, string name, string prename, DateTime birthDate)
        //{
        //    Id = id;

        //    Name = name;

        //    Prename = prename;

        //    BirthDate = birthDate.Date;

        //}

        public static int Age(DateTime BirthDate)
        {
            var age = Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(BirthDate.Year);
            return age;
        }

        //internal static int Age(object birthDate)
        //{
        //    throw new NotImplementedException();
        //}
    }

   
    
}
