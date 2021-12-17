using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services;

namespace RazorPages.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        public IEnumerable<Employee> employees { get; set; }
        public IndexModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public void OnGet()
        {
            employees = _employeeRepository.Search(SearchTerm);
        }
    }
}
