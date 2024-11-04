namespace AspNet_micro_app.Dtos;

public record GetUsersQuery
{
    public int Page { get; set; }
    public int Limit { get; set; }
}