using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STTestTaskProject.Business.Interfaces;
using STTestTaskProject.Migrations;
using STTestTaskProject.Models;
using STTestTaskProject.ViewModels;

namespace STTestTaskProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;

        public PositionController(IPositionService positionService, IMapper mapper)
        {
            _positionService = positionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PositionViewModel>>> GetPositions()
        {
            var positions = await _positionService.GetPositions();
            return _mapper.Map<List<PositionViewModel>>(positions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PositionViewModel>> GetPosition(int id)
        {
            var position = await _positionService.GetPosition(id);

            if (position == null)
            {
                return NotFound();
            }

            return _mapper.Map<PositionViewModel>(position);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosition(PositionViewModel position)
        {
            try
            {
                await _positionService.PutPosition(_mapper.Map<Position>(position));
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<PositionViewModel>> PostPosition(PositionViewModel position)
        {
            if (position != null)
            {
                await _positionService.PostPosition(_mapper.Map<Position>(position));
            }

            return CreatedAtAction("GetPosition", new {id = position.Id}, position);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosition(int id)
        {
            var position = await _positionService.DeletePosition(id);
            if (position == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}