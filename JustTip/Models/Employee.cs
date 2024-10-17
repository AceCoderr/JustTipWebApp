using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustTip.Models
{
    public class Employee
    {
        [Required]
        public string? EmployeeName { get; set; }

        List<Shift> shifts = new List<Shift>();
        public  decimal Tips { get; set; }

        public void setEmployeeName(string? _employeeName)
        {
            this.EmployeeName = _employeeName;
        }
        public string getEmployeeName()
        {
            return EmployeeName;
        }
        public void AssignShiftToEmployee(Shift shift)
        {
            shifts.Add(shift);
        }

        public decimal EmployeeTotalHoursWorked()
        {
            return shifts.Sum(s => s.ShiftDurationInHours());
        }
    }
}
