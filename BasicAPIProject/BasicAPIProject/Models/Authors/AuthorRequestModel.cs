using System.ComponentModel.DataAnnotations;

namespace BasicAPIProject.Models.Authors
{
    public class AuthorRequestModel : BaseRequestModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
    }
}
