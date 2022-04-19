using Visual_Capture.DAL.DTO;
using Visual_Capture.DAL.Types.Interfaces;

namespace Visual_Capture.DAL.Data;

public class CategoryDal : IDal<CategoryDTO>
{
    private readonly ApplicationDbContext _db;

    public CategoryDal(ApplicationDbContext db)
    {
        _db = db;
    }

    
    //Get
    public List<CategoryDTO> Get()
    {
        return _db.Categories.ToList();
    }

    //Create
    public void Create(CategoryDTO obj)
    {
        _db.Categories.Add(obj);
        _db.SaveChanges();
    }

    //Edit

    //get edit/id data
    public object Edit(Guid? id)
    {
        return _db.Categories.Find(id)!;
    }

    //save changes (update item)
    public void Edit(CategoryDTO obj)
    {
        _db.Categories.Update(obj);
        _db.SaveChanges();
    }

    //Delete

    //get delete/id data
    public object Delete(Guid? id)
    {
        var categoryFromDb = _db.Categories.Find(id);

        //just in case someone deleted at the same time.
        if (categoryFromDb == null)
        {
            return null;
        }

        //actually remove from the database
        _db.Categories.Remove(categoryFromDb);
        _db.SaveChanges();

        return categoryFromDb;
    }
}