using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;
        public ActivitiesController(DataContext context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _context.Activities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await _context.Activities.FindAsync(id);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddActivity(string Title, string Description, string City, string Venue)
        {
            try
            {
                var activity = new Activity
                {
                    Title = Title,
                    Date = DateTime.UtcNow,
                    Description = Description,
                    City = City,
                    Venue = Venue
                };

                await _context.Activities.AddAsync(activity);
                await _context.SaveChangesAsync();

                return Ok("Activity added successfully");
            }
            catch (Exception ex)
            {
               return StatusCode(500, "Internal Server Error"); // Return an appropriate status code and message for an error
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(Guid id)
        {
            try
            {
                var activity = await _context.Activities.FindAsync(id);
                _context.Activities.Remove(activity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
            return Ok("Activity Deleted Successfully");
        }

    }
}