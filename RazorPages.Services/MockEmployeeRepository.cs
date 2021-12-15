using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPages.Services
{
  public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
         public MockEmployeeRepository()
            {
                _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Sneha", Department = Dept.IT,
                    Email = "sneha@gmail.com", PhotoPath="user3.jfif" },
                new Employee() { Id = 2, Name = "Priya", Department = Dept.HR,
                    Email = "priya@gmail.com", PhotoPath="user2.png" },
                new Employee() { Id = 3, Name = "Riya", Department = Dept.IT,
                    Email = "riya@gmail.com", PhotoPath="user.jfif" },
                new Employee() { Id = 4, Name = "Shreya", Department = Dept.Payroll,
                    Email = "shreya@gmail.com" },
            };
            }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e=>e.Id==id);
        }
    }
}
