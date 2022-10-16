namespace Leasing.API.App.Domain.Models;

public class FeeType
{
    public int Id { get; set; }
    public string FeeName { get; set; }
    
    //RelationShip
    public List<Fee> Fees { get; set; } = new List<Fee>();
}