﻿namespace University.API.Services.Students
{
    public class StudentCourse
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }

    public class PaymentViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Term { get; set; }
        public string? ValidatedBy { get; set; }
        public double TotalAmount { get; set; }
        public string Currency { get; set; }
        public string Program { get; set; }
        public string Link { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
