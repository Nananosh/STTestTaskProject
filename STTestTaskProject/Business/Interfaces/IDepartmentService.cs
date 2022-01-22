using System.Collections.Generic;
using System.Threading.Tasks;
using STTestTaskProject.Models;

namespace STTestTaskProject.Business.Interfaces
{
    public interface IDepartmentService
    {
        public Task<List<Department>> GetDepartments();
        public Task<Department> GetDepartment(int id);
        public Task<int> PutDepartment(Department department);
        public Task PostDepartment(Department department);
        public Task<Department> DeleteDepartment(int id);
    }
}