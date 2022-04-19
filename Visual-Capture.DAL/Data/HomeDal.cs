using Microsoft.EntityFrameworkCore;
using Visual_Capture.DAL.DTO;
using Visual_Capture.DAL.Types.Interfaces;
using Visual_Capture.DAL.Data;

namespace Visual_Capture.DAL.Data;

public class HomeDal
{
    private readonly ApplicationDbContext _db;

    public HomeDal(ApplicationDbContext db)
    {
        _db = db;
    }

    
    #region Reservation

    //get
    public List<ReservationDTO> GetReservations()
    {
        return _db.Reservations
            .Include(x => x.TypeReservation)
            .Include( x => x.Photographer).ToList();
    }

    //create
    public void Create(ReservationDTO obj)
    {
        _db.Reservations.Update(obj);
        _db.SaveChanges();
    }

    #endregion
    
    
    
      
    #region TypeReservation

    //get
    public List<TypeReservationDTO> GetTypeReservations()
    {
        return _db.TypeReservations.ToList();
    }
    
    
    #endregion
}