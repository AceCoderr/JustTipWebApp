using Microsoft.AspNetCore.Mvc;
using JustTip.Models;
using JustTip.Strategy;

public class MainController : Controller
{
    //private readonly MainController _controller;

    //public EmployeeController(TipDistributionController controller)
    //{
    //    _controller = controller;
    //}

    private Business _business;
    //private ITipCalcStrategy _tipCalcStrategy = new ProportionalDistribution();

    public MainController(ITipCalcStrategy tipCalcStrategy)
    {
        //this._tipCalcStrategy = tipCalcStrategy;
        _business = new Business(new ProportionalDistribution());
    }

    // Show the form for adding employees
    public IActionResult Index()
    {
        return View();
    }

    // Add a new employee
    [HttpPost]
    public IActionResult Index(Employee employee)
    {
        if (ModelState.IsValid)
        {
            _business.AddEmployee(employee.EmployeeName);
        }
       // _controller.AddEmployee(name);
        return View();
    }

    //// Show the form for assigning shifts
    //public IActionResult AssignShift()
    //{
    //    return View(_controller.GetEmployees());
    //}

    //[HttpPost]
    //public IActionResult AssignShift(string name, DateTime startTime, DateTime endTime)
    //{
    //    _controller.AssignShift(name, startTime, endTime);
    //    return RedirectToAction("AssignShift");
    //}

    // Show the form to input total tips and distribute them
    public IActionResult DistributeTips()
    {
        return View();
    }

    [HttpPost]
    public IActionResult DistributeTips(Roster roster)
    {
        if (!ModelState.IsValid)
        {
            _business.DistributeTip(roster.GetRosterName(),roster.getTotalTipGathered());
            return RedirectToAction("ShowTips");
        }
        return View();
        
    }

    //// Show the tip distribution results
    //public IActionResult ShowTips()
    //{
    //    return View(_controller.GetEmployees());
    //}
}

