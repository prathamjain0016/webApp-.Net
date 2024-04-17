using AuthSystem.Areas.Identity.Data;

namespace AuthSystem.Models
{
    public class info
    {
        public int id { get; set; }
        public string Title { get; set; }

        public string Url {  get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string? UserId { get; set; }

        public ApplicationUser? User { get; set; }


    }
}
