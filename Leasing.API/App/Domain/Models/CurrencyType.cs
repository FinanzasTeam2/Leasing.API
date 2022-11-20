namespace Leasing.API.App.Domain.Models;

public class CurrencyType
{
    public int Id { get; set; }
    public string Moneda { get; set; }
    public string Valor { get; set; }

    //RelationShip
    public List<LeasingData> LeasingData { get; set; } = new List<LeasingData>();
}