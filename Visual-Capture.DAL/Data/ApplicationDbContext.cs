using Microsoft.EntityFrameworkCore;
using Visual_Capture.Contracts.DTO;

namespace Visual_Capture.DAL.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReservationPhotographerDTO>()
            .HasKey(bc => new {ReservationsId = bc.ReservationId, bc.PhotographerId });  
        modelBuilder.Entity<ReservationPhotographerDTO>()
            .HasOne(bc => bc.Reservation)
            .WithMany(c => c.reservationPhotographer)
            .HasForeignKey(bc => bc.ReservationId);
        modelBuilder.Entity<ReservationPhotographerDTO>()
            .HasOne(bc => bc.Photographer)
            .WithMany(b => b.reservationPhotographer)
            .HasForeignKey(bc => bc.PhotographerId);
    }
    
    public DbSet<CategoryDTO> Categories { get; set; }
    public DbSet<CustomerDTO> Customers { get; set; }
    public DbSet<ReservationDTO> Reservations { get; set; }
    public DbSet<PhotographerDTO> Photographers { get; set; }
    public DbSet<TypeReservationDTO> TypeReservations { get; set; }
    public DbSet<ReservationPhotographerDTO> ReservationPhotographer { get; set; }
}