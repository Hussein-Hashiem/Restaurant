
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurnat.DAL.Entities;

namespace Restaurnat.DAL.Database
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<ReservedTable> ReservedTables { get; set; }
        public DbSet<ReservedItem> ReservedItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Chef> Chefs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ReservedItem>()
                .HasKey(ri => new { ri.ItemId, ri.ReservationId });

            modelBuilder.Entity<ReservedTable>()
                .HasKey(rt => new { rt.TableId, rt.ReservationId });
            
            modelBuilder.Entity<ReservedTable>()
               .HasOne(rt => rt.Table)
               .WithMany(t => t.ReservedTables)
               .HasForeignKey(rt => rt.TableId)
               .OnDelete(DeleteBehavior.Restrict);
           
            modelBuilder.Entity<ReservedTable>()
                .HasOne(rt => rt.Reservation)
                .WithMany(r => r.ReservedTables)
                .HasForeignKey(rt => rt.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);
           
            modelBuilder.Entity<ReservedItem>()
                            .HasOne(ri => ri.Item)
                            .WithMany(i => i.ReservedItems)
                            .HasForeignKey(ri => ri.ItemId)
                            .OnDelete(DeleteBehavior.Restrict);
           
            modelBuilder.Entity<ReservedItem>()
                .HasOne(ri => ri.Reservation)
                .WithMany(r => r.ReservedItems)
                .HasForeignKey(ri => ri.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}