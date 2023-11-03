using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HireCar.Models
{
    public class UserResponseVM
    {

        public int id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Contact number is required")]
        public string ContectNumber { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
      
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "User Type is required")]
        public string UserType { get; set; }
        public string ProfileImage { get; set; }
        public string   FileName { get; set; }

    }
}