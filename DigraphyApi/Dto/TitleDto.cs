namespace DigraphyApi.Dto;

public class TitleDto
{
    public int Id { get; set; }
}

public class CreateTitleDto
{
    public string Name { get; set; }
    public string SmallPosterUrl { get; set; }
    public string LargePosterUrl { get; set; }
    public DateTime ReleasedAtUtc { get; set; }
    public string Description { get; set; }
    public int? TmdbId { get; set; }
}