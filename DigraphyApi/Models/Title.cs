using System.ComponentModel.DataAnnotations;

namespace DigraphyApi.Models;

public class Title
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string SmallPosterUrl { get; set; } = null!;
    public string LargePosterUrl { get; set; } = null!;
    public DateTime ReleasedAtUtc { get; set; }
    public string Description { get; set; } = null!;
    public int? TmdbId { get; set; }

    /// <summary>
    /// Factoids that are from this title.
    /// </summary>
    public List<Factoid> ContainedFactoids { get; set; } = [];

    /// <summary>
    /// Collections that this title belongs to.
    /// </summary>
    public List<Collection> Collections { get; set; } = [];

    /// <summary>
    /// Factoids that are required to know prior to this title. Note that this relation doesn't
    /// actually exist in the database, it's just a convience property for accessing the factoids
    /// via the FactoidsImportance join table.
    /// </summary>
    public List<Factoid> RequiredFactoids { get; set; } = [];

    /// <summary>
    /// The importance of factoids that are required to know prior to this title.
    /// </summary>
    public List<FactoidsImportance> RequiredFactoidsImportance { get; set; } = [];

    /// <summary>
    /// Orders that contain this title. Note that this relation doesn't actually exist in the
    /// database, it's just a convience property for accessing the titles via the OrderTitle join
    /// table.
    /// </summary>
    public List<Order> Orders { get; set; } = [];

    /// <summary>
    /// The indexicies of the title in the different orders.
    /// </summary>
    public List<OrderTitle> OrderIndicies { get; set; } = [];
}
