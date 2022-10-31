namespace Leasing.API.App.Resources;

public class SaveSolutionResource
{
    public string LoanDate  { get; set; }
    public DateTime FirstPaymentDate { get; set; }
    public float Value { get; set; }

    public int UserProfileId { get; set; }
    public int RateTypeId { get; set; }
    public int FeeId { get; set; }
    public int AssetTypeId { get; set; }
    public int VATId { get; set; }
    public int PeriodId { get; set; }
    public int CurrencyTypeId { get; set; }
}