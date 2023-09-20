namespace DazzlingStore.Models.Services.Interfaces;

public interface IRepository <T>
{
    // Lấy một đối tượng theo ID
    T GetById(int id);

    // Lấy tất cả các đối tượng
    IEnumerable<T> GetAll();
    Task<IEnumerable<T>> GetAllAsync();

    // Thêm một đối tượng vào cơ sở dữ liệu
    bool Add(T entity);

    // Cập nhật thông tin của một đối tượng
    bool Update(T entity);

    // Xóa một đối tượng khỏi cơ sở dữ liệu
    bool Delete(T entity);
}
