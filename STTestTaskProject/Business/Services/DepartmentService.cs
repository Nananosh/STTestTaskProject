using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using STTestTaskProject.Business.Interfaces;
using STTestTaskProject.Migrations;
using STTestTaskProject.Models;

namespace STTestTaskProject.Business.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationContext _db;

        public DepartmentService(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<List<Department>> GetDepartments()
        {
            var departments = await _db.Departments.ToListAsync();
            return departments;
        }

        public async Task<Department> GetDepartment(int id)
        {
            var department = await _db.Departments.FirstOrDefaultAsync(x => x.Id == id);
            return department;
        }

        public async Task<int> PutDepartment(Department department)
        {
            department.LastEditDate = DateTime.Now;
            _db.Entry(department).State = EntityState.Modified;
            var result = await _db.SaveChangesAsync();
            return result;
        }

        public async Task PostDepartment(Department department)
        {
            department.CreationDate = DateTime.Now;
            department.LastEditDate = DateTime.Now;
            _db.Departments.Add(department);
            await _db.SaveChangesAsync();
        }

        public async Task<Department> DeleteDepartment(int id)
        {
            var department = await _db.Departments.FindAsync(id);
            _db.Departments.Remove(department);
            await _db.SaveChangesAsync();
            return department;
        }
    }
}