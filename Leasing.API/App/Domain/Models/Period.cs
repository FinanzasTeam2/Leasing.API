namespace Leasing.API.App.Domain.Models;

public class Period
{
    public int  Id { get; set; }
    public float Quantity { get; set; }
    
    //RelationShip
    public Time Time { get; set; }
    public int TimeId { get; set; }

    private List<Solution> Solutions { get; set; } = new List<Solution>();
}