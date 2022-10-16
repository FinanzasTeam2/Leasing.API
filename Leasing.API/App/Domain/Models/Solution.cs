namespace Leasing.API.App.Domain.Models;

public class Solution
{
    public int Id { get; set; }
    public string LoanDate  { get; set; }
    public DateTime FirstPaymentDate { get; set; }
    public float Value { get; set; }
    //RelationShip
    public ProfileUser ProfileUser { get; set; }
    public int ProfileUserId { get; set; }
    public RateType RateType { get; set; }
    public int RateTypeId { get; set; }
    public Fee Fee { get; set; }
    public int FeeId { get; set; }
    public AssetType AssetType { get; set; }
    public int AssetTypeId { get; set; }
    public VAT VAT { get; set; }
    public int VATId { get; set; }
    public Period Period { get; set; }
    public int PeriodId { get; set; }
    public CurrencyType CurrencyType { get; set; }
    public int CurrencyTypeId { get; set; }
}