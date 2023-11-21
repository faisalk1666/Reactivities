using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ActivitiesController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<ActivityDTO>>> GetActivities()
        {
            var activities = await _context.Activities.ToListAsync();
            return _mapper.Map<List<ActivityDTO>>(activities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityDTO>> GetActivity(Guid id)
        {
            var activity = await _context.Activities.FindAsync(id);
            return _mapper.Map<ActivityDTO>(activity);
        }

        [HttpPost]
        public async Task<IActionResult> AddActivity(string Title, string Description, string City, string Venue)
        {
            try
            {
                var activityDTO = new ActivityDTO
                {
                    Title = Title,
                    Date = DateTime.UtcNow,
                    Description = Description,
                    City = City,
                    Venue = Venue
                };
                var activity = _mapper.Map<Activity>(activityDTO);
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