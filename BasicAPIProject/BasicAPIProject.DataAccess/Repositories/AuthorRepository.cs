using BasicAPIProject.DataAccess.Entities;
using BasicAPIProject.DataAccess.Repositories.Interfaces;

namespace BasicAPIProject.DataAccess.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(PracticalAssignmentDbContext context)
            :base(context)
        {
        }
    }
}
