using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mission10.Models;

namespace mission10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlingController : ControllerBase
    {
        private BowlingLeagueContext _BowlingLeagueContext; // might need a Db Context... We will see

        public BowlingController(BowlingLeagueContext temp)
        {
            _BowlingLeagueContext = temp;
        }

        [HttpGet (Name = "GetBowlingInfo")]

        public IEnumerable<Bowler> Get()
        {
            var bowlerList = _BowlingLeagueContext.Bowlers.ToList();

            return (bowlerList);
        }
    }
}
