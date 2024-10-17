using JustTip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustTip.Strategy
{
    //Strategy 1 - Proportional Distribution to calculate tips based on worked hours by the employees
    public class ProportionalDistribution : ITipCalcStrategy
    {
        //Implemets logic to calculate tips according to proportional distribution algorithm
        public List<Employee> CalculateTips(List<Employee> employees, decimal totalTips)
        {
            decimal totalHoursWorked = employees.Sum(e => e.EmployeeTotalHoursWorked());

            foreach (var employee in employees)
            {
                decimal hoursWorked = employee.EmployeeTotalHoursWorked();
                if (hoursWorked > 0)
                {
                    employee.Tips = (hoursWorked / totalHoursWorked) * totalTips;
                }
                else
                {
                    employee.Tips = 0;
                }
            }
            return employees;
        }
    }
}
