using Lab_1_MVC.Data;
using Lab_1_MVC.Models.EmployeeEntities;
using Lab_1_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using String = System.String;

namespace Lab_1_MVC.Controllers
{
    public class AbsenceController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public AbsenceController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Absence viewModel, Employee userId)
        {
            var employee = await dbContext.Employees.FindAsync(userId.Id);
            var absence = new Absence
            {
                Name = employee.Name,
                Date = DateTime.Now,
                DateStart = viewModel.DateStart.Date,
                DateEnd = viewModel.DateEnd.Date,
                Reason = viewModel.Reason,
                Comment = viewModel.Comment,
                TotalDays = (viewModel.DateEnd - viewModel.DateStart.AddDays(-1)).TotalDays,
            };

            await dbContext.Absences.AddAsync(absence);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Employees");
        }
        [HttpGet]
        public async Task<IActionResult> ListOfAll()
        {
            var absence = await dbContext.Absences.ToListAsync();
            return View(absence);
        }
        public async Task<IActionResult> List(string Search_Data, DateTime? start, DateTime? end)
        {
            
            var absences = dbContext.Absences.Where(s => s.Name.Contains(Search_Data) || Search_Data == null).Where(t => t.DateStart >= start || start == null).Where(t => t.DateEnd <= end || end == null).ToList();
            
            return View(absences);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var absence = await dbContext.Absences.FindAsync(id);

            return View(absence);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Absence viewModel)
        {
            var absence = await dbContext.Absences.FindAsync(viewModel.Id);

            if (absence is not null)
            {
                absence.Reason = viewModel.Reason;
                absence.Comment = viewModel.Comment;
                absence.DateStart = viewModel.DateStart;
                absence.DateEnd = viewModel.DateEnd;
                absence.Date = DateTime.Now;
                absence.TotalDays = (viewModel.DateEnd - viewModel.DateStart.AddDays(-1)).TotalDays;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Absence");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Absence viewModel)
        {
            var absence = await dbContext.Absences.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (absence is not null)
            {
                dbContext.Absences.Remove(viewModel);

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Absence");
        }
    }
}
