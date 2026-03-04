using AutoMapper;
using School.Application.DTOs;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.MappingProfiles
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            CreateMap<School.Domain.Entities.School, SchoolDto>().ReverseMap();
            CreateMap<CreateSchoolDto, School.Domain.Entities.School>()
                .ConstructUsing(dto => new School.Domain.Entities.School(dto.Name, dto.LogoUrl));

            CreateMap<School.Domain.Entities.School, SchoolDto>();

            CreateMap<Student, StudentDto>();
            CreateMap<CreateStudentDto, Student>()
                .ConstructUsing(dto => new Student(dto.FullName, dto.DateOfBirth, dto.SchoolId));

            CreateMap<Teacher, TeacherDto>();
            CreateMap<CreateTeacherDto, Teacher>()
                .ConstructUsing(dto => new Teacher(dto.FullName, dto.Subject, dto.SchoolId));

            CreateMap<Grade, GradeDto>();

            // الـ CreateGradeDto لا يحتوي على SchoolId، فهنتعامل مع الـ SchoolId في الـ Controller
            CreateMap<CreateGradeDto, Grade>()
                .ConstructUsing((dto, context) =>
                {
                    // SchoolId هيتعين في الـ Controller قبل إضافة Grade
                    return new Grade(dto.StudentId, dto.Subject, dto.Score, Guid.Empty);
                });
        }
    }
}
