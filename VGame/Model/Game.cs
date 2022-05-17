using Microsoft.EntityFrameworkCore;

namespace VGame.Model
{
  public class Game : IBaseEntity
  {

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Released { get; set; }
    public string Website { get; set; }
    public string BackgroundImage { get; set; }
    public int Metacritic { get; set; }
    public string MetacriticUrl { get; set; }
    public  List<Genre>? Genres{ get; set; }
    public List<Publisher>? Publishers { get; set; }
    public List<ParentPlatform>? ParentPlatforms { get; set; }
    public List<Rating>? Ratings { get; set; }
    public List<ScreenShort>? ScreenShorts { get; set; }
    public List<Trailer>? Trailers { get; set; }
  }

  public class Trailer
  {
    public int Id { get; set; }
    public string Max { get; set; }
  }
  public class Rating
  {
    public int Id { get; set; }
    public int Count { get; set; }
    public string Title { get; set; }
  }

  public class ScreenShort
  {
    public int Id { get; set; }
    public string Image { get; set; }
  }

  public class ParentPlatform
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }

  public class Publisher
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }

  
  public class Genre
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
}
