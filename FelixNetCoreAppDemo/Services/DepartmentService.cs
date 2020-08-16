using FelixNetCoreAppDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FelixNetCoreAppDemo.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly List<Department> _departments = new List<Department>();

        // Constructor add three records
        public DepartmentService()
        {
            _departments.Add(
                new Department
                {
                    Id = 1,
                    Name = "HR",
                    Location = "Melbourne",
                    EmployeeCount=10
                }) ;
            _departments.Add(
                new Department
                {
                    Id = 2,
                    Name = "R&D",
                    Location = "Geelong",
                    EmployeeCount = 43
                });
            _departments.Add(
                new Department
                {
                    Id =3,
                    Name = "Sales",
                    Location = "Ballarat",
                    EmployeeCount = 68
                });
        }


        public Task<IEnumerable<Department>> GetAll()
        {
            return Task.Run(function:()=> _departments.AsEnumerable());
        }

        public Task<Department> GetById(int id)
        {
            return Task.Run(function: () => _departments.FirstOrDefault(x => x.Id == id));
        }

        public Task<CompanySummary> GetCompanySummary()
        {
            return Task.Run(function: () => {
                return new CompanySummary
                {
                    EmployeeCount = _departments.Sum(x => x.EmployeeCount),
                    AverageDepartmentEmployeeCount = (int)_departments.Average(x => x.EmployeeCount)
                };
            });
        }

        public Task Add(Department department)
        {
            department.Id = _departments.Max(x => x.Id) + 1;
            _departments.Add(department);
            return Task.CompletedTask;
        }
    }
}
