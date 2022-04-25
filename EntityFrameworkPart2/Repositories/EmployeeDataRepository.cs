using System;
using System.Collections.Generic;
using System.Linq;
using EntityFrameworkPart2.Models;
using EntityFrameworkPart2.Data;

namespace EntityFrameworkPart2.Repositories
{
    public class EmployeeDataRepository
    {
        private static RecruitmentContext Context { get; set; }
        private static EmployeeDataRepository INSTANCE { get; set; }
        private EmployeeDataRepository(RecruitmentContext context)
        {
            Context = context;
        }

        public static EmployeeDataRepository Instance(RecruitmentContext context)
        {
            if( INSTANCE == null)
            {
                INSTANCE = new EmployeeDataRepository(context);
            }
            return INSTANCE;
        }

        public Employee GetEmployeeByCode(string employeeCode)
        {
            var employee = Context.Employees
                .Where(e => e.CEmployeeCode.Equals(employeeCode))
                .FirstOrDefault();
            if(employee == null)
            {
                throw new Exception("Employee Not found");
            }
            return employee;
        }
        public void GetEmployeeData(string employeeCode)
        {            
            var employee = Context.Employees
            .Join(Context.Positions,
            e => e.CCurrentPosition,
            p => p.CPositionCode,
            (e, p) => new
            {
                EmployeeCode = e.CEmployeeCode,
                EmployeeFirstName = e.VFirstName,
                EmployeeLastName = e.VLastName,
                EmployeePosition = p.VDescription
            })
            .Where(e => e.EmployeeCode.Equals(employeeCode))
            .FirstOrDefault();

            if (employee is object)
            {
                Console.WriteLine($"employee code: {employee.EmployeeCode}");
                Console.WriteLine($"employee name: {employee.EmployeeFirstName} {employee.EmployeeLastName}");
                Console.WriteLine($"position: {employee.EmployeePosition}");

            }
            else
            {
                Console.WriteLine("employee not found");
            }
        }
        public void GetMonthlySalary(string employeeCode)
        {
            var monthlySalaries = Context.MonthlySalaries
                .Select(e => e)
                .Where(e => e.CEmployeeCode.Equals(employeeCode))
                .ToList();

            Console.WriteLine("\nMonthly Salary\n");
            foreach (var salary in monthlySalaries)
            {
                Console.WriteLine(salary.MMonthlySalary);
            }
        }
        public void GetAnnualSalary(string employeeCode)
        {
            var annualSalaries = Context.AnnualSalaries
                .Select(e => e)
                .Where(e => e.CEmployeeCode.Equals(employeeCode))
                .ToList();

            Console.WriteLine("\nAnnual Salary\n");
            foreach (var salary in annualSalaries)
            {
                Console.WriteLine(salary.MAnnualSalary);
            }
        }
        public void GetEmployeeSkills(string employeeCode)
        {
            var skills = Context.EmployeeSkills
                .Join(Context.Skills,
                es => es.CSkillCode,
                s => s.CSkillCode,
                (es, s) => new
                {
                    EmployeeCode = es.CEmployeeCode,
                    SkillCode = es.CSkillCode,
                    Skill = s.VSkill
                })
                .Where(e => e.EmployeeCode.Equals(employeeCode))
                .ToList();

            Console.WriteLine("\nSkills\n");
            foreach (var skill in skills)
            {
                Console.WriteLine(skill.Skill);
            }
        }
    }
}
