using LearningPlatform.API.Endpoints;
using LearningPlatform.API.Middlewares;
using LearningPlatform.Persistance;
using LearningPlatform.Persistance.Repositories;
using LearningPlatforn.Application.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ExceptionMiddleware>();

builder.Services.AddDbContext<LearningDbContext>(options =>
{
	options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(LearningDbContext)));
});

builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<LessonsRepository>();
builder.Services.AddScoped<UsersRepository>();

builder.Services.AddScoped<CoursesService>();
builder.Services.AddScoped<LessonsService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddAutoMapper(typeof(DataBaseMappings));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

// app.UseMiddleware<ExceptionMiddleware>();

app.MapCoursesEndpoints();

app.MapLessonsEndpoints();

app.MapUsersEndpoints();

app.Run();