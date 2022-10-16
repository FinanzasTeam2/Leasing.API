namespace Leasing.API.App.Resources;

public class SolutionResource
{
    public int Id { get; set; }
    public string LoanDate  { get; set; }
    public DateTime FirstPaymentDate { get; set; }
    public float Value { get; set; }
}