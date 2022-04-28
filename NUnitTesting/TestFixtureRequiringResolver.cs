using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace NUnitTesting;

public class TestFixtureRequiringResolver
{
    public TestFixtureRequiringResolver()
    {
        Setup();
    }

    private IServiceProvider? _serviceProvider;

    protected T Resolve<T>() where T : notnull
    {
        return _serviceProvider!.GetRequiredService<T>();
    }

    private void Setup()
    {
        var hostBuilder = new HostBuilder()
            .ConfigureWebHost(webHost =>
            {
                webHost.UseTestServer();
                webHost.Configure(app =>
                {
                    app.Run(handle => handle
                        .Response
                        .StartAsync());

                    app.Build();
                });

                webHost.ConfigureServices(config =>
                {
                    config.AddSingleton(_ => new Dog()
                    {
                        CanWalk = true,
                        Name = "Sparky"
                    });
                    
                    config.AddSingleton(_ => new Person()
                    {
                        Name = "John",
                        Surname = "John"
                    });

                    config.AddTransient(_ => new Animal()
                    {
                        CanWalk = true
                    });
                });
            });

        var host = hostBuilder.Start();
        _serviceProvider = host.Services;
    }
}
