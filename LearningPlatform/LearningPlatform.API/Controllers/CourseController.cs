using LearningPlatforn.Application.Services;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace LearningPlatform.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CoursesController : ControllerBase
	{
		private readonly CoursesService _courseService;

        public CoursesController(CoursesService coursesService)
        {
            _courseService = coursesService;
        }

        [HttpGet]
		public async Task<ActionResult> GetCourses()
		{
			var courses = await _courseService.GetCoursesAsync();

			return Ok(courses);	
		}
	}
}
