namespace Leasing.API.App.Domain.Models;

public class Fee
{
    public int Id { get; set; }
    public float Quantity { get; set; }
    
    //RelationShip
    public FeeType FeeType { get; set; }
    public int FeeTypeId { get; set; }

    public List<Solution> Solutions { get; set; } = new List<Solution>();
}