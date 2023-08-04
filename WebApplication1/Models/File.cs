using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class File
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FileName { get; set; }
               
        public byte[] FileData { get; set; }
       
    }
}
