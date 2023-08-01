using javax.xml.bind.annotation;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class File
    {
        [Key]
        [Required]
        public string FileName { get; set; }
               
        public byte[] FileData { get; set; }
       
    }
}
