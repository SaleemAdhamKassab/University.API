using Microsoft.EntityFrameworkCore;
using University.API.Models;
using static University.API.Portals.Employees.CoursesManagement.CourseManagementService;
using static University.API.Portals.Students.RegisterForCourses.RegisterForCoursesService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RemoteDb")));

builder.Services.AddScoped<ICourseManagement, CourseManagement>();
builder.Services.AddScoped<IRegisterForCourses, RegisterForCourses>();
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowUniversity.SPA",
		builder => builder.WithOrigins("http://localhost:4200")
						  .AllowAnyHeader()
						  .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowUniversity.SPA");

app.UseAuthorization();

app.MapControllers();

app.Run();
