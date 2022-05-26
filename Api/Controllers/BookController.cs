using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly BookService _service;
    public BookController(BookService service)
    {
        _service = service;
    }    


    [HttpGet("GetBooks")]
    public async Task<List<Book>> GetBooks(){
        return await _service.GetBooks();
    }
      [HttpGet("GetBookById")]
    public async Task<Book> GetBookById(int id)
    {
        return await _service.GetBookById(id);
    }
    [HttpPost("Insert")]
    public async Task<int> Insert(Book book)
    {
        return await _service.Insert(book);
    }

    [HttpPut("Update")]
    public async Task<int> Update(Book model)
    {
        return await _service.Update(model);
    }

    [HttpDelete("Delete")]
    public async Task<int> Delete(int id){
        return await _service.Delete(id);
    }
}
