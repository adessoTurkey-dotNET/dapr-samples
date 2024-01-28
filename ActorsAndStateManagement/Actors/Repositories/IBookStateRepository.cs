using BookControlService.Models;

namespace BookControlService.Repositories;

public interface IBookStateRepository
{
    Task SaveBookStateAsync(BookState bookState);
    Task<BookState?> GetBookStateAsync(string licenseNumber);
}
