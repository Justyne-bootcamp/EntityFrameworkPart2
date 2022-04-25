using System;
using System.Collections.Generic;
using System.Linq;
using EntityFrameworkPart2.Data;

namespace EntityFrameworkPart2.Models
{
    public class EmployeeData
    {
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public List<decimal> MonthlySalaries { get; set; }
        public List<decimal> AnnualSalaries { get; set; }
        public List<string> Skills { get; set; }

    }
}
