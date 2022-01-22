using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IMapper _mapper;

        public StaffController(IStaffService staffService, IMapper mapper)
        {
            _staffService = staffService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<StaffViewModel>>> GetStaffs()
        {
            var staffs = await _staffService.GetStaffs();
            return _mapper.Map<List<StaffViewModel>>(staffs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StaffViewModel>> GetStaff(int id)
        {
            var staff = await _staffService.GetStaff(id);

            if (staff == null)
            {
                return NotFound();
            }

            return _mapper.Map<StaffViewModel>(staff);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(StaffViewModel staff)
        {
            try
            {
                await _staffService.PutStaff(_mapper.Map<Staff>(staff));
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<StaffViewModel>> PostStaff(StaffViewModel staff)
        {
            if (staff != null)
            {
                await _staffService.PostStaff(_mapper.Map<Staff>(staff));
            }

            return CreatedAtAction("GetStaff", new {id = staff.Id}, staff);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var staff = await _staffService.DeleteStaff(id);
            if (staff == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}