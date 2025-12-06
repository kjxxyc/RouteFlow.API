using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using DeIdeas.RouteFlow.API.DAL.Context;

namespace DeIdeas.RouteFlow.API.Health
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        private readonly AppDbContext _dbContext;

        public DatabaseHealthCheck(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var canConnect = await _dbContext.Database.CanConnectAsync(cancellationToken);
                return canConnect
                    ? HealthCheckResult.Healthy("Database connection OK")
                    : HealthCheckResult.Unhealthy("Database connection failed");
            }
            catch (System.Exception ex)
            {
                return HealthCheckResult.Unhealthy("Database check exception", ex);
            }
        }
    }
}
