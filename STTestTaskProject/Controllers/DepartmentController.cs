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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;


        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<DepartmentViewModel>>> GetDepartments()
        {
            var departments = await _departmentService.GetDepartments();
            return _mapper.Map<List<DepartmentViewModel>>(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentViewModel>> GetDepartment(int id)
        {
            var department = await _departmentService.GetDepartment(id);

            if (department == null)
            {
                return NotFound();
            }

            return _mapper.Map<DepartmentViewModel>(department);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(DepartmentViewModel department)
        {
            try
            {
                await _departmentService.PutDepartment(_mapper.Map<Department>(department));
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<DepartmentViewModel>> PostDepartment(DepartmentViewModel department)
        {
            if (department != null)
            {
                await _departmentService.PostDepartment(_mapper.Map<Department>(department));
            }

            return CreatedAtAction("GetDepartment", new {id = department.Id}, department);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _departmentService.DeleteDepartment(id);
            if (department == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}