namespace Leasing.API.App.Resources;

public class SaveSolutionResource
{
    public string LoanDate  { get; set; }
    public DateTime FirstPaymentDate { get; set; }
    public float Value { get; set; }
}