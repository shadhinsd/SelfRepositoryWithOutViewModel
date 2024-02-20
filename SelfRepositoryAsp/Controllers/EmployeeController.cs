using Microsoft.AspNetCore.Mvc;
using SelfRepositoryAsp.Models;
using SelfRepositoryAsp.repositoryService;

namespace SelfRepositoryAsp.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeRepository employee;

    public EmployeeController(IEmployeeRepository employee)
    {
        this.employee = employee;
    }
    public async Task<ActionResult<Employee>> Index()
    {
        return View(await employee.GetAllAsync());
    }
    public async Task<ActionResult<Employee>> Create(long id)
    {
        if (id == 0) { return View(new Employee()); }
        else
        {
            var data = await employee.GetByIdAsync(id);
            return View(data);
        }     
    }
    [HttpPost]
    public async Task<ActionResult<Employee>> Create(long id, Employee emp)
    {
        if (id == 0)
        {
            if (ModelState.IsValid)
            {
                var data = await employee.InsertAsync(emp);
                return RedirectToAction("Index");
            }
        }
        else
        {
            var data = await employee.UpdateAsync(id, emp);
            return RedirectToAction("Index");
        }
        return View(new Employee());
    }
    public async Task<ActionResult<Employee>> Delete(long id)
    {
        if (id == 0) { return RedirectToAction("Index"); }
        else
        {
            var data = await employee.DeleteByIdAsync(id);
            return RedirectToAction($"{nameof(Index)}");
        }
    }
    public async Task<ActionResult<Employee>> Details(long id)
    {
        if (id == 0) { return RedirectToAction("Index"); }
        else
        {
            var data=await employee.GetByIdAsync(id);
            return View(data);
        }

    }
 }
