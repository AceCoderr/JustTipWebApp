using JustTip.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace JustTip.Models
{
    public class Business
    {
        private List<Employee> employees = new List<Employee>();
        private List<Roster> rosters = new List<Roster>();
        public ITipCalcStrategy tipCalcStrategy;

        private decimal TotalTips = 0;

        public void seTotalTips(decimal totalTips)
        {
            this.TotalTips = totalTips;
        }
        public Business(ITipCalcStrategy strategy)
        {
            this.tipCalcStrategy = strategy;
        }

        public List<Employee> GetEmployeesList()
        {
            return employees;
        }
        public List<Employee> AddEmployee(string empName)
        {
            Employee newEmployee = new Employee();
            newEmployee.setEmployeeName(empName);
            employees.Add(newEmployee);
            return employees;
        }

        public List<Roster> CreateRoster(string rosName)
        {
            Roster newRoster = new Roster();
            
            newRoster.SetRosterName(rosName);

            rosters.Add(newRoster);
            return rosters;
        }

        public Roster AssignEmployeesToRoster(string rosName,string empName,DateTime start,DateTime end)
        {
            var employee = employees.FirstOrDefault(e => e.getEmployeeName() == empName);
            var roster = rosters.FirstOrDefault(r=>r.GetRosterName() == rosName);
            if (employee != null)
            {
                Shift newShift = new Shift(start,end);

                employee.AssignShiftToEmployee(newShift);
                if(roster != null)
                {
                    roster.AssignEmployeeToRoster(employee);
                    return roster;
                }
                else
                {
                    Console.WriteLine("No Roster found of this name.");
                }
            }
            else
            {
                Console.WriteLine("No Employee found of this name");
            }
            return roster;
        }
        public List<Employee> DistributeTip(string rosName,decimal totalTips)
        {
            TotalTips = totalTips;
            if (employees.Count <= 0)
            {
                throw new InvalidOperationException("No employees to distribute tips to.");
            }
            if (rosters.Count <= 0)
            {
                throw new InvalidOperationException("No Rosters  to distribute tips for.");
            }
            var roster = rosters.FirstOrDefault(r => r.GetRosterName() == rosName);
            List<Employee> RosterEmployees = new List<Employee>();
            if (roster != null)
            {
                RosterEmployees = roster.GetEmployeesList();
            }
            
            return tipCalcStrategy.CalculateTips(RosterEmployees, TotalTips);
        }
        public void ShowTips()
        {
            foreach ( var  employee in employees )
            {
                Console.WriteLine($"{employee.getEmployeeName()} : {employee.Tips}");
            }
        }
    }
}
