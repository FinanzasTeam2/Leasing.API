﻿using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Domain.Repository;

public interface ILeasingResultRepository
{
    Task<IEnumerable<LeasingResult>> ListAsync();
    Task AddAsync(LeasingResult leasingResult);
    Task<LeasingResult> FindByIdAsync(int id);
    Task<IEnumerable<LeasingResult>>FindByLeasingDataIdAsync(int leasingDataId);
}