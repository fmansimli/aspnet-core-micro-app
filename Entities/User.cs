namespace AspNet_micro_app.Entities;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? City { get; set; }
    public DateTime CreateDate { get; set; }
}