using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mission10.Models;

namespace mission10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlingController : ControllerBase
    {
        private BowlingLeagueContext _BowlingLeagueContext; // this sets up the context we will load up with temp for usage

        public BowlingController(BowlingLeagueContext temp) //gets temp info and loads up context
        {
            _BowlingLeagueContext = temp;
        }

        [HttpGet (Name = "GetBowlingInfo")]

        public IActionResult Get()
        {
            try
            {
                var bowlerList = _BowlingLeagueContext.Bowlers
                    .Include(b => b.Team) // Ensure Team data is loaded
                    .Where(b => b.Team != null && (b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")) // Filter by team name    
                    .Select(b => new
                    {
                        BowlerId = b.BowlerId,
                        FirstName = b.BowlerFirstName,
                        MiddleInitial = b.BowlerMiddleInit,
                        LastName = b.BowlerLastName,
                        TeamName = b.Team.TeamName,
                        Address = b.BowlerAddress,
                        City = b.BowlerCity,
                        State = b.BowlerState,
                        Zip = b.BowlerZip,
                        PhoneNumber = b.BowlerPhoneNumber
                    })
                    .ToList();

                return Ok(bowlerList); // Return HTTP 200 OK with filtered data
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
