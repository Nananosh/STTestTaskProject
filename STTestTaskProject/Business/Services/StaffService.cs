using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using STTestTaskProject.Business.Interfaces;
using STTestTaskProject.Migrations;
using STTestTaskProject.Models;

namespace STTestTaskProject.Business.Services
{
    public class StaffService : IStaffService
    {
        private readonly ApplicationContext _db;

        public StaffService(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<List<Staff>> GetStaffs()
        {
            var staffs = await _db.Staffs.Include(x => x.Position).Include(x => x.Department).ToListAsync();
            return staffs;
        }

        public async Task<Staff> GetStaff(int id)
        {
            var staff = await _db.Staffs.Include(x => x.Position).Include(x => x.Department)
                .FirstOrDefaultAsync(x => x.Id == id);
            return staff;
        }

        public async Task<int> PutStaff(Staff staff)
        {
            staff.LastEditDate = DateTime.Now;
            _db.Entry(staff).State = EntityState.Modified;
            var result = await _db.SaveChangesAsync();
            return result;
        }

        public async Task PostStaff(Staff staff)
        {
            staff.CreationDate = DateTime.Now;
            staff.LastEditDate = DateTime.Now;
            _db.Staffs.Add(staff);
            await _db.SaveChangesAsync();
        }

        public async Task<Staff> DeleteStaff(int id)
        {
            var staff = await _db.Staffs.FindAsync(id);
            _db.Staffs.Remove(staff);
            await _db.SaveChangesAsync();
            return staff;
        }
    }
}