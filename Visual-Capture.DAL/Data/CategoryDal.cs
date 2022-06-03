using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts;
using Visual_Capture.Contracts.Interfaces;

namespace Visual_Capture.DAL.Data;

public class CategoryManagerDal : IManagerDal<CategoryDTO> 
{
    private readonly ApplicationDbContext _db;

    public CategoryManagerDal(ApplicationDbContext db)
    {
        _db = db;
    }

    public CategoryDTO Get(Guid? id)
    {
        return _db.Categories.Find(id);
    }
    
    //Get
    public List<CategoryDTO> GetAll()
    {
        return _db.Categories.ToList();
    }

    //Create
    public bool Create(CategoryDTO obj)
    {
        _db.Categories.Add(obj);
        _db.SaveChanges();
        
        return true;
    }


    //get edit/id data
    public object Update(Guid? id)
    {
        return _db.Categories.Find(id)!;
    }

    //save changes (update item)
    public bool Edit(CategoryDTO obj)
    {
        _db.Categories.Update(obj);
        _db.SaveChanges();
        
        return true;
    }

    //Delete

    //get delete/id data
    public bool Delete(Guid? id)
    {
        var categoryFromDb = _db.Categories.Find(id);

        //just in case someone deleted at the same time.
        if (categoryFromDb == null)
        {
            return false;
        }

        //actually remove from the database
        _db.Categories.Remove(categoryFromDb);
        _db.SaveChanges();

        return true;
    }
}