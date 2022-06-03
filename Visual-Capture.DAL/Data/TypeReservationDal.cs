using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts;
using Visual_Capture.Contracts.Interfaces;

namespace Visual_Capture.DAL.Data;

public class TypeReservationManagerDal : IManagerDal<TypeReservationDTO> 
{
    private readonly ApplicationDbContext _db;

    public TypeReservationManagerDal(ApplicationDbContext db)
    {
        _db = db;
    }

    public TypeReservationDTO Get(Guid? id)
    {
        return _db.TypeReservations.Find(id);
    }
    
    //Get
    public List<TypeReservationDTO> GetAll()
    {
        return _db.TypeReservations.ToList();
    }

    //Create
    public bool Create(TypeReservationDTO obj)
    {
        _db.TypeReservations.Add(obj);
        _db.SaveChanges();
        
        return true;
    }


    //get edit/id data
    public object Update(Guid? id)
    {
        return _db.TypeReservations.Find(id)!;
    }

    //save changes (update item)
    public bool Edit(TypeReservationDTO obj)
    {
        _db.TypeReservations.Update(obj);
        _db.SaveChanges();
        
        return true;
    }

    //Delete

    //get delete/id data
    public bool Delete(Guid? id)
    {
        var typeReservationFromDb = _db.TypeReservations.Find(id);

        //just in case someone deleted at the same time.
        if (typeReservationFromDb == null)
        {
            return false;
        }

        //actually remove from the database
        _db.TypeReservations.Remove(typeReservationFromDb);
        _db.SaveChanges();

        return true;
    }
}