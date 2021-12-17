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
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository employeeRepository;

        public EditModel(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public Employee Employee { get; private set; }

        [BindProperty]
        public bool Notify { get; set; }

        [BindProperty]
        public string Message { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Employee = employeeRepository.GetEmployee(id.Value);
            }
            else
            {
                Employee = new Employee();
            }

            if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
        public IActionResult OnPost(Employee employee)
        {
            if (employee.Id > 0)
            {
                Employee = employeeRepository.Update(employee);
            }
            else
            {
                Employee = employeeRepository.Add(employee);
            }
            return RedirectToPage("Index");
        }

        public IActionResult OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
            {
                Message = "Thank you for turning on notifications";
            }
            else
            {
                Message = "You have turned off email notifications";
            }
            TempData["message"] = Message;
            return RedirectToPage("Details", new { id = id });
        }
    }
}
