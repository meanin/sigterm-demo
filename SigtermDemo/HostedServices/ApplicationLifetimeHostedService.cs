using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace SigtermDemo.HostedServices
{
    public class ApplicationLifetimeHostedService : IHostedService
    {
        private readonly IApplicationLifetime _appLifetime;

        public ApplicationLifetimeHostedService(IApplicationLifetime appLifetime)
        {
            _appLifetime = appLifetime;
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
            return;
        }

        private void OnStopping()
        {
            return;
        }

        private void OnStopped()
        {
            return;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
