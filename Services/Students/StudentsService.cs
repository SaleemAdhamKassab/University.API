using static University.API.Helper.ServiceResult;
using University.API.Models;
using University.API.Dtos;
using Microsoft.EntityFrameworkCore;

namespace University.API.Services.Students
{
    public interface IStudentsService
    {
        ResultWithMessage getStudentCoursesAsync(int studentId);
        ResultWithMessage registerForCourses(StudentCoursesDto studentCoursesDto);
        ResultWithMessage getPayments(string email);
    }

    public class StudentsService(ApplicationDbContext db) : IStudentsService
    {
        private readonly ApplicationDbContext _db = db;

        public ResultWithMessage getStudentCoursesAsync(int studentId)
        {
            List<StudentCourse> studentCourses = _db.Courses.Select(e => new StudentCourse
            {
                CourseId = e.Id,
                CourseName = e.Name

            })
            .ToList();

            if (studentCourses.Count == 0)
                return new ResultWithMessage(null, $"No Courses Founded for Student Id: {studentId}");

            return new ResultWithMessage(studentCourses, string.Empty);
        }
        public ResultWithMessage registerForCourses(StudentCoursesDto studentCoursesDto)
        {
            if (string.IsNullOrEmpty(studentCoursesDto.Email) || studentCoursesDto.CoursesIds.Count == 0)
                return new ResultWithMessage(null, "Invalid model");

            Student student = _db.Students.SingleOrDefault(e => e.User.Email.ToLower() == studentCoursesDto.Email.ToLower());
            if (student is null)
                return new ResultWithMessage(null, $"Invalid student email:{studentCoursesDto.Email}");



            foreach (int courseId in studentCoursesDto.CoursesIds)
            {
                _db.StudentCourses.Add(new Models.StudentCourse
                {
                    StudentId = student.Id,
                    CourseId = courseId,
                    Date = DateTime.Now
                });
            }

            Payment payment = new()
            {
                Description = "Course Registration",
                Status = "Pending",
                Term = "F20",
                AddedOn = DateTime.Now,
                TotalAmount = 1000,
                Currency = "SYP",
                Program = "MWT",
                Link = "url",
                StudentId = student.Id
            };

            _db.Payments.Add(payment);
            _db.SaveChanges();

            return new ResultWithMessage(null, string.Empty);
        }
        public ResultWithMessage getPayments(string email)
        {
            Student student = _db.Students.SingleOrDefault(e => e.User.Email.ToLower() == email.ToLower());

            if (student is null)
                return new ResultWithMessage(null, $"Invalid user email: {email}");

            List<Payment> payments = _db.Payments.Where(e => e.StudentId == student.Id).ToList();

            if (payments.Count == 0)
                return new ResultWithMessage(null, $"No payments were found for the student: {email}");

            List<PaymentViewModel> result = payments.Select(e => new PaymentViewModel()
            {
                Id = e.Id,
                Description = e.Description,
                Status = e.Status,
                Term = e.Term,
                ValidatedBy = e.ValidatedBy,
                AddedOn = e.AddedOn,
                Currency = e.Currency,
                Link = e.Link,
                Program = e.Program,
                TotalAmount = e.TotalAmount

            }).ToList();

            return new ResultWithMessage(result, string.Empty);
        }
    }
}