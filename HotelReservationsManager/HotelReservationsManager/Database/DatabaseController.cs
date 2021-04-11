using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace HotelReservationsManager
{
    class DatabaseController
    {
        private HotelDb context;

        public DatabaseController() { }
        public DatabaseController(HotelDb context)
        {
            this.context = context;
        }

        public List <T>  getAllEntries<T>(Func <T, bool> filter = null) where T: Entity
        {
            if (filter is null) filter = (x => true);
            return context.getTable<T>().Where(filter).ToList();
        }

        public T getFirstEntry<T>(Func<T, bool> filter = null) where T : Entity
        {
            if (filter is null) filter = (x => true);
            return context.getTable<T>().FirstOrDefault(filter);
        }


        public int addEntry<T>(T item) where T: Entity
        {
            context.getTable<T>().Add(item);
            context.SaveChanges();

            return item.id;
        }

        public void removeEntry<T>(T item) where T: Entity
        {
            context.getTable<T>().Remove(item);
            context.SaveChanges();
        }

        public void removeEntryById<T>(int id) where T: Entity
        {
            context.getTable<T>().Remove(context.getTable<T>().Find(id));
            context.SaveChanges();
        }

        public void updateEntry<T>(T item) where T: Entity
        {
            T oldVersion = context.getTable<T>().Find(item.id);
            context.Entry(oldVersion).CurrentValues.SetValues(item);

            context.SaveChanges();
        }

        public void resetDb()
        {
            foreach (ReservationClientLinker l in context.linkers.ToList())
                context.linkers.Remove(l);
            foreach (Reservation r in context.reservations.ToList())
                context.reservations.Remove(r);
            foreach (User u in context.users.ToList())
                context.users.Remove(u);
            foreach (Room r in context.rooms.ToList())
                context.rooms.Remove(r);
            foreach (Client c in context.clients.ToList())
                context.clients.Remove(c);
            context.SaveChanges();
            

            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('users', RESEED, 0)");
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('rooms', RESEED, 0)");
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('reservations', RESEED, 0)");
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('clients', RESEED, 0)");
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('linkers', RESEED, 0)");
        }
    }
}