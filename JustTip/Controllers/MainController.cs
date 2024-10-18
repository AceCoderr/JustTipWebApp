using Microsoft.AspNetCore.Mvc;
using JustTip.Models;
using JustTip.Strategy;

public class MainController : Controller
{
    private static Business _business = new Business(new ProportionalDistribution());

    // Show the form for adding employees
    public IActionResult Index()
    {
        var empList = _business.GetEmployeesList();
        return View(empList);
    }
 
    // Add a new employee
    [HttpPost]
    public IActionResult AddEmployee(Employee employee)
    {
        if (ModelState.IsValid)
        {
            _business.AddEmployee(employee.EmployeeName);
        }
       // _controller.AddEmployee(name);
        return RedirectToAction("Index");
    }

    public IActionResult CreateRoster(Roster roster)
    {
        if (ModelState.IsValid)
        {
            _business.CreateRoster(roster.GetRosterName());
        }
        // _controller.AddEmployee(name);
        return RedirectToAction("Index");
    }

    //// Show the form for assigning shifts
    //public IActionResult AssignShift()
    //{
    //    return View(_business.GetEmployeesList());
    //}

    // Assign a shift to an employee
    [HttpPost]
    public IActionResult AssignShift(string name, DateTime startTime, DateTime endTime)
    {
        var employee = _business.GetEmployeesList().Find(e => e.EmployeeName == name);
        if (employee != null)
        {
            var shift = new Shift(startTime, endTime);
            employee.AssignShiftToEmployee(shift);
        }
        return RedirectToAction("Index");
    }

    //// Show the form to input total tips and distribute them
    //public IActionResult DistributeTips()
    //{
    //    return View();
    //}

    //[HttpPost]
    //public IActionResult DistributeTips(Roster roster)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        _business.DistributeTip(roster.GetRosterName(),roster.getTotalTipGathered());
    //        return RedirectToAction("ShowTips");
    //    }
    //    return View();
        
    //}

    //// Show the tip distribution results
    //public IActionResult ShowTips()
    //{
    //    return View(_controller.GetEmployees());
    //}
}

