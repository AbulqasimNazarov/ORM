namespace InkHouse.Models;

public class Painting
{
    public Guid PaintingId { get; set; }
    public string Image { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public Guid PainterId { get; set; } 

    public Painter Painter { get; set; }
}
