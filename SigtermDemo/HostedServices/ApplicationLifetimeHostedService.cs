using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SigtermDemo.HostedServices
{
    public class ApplicationLifetimeHostedService : IHostedService
    {
        private readonly IApplicationLifetime _appLifetime;
        private readonly ILogger<ApplicationLifetimeHostedService> _logger;

        public ApplicationLifetimeHostedService(
            IApplicationLifetime appLifetime,
            ILogger<ApplicationLifetimeHostedService> logger)
        {
            _appLifetime = appLifetime;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifetime.ApplicationStarted.Register(OnStarted);
            _appLifetime.ApplicationStopping.Register(OnStopping);
            _appLifetime.ApplicationStopped.Register(OnStopped);

            return Task.CompletedTask;
        }

        private void OnStarted()
        {
            _logger.LogInformation("Hosted service OnStarted");
        }

        private void OnStopping()
        {
            _logger.LogInformation("Hosted service OnStopping");
        }

        private void OnStopped()
        {
            _logger.LogInformation("Hosted service OnStopped");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Hosted service StopAsync");
            return Task.CompletedTask;
        }
    }
}
