using Microsoft.EntityFrameworkCore;
using System;

namespace HotelReservationsManager
{
    public class HotelDb : DbContext
    {
        public virtual DbSet<User> users { get; set; }
        public virtual DbSet<Room> rooms { get; set; }
        public virtual DbSet<Client> clients { get; set; }
        public virtual DbSet<Reservation> reservations { get; set; }
        public virtual DbSet<ReservationClientLinker> linkers { get; set; }

        public DbSet<T> getTable<T>() where T: Entity
        {
            if (typeof(T) == typeof(User)) return users as DbSet <T>;
            if (typeof(T) == typeof(Room)) return rooms as DbSet <T>;
            if (typeof(T) == typeof(Client)) return clients as DbSet <T>;
            if (typeof(T) == typeof(Reservation)) return reservations as DbSet <T>;
            if (typeof(T) == typeof(ReservationClientLinker)) return linkers as DbSet <T>;
            throw new Exception();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\.; Database = HotelDbv6.0;");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}