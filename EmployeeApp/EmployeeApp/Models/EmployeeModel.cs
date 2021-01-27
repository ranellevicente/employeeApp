using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EmployeeApp.Models
{

    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public float Tin { get; set; }
        public float Salary { get; set; }
        public float Absences { get; set; }
        public float WorkDays { get; set; }
        public decimal FinalSalary { get; set; }
        public EmploymentType EmployeeType { get; set; }

        public enum EmploymentType
        {
            Regular,
            Contractual
        }
    }

    public class OurDatabase
    {
        List<EmployeeModel> _Employees;
        public List<EmployeeModel> Employees
        {
            get
            {
                _Employees = new List<EmployeeModel>();

                _Employees.AddRange(new[] {

                new EmployeeModel { Id = 1, Name = "Ranelle Vicente", BirthDate = "September 9, 1995", Tin = 12345, EmployeeType = EmployeeModel.EmploymentType.Regular, Salary = 30000, Absences = 1, WorkDays = 0, FinalSalary = 28509 },

                });

                return _Employees;
            }

            set
            {
                _Employees = value;
            }
        }

    }

}