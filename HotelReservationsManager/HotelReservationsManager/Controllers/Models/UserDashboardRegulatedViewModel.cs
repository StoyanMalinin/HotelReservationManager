using System;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationsManager.Controllers.Models
{
    public class UserDashboardRegulatedViewModel
    {

        public int id { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "username cannot be longer than 30 characters")]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string thirdName { get; set; }
        [Required]
        public string EGN { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        public DateTime recruitmentDate { get; set; }
        public bool isActive { get; set; }
        public DateTime dismisalDate { get; set; }
        public bool isAdmin { get; set; }
        

        public UserDashboardRegulatedViewModel() 
        {
            this.isActive = true;
        }
        public UserDashboardRegulatedViewModel(User u) : this()
        {
            id = u.id;
            username = u.username;
            password = u.password;
            isAdmin = u.isAdmin;
            EGN = u.EGN;
            isActive = u.isActive;
        }
    }
}