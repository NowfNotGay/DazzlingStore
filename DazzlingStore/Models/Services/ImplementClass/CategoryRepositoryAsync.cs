using DazzlingStore.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Diagnostics;

namespace DazzlingStore.Models.Services.ImplementClass;

public class CategoryRepositoryAsync : IRepositoryAsyn<Category>
{

    private readonly DatabaseContext _databaseContext;

    public CategoryRepositoryAsync(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<bool> AddAsync(Category entity)
    {
        try
        {
            _databaseContext.Categories.Add(entity);

            var affectRows = await _databaseContext.SaveChangesAsync();

            return affectRows > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public async Task<bool> DeleteAsync(Category entity)
    {
        try
        {
            if (entity.IsDeleted == true)
            {
                _databaseContext.Categories.Remove(entity);
            }

            var affectRows = await _databaseContext.SaveChangesAsync();

            return affectRows > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public async Task<IEnumerable<Category>> GetAllAsync() => await _databaseContext.Categories.ToListAsync();

    public async Task<Category> GetByIdAsync(int id)
    {
        return await _databaseContext.Categories.FindAsync(id)!;
    }

    public async Task<bool> UpdateAsync(Category entity)
    {
        try
        {
            _databaseContext.Categories.Update(entity);

            var affectRows = await _databaseContext.SaveChangesAsync();

            return affectRows > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }

    }
}
