using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts;
using Visual_Capture.Contracts.Interfaces;

namespace Visual_Capture.DAL.Data;

public class PhotographerManagerDal : IManagerDal<PhotographerDTO> 
{
    private readonly ApplicationDbContext _db;

    public PhotographerManagerDal(ApplicationDbContext db)
    {
        _db = db;
    }

    public PhotographerDTO Get(Guid? id)
    {
        return _db.Photographers.Find(id);
    }
    
    //Get
    public List<PhotographerDTO> GetAll()
    {
        return _db.Photographers.ToList();
    }

    //Create
    public bool Create(PhotographerDTO obj)
    {
        _db.Photographers.Add(obj);
        _db.SaveChanges();
        
        return true;
    }


    //get edit/id data
    public object Update(Guid? id)
    {
        return _db.Photographers.Find(id)!;
    }

    //save changes (update item)
    public bool Edit(PhotographerDTO obj)
    {
        _db.Photographers.Update(obj);
        _db.SaveChanges();
        
        return true;
    }

    //Delete

    //get delete/id data
    public bool Delete(Guid? id)
    {
        var photographerFromDb = _db.Photographers.Find(id);

        //just in case someone deleted at the same time.
        if (photographerFromDb == null)
        {
            return false;
        }

        //actually remove from the database
        _db.Photographers.Remove(photographerFromDb);
        _db.SaveChanges();

        return true;
    }
}