using System.Collections.Generic;
using Newtonsoft.Json;

namespace STTestTaskProject.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string PositionName { get; set; } 
        [JsonIgnore]
        public List<Staff> Staffs { get; set; }
    }
}