namespace BasicAPIProject.Models.Books
{
    public class BookResponseModel : BaseResponseModel
    {
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
    }
}
