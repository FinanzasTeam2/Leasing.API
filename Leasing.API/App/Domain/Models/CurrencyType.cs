﻿namespace Leasing.API.App.Domain.Models;

public class CurrencyType
{
    public int Id { get; set; }
    public string CurrencyName { get; set; }
    public float Price { get; set; }
    //RelationShip
    private List<Solution> Solutions = new List<Solution>();
}