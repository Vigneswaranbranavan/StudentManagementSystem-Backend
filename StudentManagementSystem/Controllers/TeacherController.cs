﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;
using StudentManagementSystem.IServices;
using StudentManagementSystem.Services;

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
                var createTeacher = await _teacherService.AddTeacherAsync(teacherRequest);
                return CreatedAtAction(nameof(GetTeacherByTeacherId), new { id = createTeacher.ID }, createTeacher);
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


        [HttpGet("TeacherByTeacherId")]
        public async Task<IActionResult> GetTeacherByTeacherId(Guid teacherId)
        {
            try
            {
                var data = await _teacherService.GetTeacherByTeacherId(teacherId);
                return Ok(data);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("Teacher")]
        public async Task<IActionResult> UpdateTeacher(Guid Id, TeacherReqDto request)
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

        [HttpGet("GetTeacherBySubjectId")]
        public async Task<IActionResult> GetTeacherBySubjectId(Guid id)
        {
            try
            {
                var data = await _teacherService.GetTeacherBySubjectId(id);
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



        [HttpGet("user/{userId}")]
        public async Task<ActionResult<StudentResponce>> geGetTeacherByUserIdAsync(Guid userId)
        {
            try
            {
                var student = await _teacherService.GetTeacherByUserIdAsync(userId);
                return Ok(student);  // The response now includes the Class details
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Student not found for the provided UserID." });
            }
        }
    }
}
