using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace STTestTaskProject.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }
        [JsonIgnore]
        public List<Staff> Staffs { get; set; }
    }
}