namespace InkHouse.Models;

public class Painter
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthdate { get; set; }
    public Guid CountryId { get; set; } 

    public Country Country { get; set; } 
    public ICollection<Painting> Paintings { get; set; }

}
