using JustTip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustTip.Strategy
{
    //Interface to create Tip Calculation Strategy
    public interface ITipCalcStrategy
    {
        List<Employee> CalculateTips(List<Employee> employees, decimal totalTips);   // Place holder Method - no logic
    }
}
