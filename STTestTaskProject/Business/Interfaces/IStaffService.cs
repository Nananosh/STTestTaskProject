using System.Collections.Generic;
using System.Threading.Tasks;
using STTestTaskProject.Models;

namespace STTestTaskProject.Business.Interfaces
{
    public interface IStaffService
    {
        public Task<List<Staff>> GetStaffs();
        public Task<Staff> GetStaff(int id);
        public Task<int> PutStaff(Staff staff);
        public Task PostStaff(Staff staff);
        public Task<Staff> DeleteStaff(int id);
    }
}