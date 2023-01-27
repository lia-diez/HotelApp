using DAL;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HotelApp;

public class Test : BackgroundService
{
    public IRepositoryProvider Repositories;
    private ILogger<Test> _logger;

    public Test(IRepositoryProvider provider, ILogger<Test> logger)
    {
        _logger = logger;
        Repositories = provider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation(Repositories.Rooms.GetAll().Count().ToString());
        await Task.CompletedTask;
    }
}