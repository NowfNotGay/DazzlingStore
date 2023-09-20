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

    /// <summary>
    /// Thêm một đối tượng Role vào cơ sở dữ liệu.
    /// </summary>
    /// <param name="entity">Đối tượng Role cần thêm.</param>
    /// <returns>Trả về true nếu thêm thành công, ngược lại trả về false.</returns>
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


    /// <summary>
    /// Xóa một đối tượng Role khỏi cơ sở dữ liệu nếu được phép.
    /// </summary>
    /// <param name="entity">Đối tượng Role cần xóa.</param>
    /// <returns>Trả về true nếu xóa thành công hoặc nếu không cần xóa, ngược lại trả về false.</returns>
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

    /// <summary>
    /// Lấy tất cả các đối tượng Role từ cơ sở dữ liệu.
    /// </summary>
    /// <returns>Danh sách các đối tượng Role.</returns>
    public IEnumerable<Role> GetAll() => _databaseContext.Roles;


    /// <summary>
    /// Lấy toàn bộ danh sách các Role từ cơ sở dữ liệu bất đồng bộ.
    /// </summary>
    /// <returns>Chuỗi danh sách các Role.</returns>
    public async Task<IEnumerable<Role>> GetAllAsync() => await _databaseContext.Roles.ToListAsync();




    /// <summary>
    /// Lấy một đối tượng Role từ cơ sở dữ liệu dựa trên ID.
    /// </summary>
    /// <param name="id">ID của đối tượng Role cần lấy.</param>
    /// <returns>Đối tượng Role tương ứng với ID hoặc null nếu không tìm thấy.</returns>
    public Role GetById(int id) => _databaseContext.Roles.Find(id)!;



    /// <summary>
    /// Cập nhật thông tin một đối tượng Role trong cơ sở dữ liệu.
    /// </summary>
    /// <param name="entity">Đối tượng Role cần cập nhật.</param>
    /// <returns>Trả về true nếu cập nhật thành công, ngược lại trả về false.</returns>
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
