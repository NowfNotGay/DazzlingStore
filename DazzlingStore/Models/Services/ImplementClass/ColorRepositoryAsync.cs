using DazzlingStore.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Diagnostics;

namespace DazzlingStore.Models.Services.ImplementClass;

public class ColorRepositoryAsync : IRepositoryAsyn<Color>
{

    private readonly DatabaseContext _databaseContext;

    public ColorRepositoryAsync(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<bool> AddAsync(Color entity)
    {
        try
        {
            _databaseContext.Colors.Add(entity);

            var affectRows = await _databaseContext.SaveChangesAsync();

            return affectRows > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public async Task<bool> DeleteAsync(Color entity)
    {
        try
        {
            if (entity.IsDeleted == true)
            {
                _databaseContext.Colors.Remove(entity);
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

    public async Task<IEnumerable<Color>> GetAllAsync() => await _databaseContext.Colors.ToListAsync();

    public async Task<Color> GetByIdAsync(int id)
    {
        return await _databaseContext.Colors.FindAsync(id)!;
    }

    public async Task<bool> UpdateAsync(Color entity)
    {
        try
        {
            _databaseContext.Colors.Update(entity);

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
