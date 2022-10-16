namespace Leasing.API.App.Domain.Models;

public class VAT
{
    public int Id { get; set; }

    public double Percentage { get; set; }
    //RelationShip
    private List<Solution> Solutions { get; set; } = new List<Solution>();
}