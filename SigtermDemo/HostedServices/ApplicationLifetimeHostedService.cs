using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace SigtermDemo.HostedServices
{
    public class ApplicationLifetimeHostedService : IHostedService
    {
        private readonly IApplicationLifetime _appLifetime;
        public event EventHandler OnStoppingEventHandler;

        public ApplicationLifetimeHostedService(IApplicationLifetime appLifetime)
        {
            _appLifetime = appLifetime;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifetime.ApplicationStopping.Register(OnStopping);
            _appLifetime.ApplicationStarted.Register(OnStarted);
            _appLifetime.ApplicationStopped.Register(OnStopped);

            return Task.CompletedTask;
        }

        private void OnStarted()
        {
            OnStoppingEventHandler?.Invoke(this, EventArgs.Empty);
        }

        private void OnStopping()
        {
            OnStoppingEventHandler?.Invoke(this, EventArgs.Empty);
        }

        private void OnStopped()
        {
            OnStoppingEventHandler?.Invoke(this, EventArgs.Empty);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
