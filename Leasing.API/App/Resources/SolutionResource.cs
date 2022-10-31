namespace Leasing.API.App.Resources;

public class SolutionResource
{
    public int Id { get; set; }

    public string LoanDate  { get; set; }
    public DateTime FirstPaymentDate { get; set; }
    public float Value { get; set; }

    public UserProfileResource UserProfile { get; set; }
    public RateTypeResource RateType { get; set; }
    public FeeResource Fee { get; set; }
    public AssetTypeResource AssetType { get; set; }
    public VATResource VAT { get; set; }
    public PeriodResource Period { get; set; }
    public CurrencyTypeResource CurrencyType { get; set; }
}