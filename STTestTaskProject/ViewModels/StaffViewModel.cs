using System;
using STTestTaskProject.Models;

namespace STTestTaskProject.ViewModels
{
    public class StaffViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }
        public DateTime EmploymentDate { get; set; }
        public Position Position { get; set; }
        public int PositionId { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}