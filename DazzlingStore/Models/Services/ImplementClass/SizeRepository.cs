using DazzlingStore.Models.Services.Interfaces;
using System.Diagnostics;

namespace DazzlingStore.Models.Services.ImplementClass;

public class SizeRepository : IRepository<Size>
{
    
    private readonly DatabaseContext _databaseContext;

    public SizeRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public bool Add(Size entity)
    {
        try
        {
            //Thêm đối tượng vào cơ sở dữ liệu.
            _databaseContext.Sizes.Add(entity);

            //Có 2 trường hợp xảy ra : 

            // 1) Lưu thay đổi khi đối tượng được thêm vào thành công sẽ trả về true.
            return _databaseContext.SaveChanges() > 0;

        }
        catch (Exception ex)
        {
            // 2) Trong trường hợp phát hiện ra lỗi và không thêm vào được thì sẽ trả về false. Khởi chạy Ex.
            Debug.WriteLine(ex);
            return false;
        }
    }

    public bool Delete(Size entity)
    {
        try
        {
            //Kiểm tra xem đối tượng được phép xóa hay không.

            if (entity.IsDeleted == true)
            {
                //Nếu true thì được phép xóa.
                _databaseContext.Sizes.Remove(entity);
            }

            //Lưu lại những thay đổi thao tác trên.
            return _databaseContext.SaveChanges() > 0;
        }
        catch(Exception ex) 
        { 

            //Nếu có lỗi thì sẽ trả về false.
            Debug.WriteLine(ex);
            return false;
        }
    }

    //Lấy tất cả dữ liệu của đối tượng
    public IEnumerable<Size> GetAll() => _databaseContext.Sizes;

    //Lấy ra đối tượng có id = với id nhập vào. Find lấy dựa trên khóa chính.
    public Size GetById(int id) => _databaseContext.Sizes.Find(id)!;

    public bool Update(Size entity)
    {
        try
        {
            //Sử dụng Update để nói với Db Set rằng đối tượng này cần được thay đổi
            _databaseContext.Sizes.Update(entity);

            //Nếu thay đổi thành công sẽ trả về true và lưu lại những thay đổi đó.
            return _databaseContext.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            //Nếu false thì báo lỗi.
            Debug.WriteLine(ex);
            return false;
        }
    }
}
