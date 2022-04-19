using System.ComponentModel.DataAnnotations;

namespace BasicAPIProject.Models.Books
{
    public class BookRequestModel : BaseRequestModel
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        public Guid AuthorId { get; set; }
    }
}
