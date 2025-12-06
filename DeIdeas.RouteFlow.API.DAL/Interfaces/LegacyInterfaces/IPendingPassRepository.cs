using DeIdeas.RouteFlow.API.DAL.Models.Legacy;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeIdeas.RouteFlow.API.DAL.Interfaces.LegacyInterfaces
{
    public interface IPendingPassRepository
    {
        Task<IEnumerable<SAP_V_PendingPass>> GetAllAsync();
        Task<IEnumerable<SAP_V_PendingPass>> GetByDateRangeAsync(DateTime from, DateTime to, CancellationToken ct = default);
    }
}