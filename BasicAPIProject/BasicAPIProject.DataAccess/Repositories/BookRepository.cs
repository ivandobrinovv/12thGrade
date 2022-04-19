using BasicAPIProject.DataAccess.Entities;
using BasicAPIProject.DataAccess.Repositories.Interfaces;

namespace BasicAPIProject.DataAccess.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(PracticalAssignmentDbContext context)
            : base(context)
        {
        }
    }
}
