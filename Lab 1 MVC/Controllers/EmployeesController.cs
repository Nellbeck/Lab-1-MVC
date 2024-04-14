using Lab_1_MVC.Data;
using Lab_1_MVC.Data.Migrations;
using Lab_1_MVC.Models;
using Lab_1_MVC.Models.EmployeeEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab_1_MVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel viewModel) 
        {
            var employee = new Employee
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
            };

            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Employees");
        }

        [HttpGet]
        public async Task<IActionResult> List() 
        {
            var employee = await dbContext.Employees.ToListAsync();
            return View(employee);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id) 
        {
            var employee = await dbContext.Employees.FindAsync(id);

            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee viewModel)
        {
            var employee = await dbContext.Employees.FindAsync(viewModel.Id);

            if (employee is not null)
            {
                employee.Name = viewModel.Name;
                employee.Email = viewModel.Email;
                employee.Phone = viewModel.Phone;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Employees");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Employee viewModel) 
        {
            var employee = await dbContext.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (employee is not null) 
            {
                dbContext.Employees.Remove(viewModel);
                
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Employees");
        }
    }
}
