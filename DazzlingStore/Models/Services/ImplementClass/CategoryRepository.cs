using DazzlingStore.Models.Services.Interfaces;
using System.Diagnostics;

namespace DazzlingStore.Models.Services.ImplementClass;

public class CategoryRepository : IRepository<Category>
{
/*    private List<Category> list = new List<Category>();*/

    private readonly DatabaseContext _databaseContext;

    public CategoryRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public bool Add(Category entity)
    {
        try
        {
            _databaseContext.Categories.Add(entity);

            return _databaseContext.SaveChanges() > 0;
        }
        catch (Exception ex)
        { 
            Debug.WriteLine(ex);
            return false;
        }
    }

    public bool Delete(Category entity)
    {
        try
        {

            if (entity.IsDeleted == true)
            {
                _databaseContext.Categories.Remove(entity);
            }

            return _databaseContext.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public IEnumerable<Category> GetAll() => _databaseContext.Categories;

    public Category GetById(int id) => _databaseContext.Categories.Find(id)!;

    public bool Update(Category entity)
    {
        try
        {
            _databaseContext.Categories.Update(entity);

            return _databaseContext.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

/*    private List<Category> Recursive(List<Category> caetegory, int parent = 0, string level = "")
    {

        foreach (var cate in caetegory)
        {
*//*            if (cate.Id == id)
            {
                continue;
            }*//*

            if (cate.ParentId == parent)
            {
                cate.Name = level + cate.Name;
                list.Add(cate);
                return Recursive(caetegory, parent : cate.ParentId, level += "--|");
            }
        }

        return list;
    }*/
}
