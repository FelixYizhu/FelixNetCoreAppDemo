using FelixNetCoreAppDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FelixNetCoreAppDemo.Services
{
    public interface IEmployeeService
    {
        Task Add(Employee employee);
        Task<IEnumerable<Employee>> GetByDepartmentId(int id);
        Task<Employee> Fire(int id);
    }
}
