using Domain.Models;

namespace HttpClients.Interfaces;

public interface ICategoryService
{
    Task<Category> CreateAsync(Category category);
}