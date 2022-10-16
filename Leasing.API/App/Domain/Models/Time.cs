namespace Leasing.API.App.Domain.Models;

public class Time
{
    public int Id { get; set; }

    public float TimeUnit { get; set; }
    //RelationShip
    private List<Period> Periods { get; set; } = new List<Period>();
}