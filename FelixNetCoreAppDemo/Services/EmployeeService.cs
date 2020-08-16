using FelixNetCoreAppDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FelixNetCoreAppDemo.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees = new List<Employee>();

        // Consstructor create seven records
        public EmployeeService() 
        {
            _employees.Add(new Employee { 
            Id=1,
            DepartmentId=1,
            FirstName="Nick",
            LastName="Paul",
            Gender=Gender.male
            });

            _employees.Add(new Employee
            {
                Id = 2,
                DepartmentId = 1,
                FirstName = "Nick",
                LastName = "Paul",
                Gender = Gender.male
            });

            _employees.Add(new Employee
            {
                Id = 3,
                DepartmentId = 2,
                FirstName = "Sherry",
                LastName = "Wang",
                Gender = Gender.female
            });
            _employees.Add(new Employee
            {
                Id = 4,
                DepartmentId = 2,
                FirstName = "Jack",
                LastName = "Paul",
                Gender = Gender.male
            });
            _employees.Add(new Employee
            {
                Id = 5,
                DepartmentId = 2,
                FirstName = "Mary",
                LastName = "Sue",
                Gender = Gender.female
            });
            _employees.Add(new Employee
            {
                Id = 6,
                DepartmentId = 3,
                FirstName = "Felix",
                LastName = "Wang",
                Gender = Gender.male
            });
            _employees.Add(new Employee
            {
                Id = 7,
                DepartmentId = 3,
                FirstName = "Tim",
                LastName = "James",
                Gender = Gender.male
            });
        }

        public Task Add(Employee employee)
        {
            employee.Id = _employees.Max(x => x.Id) + 1;
            _employees.Add(employee);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId)
        {
            return Task.Run(function: () =>_employees.Where(x => x.DepartmentId == departmentId));
        }

        public Task<Employee> Fire(int id)
        {
            return Task.Run(function: ()=> {
                var employee = _employees.FirstOrDefault(e => e.Id == id);
                if (employee != null)
                {
                    employee.Fired = true;
                    return employee;
                }
                return null;

            });
        }
    }
}
