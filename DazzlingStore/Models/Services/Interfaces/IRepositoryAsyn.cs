namespace DazzlingStore.Models.Services.Interfaces;

public interface IRepositoryAsyn<T>
{
    // Lấy một đối tượng theo ID
    Task<T> GetByIdAsync(int id);

    // Lấy tất cả các đối tượng
    Task<IEnumerable<T>> GetAllAsync();

    // Thêm một đối tượng vào cơ sở dữ liệu
    Task<bool> AddAsync(T entity);

    // Cập nhật thông tin của một đối tượng
    Task<bool> UpdateAsync(T entity);

    // Xóa một đối tượng khỏi cơ sở dữ liệu
    Task<bool> DeleteAsync(T entity);
}
