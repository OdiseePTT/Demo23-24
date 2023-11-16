using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace Todo.UITests.Helpers
{
    public class WebTestingHostFactory<TProgram>
      : WebApplicationFactory<TProgram>
      where TProgram : class
    {
        // Override the CreateHost to build our HTTP host server.
        protected override IHost CreateHost(IHostBuilder builder)
        {
            // Create the host that is actually used by the
            // TestServer (In Memory).
            var testHost = base.CreateHost(builder);
            // configure and start the actual host using Kestrel.
            builder.ConfigureWebHost(webHostBuilder => webHostBuilder.UseKestrel());
            var host = builder.Build();
            host.Start();
            // In order to cleanup and properly dispose HTTP server
            // resources we return a composite host object that is
            // actually just a way to intercept the StopAsync and Dispose
            // call and relay to our HTTP host.
            return new CompositeHost(testHost, host);
        }

        public class CompositeHost : IHost
        {
            private readonly IHost testHost;
            private readonly IHost kestrelHost;

            public CompositeHost(IHost testHost, IHost kestrelHost)
            {
                this.testHost = testHost;
                this.kestrelHost = kestrelHost;
            }

            public IServiceProvider Services => testHost.Services;

            public void Dispose()
            {
                testHost.Dispose();
                kestrelHost.Dispose();
            }

            public async Task StartAsync(
              CancellationToken cancellationToken = default)
            {
                await testHost.StartAsync(cancellationToken);
                await kestrelHost.StartAsync(cancellationToken);
            }

            public async Task StopAsync(
              CancellationToken cancellationToken = default)
            {
                await testHost.StopAsync(cancellationToken);
                await kestrelHost.StopAsync(cancellationToken);
            }
        }
    }
}