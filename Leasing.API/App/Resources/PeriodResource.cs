namespace Leasing.API.App.Resources;

public class PeriodResource
{
    public int  Id { get; set; }
    public float Quantity { get; set; }
    public TimeResource Time { get; set; }
}