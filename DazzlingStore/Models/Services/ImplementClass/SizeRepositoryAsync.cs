using DazzlingStore.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Diagnostics;

namespace DazzlingStore.Models.Services.ImplementClass;

public class SizeRepositoryAsync : IRepositoryAsyn<Size>
{

    private readonly DatabaseContext _databaseContext;

    public SizeRepositoryAsync(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<bool> AddAsync(Size entity)
    {
        try
        {
            _databaseContext.Sizes.Add(entity);

            var affectRows = await _databaseContext.SaveChangesAsync();

            return affectRows > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public async Task<bool> DeleteAsync(Size entity)
    {
        try
        {
            if (entity.IsDeleted == true)
            {
                _databaseContext.Sizes.Remove(entity);
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

    public async Task<IEnumerable<Size>> GetAllAsync() => await _databaseContext.Sizes.ToListAsync();

    public async Task<Size> GetByIdAsync(int id)
    {
        return await _databaseContext.Sizes.FindAsync(id)!;
    }

    public async Task<bool> UpdateAsync(Size entity)
    {
        try
        {
            _databaseContext.Sizes.Update(entity);

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
