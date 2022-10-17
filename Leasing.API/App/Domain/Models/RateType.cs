namespace Leasing.API.App.Domain.Models;

public class RateType
{
    public int Id { get; set; }
    public string RateName { get; set; }
    public double Percentage { get; set; }
    
    //RelationShip
    public List<Solution> Solutions { get; set; } = new List<Solution>();
}