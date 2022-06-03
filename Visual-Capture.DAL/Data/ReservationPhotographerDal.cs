using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts;
using Visual_Capture.Contracts.Interfaces;

namespace Visual_Capture.DAL.Data;

public class ReservationPhotographerDAL : IManagerDal<ReservationPhotographerDTO> 
{
    private readonly ApplicationDbContext _db;

    public ReservationPhotographerDAL(ApplicationDbContext db)
    {
        _db = db;
    }

    public ReservationPhotographerDTO Get(Guid? id)
    {
        return _db.ReservationPhotographer.Find(id);
    }
    
    //Get
    public List<ReservationPhotographerDTO> GetAll()
    {
        return _db.ReservationPhotographer.ToList();
    }

    //Create
    public bool Create(ReservationPhotographerDTO obj)
    {
        _db.ReservationPhotographer.Add(obj);
        _db.SaveChanges();
        
        return true;
    }


    //get edit/id data
    public object Update(Guid? id)
    {
        return _db.ReservationPhotographer.Find(id)!;
    }

    //save changes (update item)
    public bool Edit(ReservationPhotographerDTO obj)
    {
        _db.ReservationPhotographer.Update(obj);
        _db.SaveChanges();
        
        return true;
    }

    //Delete

    //get delete/id data
    public bool Delete(Guid? id)
    {
        var reservationphotographerFromDb = _db.ReservationPhotographer.Find(id);

        //just in case someone deleted at the same time.
        if (reservationphotographerFromDb == null)
        {
            return false;
        }

        //actually remove from the database
        _db.ReservationPhotographer.Remove(reservationphotographerFromDb);
        _db.SaveChanges();

        return true;
    }
}