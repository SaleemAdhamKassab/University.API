namespace University.API.Dtos
{
    public class StudentCoursesDto
    {
        public string Email { get; set; }
        public List<int> CoursesIds { get; set; }
    }
}
