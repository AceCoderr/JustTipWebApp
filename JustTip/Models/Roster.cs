using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustTip.Models
{
    public class Roster
    {
        
        private string rosterName {  get; set; }

        private List<Employee> employees = new List<Employee>();

        private decimal totalHoursWorked {  get; set; }

        private decimal totalTipGathered {  get; set; }

        #region Getter Setter Methods
        public void setTotalTipGathered(decimal _totalTipGathered)
        {
            this.totalTipGathered = _totalTipGathered;
        }
        public decimal getTotalTipGathered()
        {
            return this.totalTipGathered;
        }
        public List<Employee> GetEmployeesList()
        {
            return employees;
        }
        public string GetRosterName()
        {
            return rosterName;
        }
        public void SetRosterName(string name)
        {
             this.rosterName = name;
        }

        #endregion


        public void AssignEmployeeToRoster(Employee emp)
        {
            employees.Add(emp);
        }

        //Total hours worked by the employees in a particular roster.
        public decimal CalculateTotalHoursWorked()
        {
            foreach (Employee emp in employees)
            {
               totalHoursWorked +=  emp.EmployeeTotalHoursWorked();
            }
            return totalHoursWorked;
        }
    }
}
