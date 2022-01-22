using System.Collections.Generic;
using System.Threading.Tasks;
using STTestTaskProject.Models;

namespace STTestTaskProject.Business.Interfaces
{
    public interface IPositionService
    {
        public Task<List<Position>> GetPositions();
        public Task<Position> GetPosition(int id);
        public Task<int> PutPosition(Position position);
        public Task PostPosition(Position position);
        public Task<Position> DeletePosition(int id);
    }
}