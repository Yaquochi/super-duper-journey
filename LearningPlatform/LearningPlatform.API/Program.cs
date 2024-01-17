using LearningPlatform.DataAccess.Postgres;
using LearningPlatform.DataAccess.Postgres.Repositories;
using LearningPlatforn.Application.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LearningDbContext>(options =>
{
	options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(LearningDbContext)));
});

builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<LessonsRepository>();
builder.Services.AddScoped<CoursesService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();