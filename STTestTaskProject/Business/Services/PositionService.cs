using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using STTestTaskProject.Business.Interfaces;
using STTestTaskProject.Migrations;
using STTestTaskProject.Models;

namespace STTestTaskProject.Business.Services
{
    public class PositionService : IPositionService
    {
        private readonly ApplicationContext _db;

        public PositionService(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<List<Position>> GetPositions()
        {
            var positions = await _db.Positions.ToListAsync();
            return positions;
        }

        public async Task<Position> GetPosition(int id)
        {
            var position = await _db.Positions.FirstOrDefaultAsync(x => x.Id == id);
            return position;
        }

        public async Task<int> PutPosition(Position position)
        {
            _db.Entry(position).State = EntityState.Modified;
            var result = await _db.SaveChangesAsync();
            return result;
        }

        public async Task PostPosition(Position position)
        {
            _db.Positions.Add(position);
            await _db.SaveChangesAsync();
        }

        public async Task<Position> DeletePosition(int id)
        {
            var position = await _db.Positions.FindAsync(id);
            _db.Positions.Remove(position);
            await _db.SaveChangesAsync();
            return position;
        }
    }
}