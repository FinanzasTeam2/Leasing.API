namespace Leasing.API.App.Domain.Models;

public class LeasingMethod
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    
    //RelationShip
    public List<LeasingResult> LeasingResults { get; set; } = new List<LeasingResult>();
}