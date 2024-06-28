namespace InkHouse.Models;

public class Country
{
    public Guid CountryId { get; set; }
    public string Name { get; set; }

    public ICollection<Painter> Painters { get; set; }
}
