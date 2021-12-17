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
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }

        public Employee Update(Employee updatedEmployee)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == updatedEmployee.Id);
            if (employee != null)
            {
                employee.Name = updatedEmployee.Name;
                employee.Department = updatedEmployee.Department;
                employee.Email = updatedEmployee.Email;
            }
            return employee;
        }
        public Employee Add(Employee newEmployee)
        {
            newEmployee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(newEmployee);
            return newEmployee;
        }
        public Employee Delete(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employeeList.Remove(employee);
            }
                return employee;
        }

        public IEnumerable<DeptHeadCount> EmployeeCountByDept(Dept? dept)
        {
            IEnumerable<Employee> query = _employeeList;
            if (dept.HasValue) {
                query = query.Where(e => e.Department == dept.Value);
            }
            return query.GroupBy(e => e.Department)
                .Select(g => new DeptHeadCount()
                {
                    Department = g.Key.Value,
                    Count = g.Count()
                }).ToList();
        }

       public IEnumerable<Employee> Search(string searchTerm=null)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return _employeeList;
            }

            return _employeeList.Where(e => e.Name.Contains(searchTerm) ||
                                            e.Email.Contains(searchTerm)).ToList();
        }

    }
}
