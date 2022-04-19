using Microsoft.EntityFrameworkCore;
using Visual_Capture.DAL.DTO;

namespace Visual_Capture.DAL.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<CategoryDTO> Categories { get; set; }
    
    public DbSet<UserDTO> Users { get; set; }
    public DbSet<ReservationDTO> Reservations { get; set; }
    public DbSet<PhotographerDTO> Photographers { get; set; }
    public DbSet<TypeReservationDTO> TypeReservations { get; set; }
}