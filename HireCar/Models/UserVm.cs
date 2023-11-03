using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HireCar.Models
{
    public class UserVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string ContectNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }       
        public bool IsDeleted { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string UserType { get; set; }
        public string ProfileImage { get; set; }
        public string FileName { get; set; }
       
    }

  


}