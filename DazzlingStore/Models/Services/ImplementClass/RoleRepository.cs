using DazzlingStore.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;

namespace DazzlingStore.Models.Services.ImplementClass;

public class RoleRepository : IRepository<Role>
{
    private readonly DatabaseContext _databaseContext;

    public RoleRepository(DatabaseContext databaseContext)
    {
        // Dependency Injection: Inject đối tượng DatabaseContext vào constructor của RoleRepository.
        _databaseContext = databaseContext;
    }


    public bool Add(Role entity)
    {
        try
        {
            // Thêm đối tượng Role vào DbSet trong cơ sở dữ liệu.
            _databaseContext.Roles.Add(entity);

            // Lưu thay đổi vào cơ sở dữ liệu và kiểm tra xem có bất kỳ dòng nào bị ảnh hưởng.
            // Nếu có dòng nào đó đã được thay đổi, thì trả về true để thông báo rằng thêm thành công.
            return _databaseContext.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            // Trong trường hợp xảy ra lỗi, bắt ngoại lệ và trả về false để thông báo rằng thêm không thành công và in ra lỗi.
            Debug.WriteLine(ex);
            return false;
        }
    }

    public bool Delete(Role entity)
    {
        try
        {
            // Kiểm tra xem đối tượng có được phép xóa hay không (trường IsDeleted).
            if (entity.IsDeleted == true)
            {
                // Nếu được phép xóa, loại bỏ đối tượng Role khỏi DbSet của cơ sở dữ liệu.
                _databaseContext.Roles.Remove(entity);
            }
            // Lưu thay đổi vào cơ sở dữ liệu và kiểm tra xem có bất kỳ dòng nào bị ảnh hưởng.
            // Nếu có dòng nào đó đã được xóa, thì trả về true để thông báo rằng xóa thành công.
            return _databaseContext.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            // Trong trường hợp xảy ra lỗi, bắt ngoại lệ và trả về false để thông báo rằng xóa không thành công.
            return false;
        }
    }

    // Lấy tất cả các Role đang có
    public IEnumerable<Role> GetAll() => _databaseContext.Roles;


    // Lấy Role phù hợp với Id
    public Role GetById(int id) => _databaseContext.Roles.Find(id)!;

    public bool Update(Role entity)
    {
        try
        {
            // Sử dụng phương thức Update() của DbSet để đánh dấu đối tượng Role là cần cập nhật.
            _databaseContext.Roles.Update(entity);

            // Lưu thay đổi vào cơ sở dữ liệu và kiểm tra xem có bất kỳ dòng nào bị ảnh hưởng.
            // Nếu có dòng nào đó đã được cập nhật, thì trả về true để thông báo rằng cập nhật thành công.
            return _databaseContext.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            // Trong trường hợp xảy ra lỗi, ghi log lỗi và trả về false để thông báo rằng cập nhật không thành công.
            Debug.WriteLine(ex);
            return false;
        }
    }

}
