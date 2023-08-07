using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Models
{
    public class File
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter a filename")]
        [UseSorting]
        public string FileName { get; set; }
               
        public byte[] FileData { get; set; }
       
    }
}
