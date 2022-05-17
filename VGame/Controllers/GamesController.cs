using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using VGame.Model;

namespace VGame.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class GamesController : BaseController<Game>
  {
    public GamesController(AppDbContext appDbContext) : base(appDbContext, appDbContext.Games)
    {
    }
    public override IActionResult Get()
    {
      var res= _dbSet.Include(ch=>ch.Genres).Include(ch=>ch.Ratings).Include(x=>x.ScreenShorts).Include(x=>x.Trailers).Include(x=>x.ParentPlatforms).Include(y=>y.Publishers).AsNoTracking();
      return Ok(res);
    }
  }
  }

