namespace Leasing.API.App.Domain.Models;

public class AssetType
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    //RelationShip
    public List<Solution> Solutions { get; set; } = new List<Solution>();
}