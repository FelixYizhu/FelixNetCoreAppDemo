using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FelixNetCoreAppDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public bool Fired { get; set; }
    }

    // Enum for Gender, female is 0, male is 1
    public enum Gender
    {
        female = 0,
        male = 1
    }
}
