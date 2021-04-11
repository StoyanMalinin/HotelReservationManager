using HotelReservationsManager.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Shared;

namespace HotelReservationsManager.Controllers
{
    public class DashboardController : Controller
    {
        private DatabaseController ds;
        private const int PageSize = 10;
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(ILogger<DashboardController> logger)
        {
            _logger = logger;
            this.ds = new DatabaseController(new HotelDb());
        }

        public IActionResult ManageUsers(UserDashBoardViewModel model)
        {
            if (HotelReservationsManager.Controllers.HomeController.loggedUser is null) return NotFound();
            if (HotelReservationsManager.Controllers.HomeController.loggedUser.isAdmin==false) return NotFound();

            model.Pager ??= new PagerViewModel();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            if (model.usernameFilter == "") model.usernameFilter = null;
             
            List<User> items = ds.getAllEntries<User>().Skip((model.Pager.CurrentPage - 1) * PageSize)
            .Where(u => model.usernameFilter == null || model.usernameFilter==u.username)    
            .Take(PageSize).Select(b => new User(new UserDashboardRegulatedViewModel(b))).ToList();
            int cnt = items.Count;

            model.Items = items;
            model.Pager.PagesCount = (int)Math.Ceiling(cnt / (double)PageSize);

            return View(model);
        }
        public IActionResult ManageRooms(RoomDashboardViewModel model)
        {
            if (HotelReservationsManager.Controllers.HomeController.loggedUser is null) return NotFound();

            model.Pager ??= new PagerViewModel();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            int? capMinFilter = model.capMinFilter, capMaxFilter = model.capMaxFilter;
            if (model.typeFilter == "") model.typeFilter = null;
            if (model.capMinFilter == null) capMinFilter = -1;
            if (model.capMaxFilter == null) capMaxFilter = int.MaxValue;

            List<Room> items = ds.getAllEntries<Room>().Skip((model.Pager.CurrentPage - 1) * PageSize)
            .Where(r => capMinFilter<=r.capacity && r.capacity<=capMaxFilter)
            .Where(r => ((r.isFree&model.isFreeFilter)==model.isFreeFilter))
            .Where(r => model.typeFilter==null || model.typeFilter==r.type)
            .Take(PageSize).Select(r => new Room(r)).ToList();
            int cnt = items.Count;

            model.Items = items;
            model.Pager.PagesCount = (int)Math.Ceiling(cnt / (double)PageSize);

            return View(model);
        }
        public IActionResult ManageClients(ClientDashboardViewModel model)
        {
            if (HotelReservationsManager.Controllers.HomeController.loggedUser is null) return NotFound();

            model.Pager ??= new PagerViewModel();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            if (model.firstNameFilter == "") model.firstNameFilter = null;
            if (model.lasttNameFilter == "") model.lasttNameFilter = null;

            List<Client> items = ds.getAllEntries<Client>().Skip((model.Pager.CurrentPage - 1) * PageSize)
            .Where(c => model.firstNameFilter==null || model.firstNameFilter==c.firstName)
            .Where(c => model.lasttNameFilter==null || model.lasttNameFilter==c.lastName)
            .Take(PageSize).Select(c => new Client(c)).ToList();
            int cnt = items.Count;

            model.Items = items;
            model.Pager.PagesCount = (int)Math.Ceiling(cnt / (double)PageSize);

            return View(model);
        }
        public IActionResult SeeReservations(ReservationDashboardViewModel model)
        {
            if (HomeController.loggedUser is null) return NotFound();
            //if (HomeController.loggedUser.isAdmin==false) return NotFound();

            model.Pager ??= new PagerViewModel();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            List<Reservation> items = ds.getAllEntries<Reservation>().Skip((model.Pager.CurrentPage - 1) * PageSize)
            .Take(PageSize).Select(r => new Reservation(r)).ToList();
            int cnt = items.Count;

            model.Items = items;
            model.Pager.PagesCount = (int)Math.Ceiling(cnt / (double)PageSize);

            return View(model);
        }

        [HttpGet]
        public IActionResult GetClientReservations(ClientReservationsDashboardViewModel model, int clientId)
        {
            if (HomeController.loggedUser is null) return NotFound();
            //if (HomeController.loggedUser.isAdmin == false) return NotFound();

            model.Pager ??= new PagerViewModel();
            model.client = ds.getFirstEntry<Client>(c => c.id==clientId);
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            int cnt = ds.getAllEntries<User>().Count;

            List<Reservation> items = ds.getAllEntries<Reservation>().Skip((model.Pager.CurrentPage - 1) * PageSize)
            .Where(r => r.clients.Any(c => c.client!=null && c.client.id==clientId)==true)
            .Take(PageSize).Select(r => new Reservation(r)).ToList();

            model.Items = items;
            model.Pager.PagesCount = (int)Math.Ceiling(cnt / (double)PageSize);

            return View(model);
        }

        public IActionResult MakeReservation1()
        {
            if (HomeController.loggedUser is null) return NotFound();

            ReservationDashboardRegulatedViewModel model = new ReservationDashboardRegulatedViewModel();

            model.clients = new ClientDashboardRegulatedViewModel[model.clientsCnt];
            for (int i = 0; i < model.clients.Length; i++) model.clients[i] = new ClientDashboardRegulatedViewModel();

            return View(model);
        }
        public IActionResult CreateUser()
        {
            if (HomeController.loggedUser is null) return NotFound();
            if (HomeController.loggedUser.isAdmin == false) return NotFound();

            UserDashboardRegulatedViewModel model = new UserDashboardRegulatedViewModel();
            return View(model);
        }
        public IActionResult CreateRoom()
        {
            if (HomeController.loggedUser is null) return NotFound();
            if (HomeController.loggedUser.isAdmin == false) return NotFound();

            RoomDashboardRegulatedViewModel model = new RoomDashboardRegulatedViewModel();
            return View(model);
        }
        public IActionResult CreateClient()
        {
            if (HomeController.loggedUser is null) return NotFound();
            //if (HomeController.loggedUser.isAdmin == false) return NotFound();

            ClientDashboardRegulatedViewModel model = new ClientDashboardRegulatedViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUser(UserDashboardRegulatedViewModel model)
        {
            if (HomeController.loggedUser is null) return NotFound();
            if (HomeController.loggedUser.isAdmin == false) return NotFound();

            if (ModelState.IsValid)
            {
                User u = new User(model);
                ds.addEntry(u);

                return Redirect("/Dashboard/ManageUsers");
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateRoom(RoomDashboardRegulatedViewModel model)
        {
            if (HomeController.loggedUser is null) return NotFound();
            if (HomeController.loggedUser.isAdmin == false) return NotFound();

            if (ModelState.IsValid)
            {
                Room r = new Room(model);
                ds.addEntry(r);

                return Redirect("/Dashboard/ManageRooms");
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateClient(ClientDashboardRegulatedViewModel model)
        {
            if (HomeController.loggedUser is null) return NotFound();
            //if (HomeController.loggedUser.isAdmin == false) return NotFound();

            if (ModelState.IsValid)
            {
                Client r = new Client(model);
                ds.addEntry(r);

                return Redirect("/Dashboard/ManageClients");
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MakeReservation2(ReservationDashboardRegulatedViewModel model)
        {
            if (ModelState.IsValid == false) return View(model);
            if (model.roomNumber is null) return View(model);

            model.errorMessage = "";
            Room r = ds.getFirstEntry<Room>(r => r.number == model.roomNumber);

            if (r is null)
            {
                model.errorMessage = "This room does not exist";
                return View(model);
            }
            if (r.isFree == false)
            {
                model.errorMessage = "This room is occupied";
                return View(model);
            }

            r.isFree = false;
            ds.updateEntry(r);

            Client[] clients = new Client[model.clientsCnt];
            for(int i = 0;i<model.clientsCnt;i++)
            {
                clients[i] = new Client(model.clients[i]);
                clients[i].id = 0;
            }

            Reservation res = new Reservation()
            {
                id = 0,
                user = ds.getFirstEntry<User>(u => u.id == HomeController.loggedUser.id),
                room = r,
                dateStart = model.dateStart,
                dateEnd = model.dateEnd,
                allInclusive = model.allInclusive,
                breakfast = model.breakfast,
            };
            res.cost = (model.dateEnd - model.dateStart).TotalDays*(clients.Count(c => c.isAdult == true) * r.priceAdult + clients.Count(c => c.isAdult == false) * r.priceChild 
                       + ((res.breakfast == true) ? 1 : 0) + ((res.allInclusive == true) ? 3 : 0));

            int id = ds.addEntry(res);
            res = ds.getFirstEntry<Reservation>(r => r.id == id);

            foreach (Client c in clients)
            {
                if (res.clients == null) res.clients = new List<ReservationClientLinker>();

                Client dsClient = ds.getFirstEntry<Client>(x => x.firstName == c.firstName && x.lastName==c.lastName);
                if (dsClient == null)
                {
                    id = ds.addEntry(c);
                    dsClient = ds.getFirstEntry<Client>(x => x.id == id);
                }

                id = ds.addEntry(new ReservationClientLinker() { client = dsClient, reservation = res });
                ReservationClientLinker linker = ds.getFirstEntry<ReservationClientLinker>(l => l.id==id);
            }

            return Redirect("/Home/Dashboard");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult deleteUser(int id)
        {
            if (HomeController.loggedUser is null) return NotFound();
            if (HomeController.loggedUser.isAdmin == false) return NotFound();

            List<ReservationClientLinker> linkers = ds.getAllEntries<ReservationClientLinker>().ToList();
            linkers = linkers.Where(l => l.reservation.user.id == id).ToList();

            foreach (ReservationClientLinker l in linkers) ds.removeEntry(l);

            ds.removeEntryById<User>(id);
            return Redirect("/Dashboard/ManageUsers");
        }
        public IActionResult DeleteRoom(int id)
        {
            if (HomeController.loggedUser is null) return NotFound();
            if (HomeController.loggedUser.isAdmin == false) return NotFound();

            ds.removeEntryById<Room>(id);
            return Redirect("/Dashboard/ManageRooms");
        }
        public IActionResult DeleteClient(int id)
        {
            if (HomeController.loggedUser is null) return NotFound();
            //if (HomeController.loggedUser.isAdmin == false) return NotFound();

            List<ReservationClientLinker> linkers = ds.getAllEntries<ReservationClientLinker>().ToList(); 
            linkers = linkers.Where(l => l.client.id == id).ToList();

            foreach (ReservationClientLinker l in linkers) ds.removeEntry(l);
            ds.removeEntryById<Client>(id);

            return Redirect("/Dashboard/ManageClients");
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            if (HomeController.loggedUser is null) return NotFound();
            if (HomeController.loggedUser.isAdmin == false) return NotFound();

            User u = ds.getFirstEntry<User>(u => u.id==id);
            UserDashboardRegulatedViewModel model = new UserDashboardRegulatedViewModel(u);

            return View(model);
        }
        [HttpGet]
        public IActionResult EditRoom(int id)
        {
            if (HomeController.loggedUser is null) return NotFound();
            if (HomeController.loggedUser.isAdmin == false) return NotFound();

            Room r = ds.getFirstEntry<Room>(r => r.id == id);
            RoomDashboardRegulatedViewModel model = new RoomDashboardRegulatedViewModel(r);

            return View(model);
        }
        [HttpGet]
        public IActionResult EditClient(int id)
        {
            if (HomeController.loggedUser is null) return NotFound();
            //if (HomeController.loggedUser.isAdmin == false) return NotFound();

            Client c = ds.getFirstEntry<Client>(c => c.id == id);
            ClientDashboardRegulatedViewModel model = new ClientDashboardRegulatedViewModel(c);

            return View(model);
        }

        public IActionResult EditUser(UserDashboardRegulatedViewModel model)
        {
            if (HomeController.loggedUser is null) return NotFound();
            if (HomeController.loggedUser.isAdmin == false) return NotFound();

            if (ModelState.IsValid)
            {
                User u = new User(model);
                ds.updateEntry(u);

                return Redirect("/Dashboard/ManageUsers");
            }

            return View(model);
        }
        public IActionResult EditRoom(RoomDashboardRegulatedViewModel model)
        {
            if (HomeController.loggedUser is null) return NotFound();
            if (HomeController.loggedUser.isAdmin == false) return NotFound();

            if (ModelState.IsValid)
            {
                Room r = new Room(model);
                ds.updateEntry(r);

                return Redirect("/Dashboard/ManageRooms");
            }

            return View(model);
        }
        public IActionResult EditClient(ClientDashboardRegulatedViewModel model)
        {
            if (HomeController.loggedUser is null) return NotFound();
            //if (HomeController.loggedUser.isAdmin == false) return NotFound();

            if (ModelState.IsValid)
            {
                Client c = new Client(model);
                ds.updateEntry(c);

                return Redirect("/Dashboard/ManageClients");
            }

            return View(model);
        }

        public IActionResult logout()
        {
            HomeController.loggedUser = null;
            return Redirect("/Home");
        }
    }
}
