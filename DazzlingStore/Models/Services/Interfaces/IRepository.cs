namespace DazzlingStore.Models.Services.Interfaces;

public interface IRepository <T>
{
    // Lấy một đối tượng theo ID
    T GetById(int id);

    // Lấy tất cả các đối tượng
    IEnumerable<T> GetAll();

    // Thêm một đối tượng vào cơ sở dữ liệu
    void Add(T entity);

    // Cập nhật thông tin của một đối tượng
    void Update(T entity);

    // Xóa một đối tượng khỏi cơ sở dữ liệu
    void Delete(T entity);
}
