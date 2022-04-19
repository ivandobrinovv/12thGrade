using AutoMapper;
using BasicAPIProject.DataAccess.Entities;
using BasicAPIProject.DataAccess.Repositories.Interfaces;
using BasicAPIProject.Models.Authors;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorRepository.GetAllAsync();

            var models = _mapper.Map<List<AuthorResponseModel>>(authors);

            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(Guid id)
        {
            var author = await _authorRepository.GetByIdAsync(id);

            if (author is null)
            {
                return NotFound();
            }

            var model = _mapper.Map<AuthorResponseModel>(author);

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(AuthorRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var author = _mapper.Map<Author>(model);

            var createdAuthorId = await _authorRepository.CreateAsync(author);

            return Ok(createdAuthorId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor([FromRoute] Guid id, [FromBody] AuthorRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var author = _mapper.Map<Author>(model);
            author.Id = id;
            try
            {
                await _authorRepository.UpdateAsync(author);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor([FromRoute] Guid id)
        {
            try
            {
                await _authorRepository.DeleteAsync(id);
            }
            catch(ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
    }
}
