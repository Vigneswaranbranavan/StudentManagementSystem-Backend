﻿using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;

namespace StudentManagementSystem.IServices
{
    public interface ITeacherService
    {
        Task<TeacherResponse> AddTeacherAsync(TeacherRequest teacherRequest);
        Task<IEnumerable<TeacherResponse>> GetTeachers();
        Task<TeacherResponse> GetTeacherByTeacherId(Guid teacherId);
        Task<TeacherResponse> UpdateTeacher(Guid id, TeacherReqDto request);
        Task<List<TimeTableResponse>> GetTimetableByTeacherId(Guid id);
        Task<TeacherResponse> GetTeacherBySubjectId(Guid subjectId);
        Task<TeacherResponse> DeleteTeacher(Guid id);
        Task<TeacherResponse> GetTeacherByUserIdAsync(Guid userId);
    }
}
