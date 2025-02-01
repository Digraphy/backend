using System.ComponentModel.DataAnnotations;

namespace DigraphyApi.Models;

public class Factoid
{
    [Key]
    public int Id { get; set; }
    public string Description { get; set; } = null!;

    /// <summary>
    /// Titles which contain this factoid.
    /// </summary>
    public List<Title> AffilitatedTitles { get; set; } = [];

    /// <summary>
    /// Titles that are dependent on knowing this factoid. Note that this relation doesn't actually
    /// exist in the database, it's just a convience property for accessing the titles via the
    /// FactoidsImportance join table.
    /// </summary>
    public List<Title> DependentTitles { get; set; } = [];

    /// <summary>
    /// The importance of this factoid for dependent titles.
    /// </summary>
    public List<FactoidsImportance> DependentTitlesImportance { get; set; } = [];

    /// <summary>
    /// Topics that are related to this factoid.
    /// </summary>
    public List<Topic> Topics { get; set; } = [];
}
