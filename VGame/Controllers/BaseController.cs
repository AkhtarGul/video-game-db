using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using VGame.Model;

namespace VGame.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BaseController<T> : ControllerBase where T : class, IBaseEntity
  {
    protected readonly AppDbContext _appDbContext;

    protected readonly DbSet<T> _dbSet;
    public BaseController(AppDbContext appDbContext, DbSet<T> dbSet)
    {
      _appDbContext = appDbContext;
      _dbSet = dbSet;
    }
    [HttpGet("")]
    virtual public IActionResult Get()
    {
      var data = _dbSet.AsNoTracking();
      return Ok(data);
    }
    [HttpGet("{id}")]
    virtual public IActionResult Get(int id)
    {
      var user = _dbSet.AsNoTracking().FirstOrDefault(c => c.Id == id);
      if (user == null) return NotFound();

      return Ok(user);
    }

    [HttpPut("{id}")]
    virtual public async Task<IActionResult> Put(int id, [FromBody] T dbEntity)
    {
      if (id != dbEntity.Id) return BadRequest();

      _appDbContext.Entry(dbEntity).State = EntityState.Modified;

      try
      {
        await _appDbContext.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (Exists(id) == false) return NotFound();

        throw;
      }

      return NoContent();
    }

    [HttpPost]
    virtual public async Task<ActionResult<T>> Post([FromBody] T dbEntity)
    {
      _dbSet.Add(dbEntity);
      await _appDbContext.SaveChangesAsync();

      return CreatedAtAction("Get", new { id = dbEntity.Id }, dbEntity);
    }

    [HttpDelete("{id}")]
    virtual public async Task<ActionResult<T>> Delete(int id)
    {
      var dbEntity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
      if (dbEntity == null) return NotFound();

      _dbSet.Remove(dbEntity);
      await _appDbContext.SaveChangesAsync();

      return dbEntity;
    }


    private bool Exists(int id)
    {
      return _dbSet.Any(e => e.Id == id);
    }

  }
}
