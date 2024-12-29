namespace CoffeeApp.Domain.Entities;

public class Coffee
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> Ingredients { get; set; }
    public string Image { get; set; }
}
