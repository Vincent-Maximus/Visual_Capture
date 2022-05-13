using Microsoft.EntityFrameworkCore;
using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts;
using Visual_Capture.DAL.Data;

namespace Visual_Capture.DAL.Data;

public class ReservationDal 
{
    private readonly ApplicationDbContext _db;

    public ReservationDal(ApplicationDbContext db)
    {
        _db = db;
    }

    //GetOne
    public ReservationDTO Get(Guid? id)
    {
        return _db.Reservations.Find(id);
    }
    
    
    //GetAll
    public List<ReservationDTO> GetAll()
    {
        return _db.Reservations.ToList();
    }

    //Combine Data
    // public List<ReservationDTO> GetReservations()
    // {
    //     return _db.Reservations
    //         .Include(x => x.TypeReservation)
    //         .Include( x => x.Photographer).ToList();
    // }

    //create
    public bool Create(ReservationDTO obj)
    {
        _db.Reservations.Add(obj);
        _db.SaveChanges();
        
        return true;
    }
    
    //get edit/id data
    public object Update(Guid? id)
    {
        return _db.Reservations.Find(id)!;
    }
    
    //save changes (update item)
    public bool Update(ReservationDTO obj)
    {
        _db.Reservations.Update(obj);
        _db.SaveChanges();
        
        return true;
    }
    
    //get delete/id data
    public bool Delete(Guid? id)
    {
        var reservationFromDb = _db.Reservations.Find(id);

        //just in case someone deleted at the same time.
        if (reservationFromDb == null)
        {
            return false;
        }

        //actually remove from the database
        _db.Reservations.Remove(reservationFromDb);
        _db.SaveChanges();

        return true;
    }
    

    #region TypeReservation

    //get
    public List<TypeReservationDTO> GetTypeReservations()
    {
        return _db.TypeReservations.ToList();
    }
    
    
    #endregion
}