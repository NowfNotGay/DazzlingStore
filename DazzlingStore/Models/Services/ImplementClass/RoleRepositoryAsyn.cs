using DazzlingStore.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DazzlingStore.Models.Services.ImplementClass;

public class RoleRepositoryAsyn : IRepositoryAsyn<Role>
{
    private readonly DatabaseContext _databaseContext;

    public RoleRepositoryAsyn(DatabaseContext databaseContext)
    {
        // Dependency Injection: Inject đối tượng DatabaseContext vào constructor của RoleRepositoryAsyn.
        _databaseContext = databaseContext;
    }

    public async Task<bool> AddAsync(Role entity)
    {
        try
        {
            // Thêm đối tượng Role vào DbSet trong cơ sở dữ liệu bằng cách sử dụng async.
            _databaseContext.Roles.Add(entity);

            // Lưu thay đổi vào cơ sở dữ liệu và kiểm tra xem có bất kỳ dòng nào bị ảnh hưởng (sử dụng async).
            var affectedRows = await _databaseContext.SaveChangesAsync();

            // Nếu có dòng nào đó đã được thay đổi, trả về true để thông báo rằng thêm thành công.
            return affectedRows > 0;
        }
        catch (Exception ex)
        {
            // Trong trường hợp xảy ra lỗi, bắt ngoại lệ và trả về false để thông báo rằng thêm không thành công và in ra lỗi.
            Debug.WriteLine(ex);
            return false;
        }
    }

    public async Task<bool> DeleteAsync(Role entity)
    {
        try
        {
            // Xóa đối tượng Role vào DbSet trong cơ sở dữ liệu bằng cách sử dụng async.

            if (entity.IsDeleted == true)
            {
                _databaseContext.Roles.Remove(entity);

            }

            // Lưu thay đổi vào cơ sở dữ liệu và kiểm tra xem có bất kỳ dòng nào bị ảnh hưởng (sử dụng async).
            var affectedRows = await _databaseContext.SaveChangesAsync();

            // Nếu có dòng nào đó đã được thay đổi, trả về true để thông báo rằng thêm thành công.
            return affectedRows > 0;
        }
        catch (Exception ex)
        {
            // Trong trường hợp xảy ra lỗi, bắt ngoại lệ và trả về false để thông báo rằng thêm không thành công và in ra lỗi.
            Debug.WriteLine(ex);
            return false;
        }
    }

    // Lấy tất cả các đối tượng Role từ cơ sở dữ liệu bất đồng bộ.
    public async Task<IEnumerable<Role>> GetAllAsync() => await _databaseContext.Roles.ToListAsync();

    // - Đối tượng Role có ID tương ứng hoặc null nếu không tìm thấy.
    public async Task<Role> GetByIdAsync(int id) => await _databaseContext.Roles.FindAsync(id);

    public async Task<bool> UpdateAsync(Role entity)
    {
        try
        {
            // Sửa đối tượng Role vào DbSet trong cơ sở dữ liệu bằng cách sử dụng async.
            _databaseContext.Roles.Update(entity);

            // Lưu thay đổi vào cơ sở dữ liệu và kiểm tra xem có bất kỳ dòng nào bị ảnh hưởng (sử dụng async).
            var affectedRows = await _databaseContext.SaveChangesAsync();

            // Nếu có dòng nào đó đã được thay đổi, trả về true để thông báo rằng thêm thành công.
            return affectedRows > 0;
        }
        catch (Exception ex)
        {
            // Trong trường hợp xảy ra lỗi, bắt ngoại lệ và trả về false để thông báo rằng thêm không thành công và in ra lỗi.
            Debug.WriteLine(ex);
            return false;
        }
    }
}
