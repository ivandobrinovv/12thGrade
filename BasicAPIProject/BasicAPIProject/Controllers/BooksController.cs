using AutoMapper;
using BasicAPIProject.DataAccess.Entities;
using BasicAPIProject.DataAccess.Repositories.Interfaces;
using BasicAPIProject.Models.Books;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookRepository.GetAllAsync();

            var models = _mapper.Map<List<BookResponseModel>>(books);

            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook([FromRoute]Guid id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if(book is null)
            {
                return NotFound();
            }
            
            var model = _mapper.Map<BookResponseModel>(book);

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody]BookRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var book = _mapper.Map<Book>(model);
            var createdBookId = await _bookRepository.CreateAsync(book);

            return Ok(createdBookId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute] Guid id, [FromBody]BookRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var book = _mapper.Map<Book>(model);
            book.Id = id;

            try
            {
                await _bookRepository.UpdateAsync(book);
            }
            catch(ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute]Guid id)
        {
            try
            {
                await _bookRepository.DeleteAsync(id);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
    }
}
