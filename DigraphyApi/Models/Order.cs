using System.ComponentModel.DataAnnotations;

namespace DigraphyApi.Models;

public class Order
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool IsVerified { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime EditedAtUtc { get; set; }

    /// <summary>
    /// The collection this order belongs to.
    /// </summary>
    public Collection Collection { get; set; } = null!;

    /// <summary>
    /// Titles that are contained in this order. Note that this relation doesn't actually exist in
    /// the database, it's just a convience property for accessing the titles via the OrderTitle
    /// join table.
    /// </summary>
    public List<Title> Titles { get; set; } = [];

    /// <summary>
    /// The index of each of the titles in the order.
    /// </summary>
    public List<OrderTitle> OrderTitles { get; set; } = [];

    // TODO: Add in when we have a user system
    // public Person CreatedById { get; set; } = null!;
}