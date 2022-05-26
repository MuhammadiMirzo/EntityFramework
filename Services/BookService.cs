using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Services;

public class BookService
{
    private readonly DataContext _context;

    public BookService(DataContext context)
    {
        _context = context;
    }

    // select * from books
    public async Task<List<Book>> GetBooks()
    {
        var books = _context.Books.ToList();
        return books;
    }

    //insert into Book 
    public async Task<int> Insert(Book book)
    {
         _context.Add(book);
         var inserted =  await _context.SaveChangesAsync();

        return inserted;

    }
    
    //update into Book 
    public async Task<int> Update(Book model)
    {
        var book  = await _context.Books.FindAsync(model.Id);
        book.Name = model.Name;
        book.NumberOfPages = model.NumberOfPages;
        
        var updated =  await _context.SaveChangesAsync();

        return updated;

    }

    //select * from books where id  = id
    public async Task<Book>  GetBookById(int id)
    {
        var book = await _context.Books.FindAsync(id);
        return  book;
    }

    public async Task<int> Delete(int id)
    {
        var book = await _context.Books.FindAsync(id);
        _context.Books.Remove(book);
        return await _context.SaveChangesAsync();
    }
}


