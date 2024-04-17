
using System.ComponentModel.DataAnnotations;

namespace AuthSystem.ViewModel
{
    public class InfoViewModel
    {
      
        public int id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Url { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        
        public string? UserId { get; set; }

        
    }
}
