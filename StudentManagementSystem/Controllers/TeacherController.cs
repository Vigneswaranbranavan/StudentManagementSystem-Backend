﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.IServices;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost("Teacher")]
        public async Task<IActionResult> AddTeacher(TeacherRequest teacherRequest)
        {
            try
            {
                var ReturnData = await _teacherService.AddTeacher(teacherRequest);
                return Ok(ReturnData);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("Teacher")]
        public async Task<IActionResult> GetTeachers()
        {
            try
            {
                var data = await _teacherService.GetTeachers();
                return Ok(data);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("TeacherById")]
        public async Task<IActionResult> GetTeacherById(Guid id)
        {
            try
            {
                var data = await _teacherService.GetTeacherById(id);
                return Ok(data);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("Teacher")]
        public async Task<IActionResult> UpdateTeacher(Guid Id, TeacherRequest request)
        {
            try
            {
                var data = await _teacherService.UpdateTeacher(Id, request);
                return Ok(data);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("TimetableByTeacherId")]
        public async Task<IActionResult> GetTimetableByTeacherId(Guid id)
        {
            try
            {
                var data = await _teacherService.GetTimetableByTeacherId(id);
                return Ok(data);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetTeachersBySubjectId")]
        public async Task<IActionResult> GetTeachersBySubjectId(Guid id)
        {
            try
            {
                var data = await _teacherService.GetTeachersBySubjectId(id);
                return Ok(data);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("Teacher")]
        public async Task<IActionResult> DeleteTeacher(Guid id)
        {
            try
            {
                var data = await _teacherService.DeleteTeacher(id);
                return Ok(data);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}