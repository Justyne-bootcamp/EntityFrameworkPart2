using System;
using EntityFrameworkPart2.Data;
using EntityFrameworkPart2.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkPart2.Repositories;

namespace EntityFrameworkPart2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConfigurationHelper configuration = ConfigurationHelper.Instance();
            var dbConnection = configuration.GetProperty<string>("DbConnectionString");
            Console.WriteLine(dbConnection);

            using (RecruitmentContext context = new RecruitmentContext(dbConnection))
            {
                string employeeCode = "000001";
                EmployeeData employeeData = new EmployeeData();

                EmployeeDataRepository employeeDataRepository = EmployeeDataRepository.Instance(context);
                try
                {
                    Employee verifiedEmployee = employeeDataRepository.GetEmployeeByCode(employeeCode);
                    employeeDataRepository.GetEmployeeData(verifiedEmployee.CEmployeeCode);
                    employeeDataRepository.GetMonthlySalary(verifiedEmployee.CEmployeeCode);
                    employeeDataRepository.GetAnnualSalary(verifiedEmployee.CEmployeeCode);
                    employeeDataRepository.GetEmployeeSkills(verifiedEmployee.CEmployeeCode);
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
