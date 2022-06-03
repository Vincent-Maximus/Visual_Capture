using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts;
using Visual_Capture.Contracts.Interfaces;

namespace Visual_Capture.DAL.Data;

public class ReservationManagerDal : IManagerDal<ReservationDTO>, IDal<ReservationDTO>
{
    private readonly ApplicationDbContext _db;

    public ReservationManagerDal(ApplicationDbContext db)
    {
        _db = db;
    }

    public ReservationDTO Get(Guid? id)
    {
        return _db.Reservations.Find(id);
    }
    
    //Get
    public List<ReservationDTO> GetAll()
    {
        return _db.Reservations.ToList();
    }

    //Create
    public bool Create(ReservationDTO obj)
    {
        _db.Reservations.Add(obj);
        _db.SaveChanges();
        
        return true;
    }

    //get edit/id data
    public object Edit(Guid? id)
    {
        return _db.Reservations.Find(id)!;
    }

    //save changes (update item)
    public bool Edit(ReservationDTO obj)
    {
        _db.Reservations.Update(obj);
        _db.SaveChanges();
        
        return true;
    }

    //Delete

    //get delete/id data
    public bool Delete(Guid? id)
    {
        var ReservationFromDb = _db.Reservations.Find(id);

        //just in case someone deleted at the same time.
        if (ReservationFromDb == null)
        {
            return false;
        }

        //actually remove from the database
        _db.Reservations.Remove(ReservationFromDb);
        _db.SaveChanges();

        return true;
    }
}