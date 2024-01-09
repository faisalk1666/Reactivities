using Application;
using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }

        [HttpPost]
        public async Task<IActionResult> AddActivity(Activity activity)
        {
            try
            {
                await Mediator.Send(new Create.Command{Activity = activity});
                return Ok("Activity added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error"); // Return an appropriate status code and message for an error
            }
        }
        [HttpPut]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            try
            {
                activity.Id = id;
                await Mediator.Send(new Edit.Command{Activity = activity});
                return Ok("Activity Updated Successfully");
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(Guid id)
        {
            try
            {
                await Mediator.Send(new Delete.Command{Id = id});
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
            return Ok("Activity Deleted Successfully");
        }

    }
}