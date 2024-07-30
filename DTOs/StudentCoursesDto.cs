namespace University.API.DTOs
{
    public class StudentCoursesDto
    {
        public int StudentId { get; set; }
        public List<int> CoursesIds { get; set; }
    }
}
