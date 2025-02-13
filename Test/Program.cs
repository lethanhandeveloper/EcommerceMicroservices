using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

public class ConsoleBackgroundService : BackgroundService
{
    private readonly ILogger<ConsoleBackgroundService> _logger;

    public ConsoleBackgroundService(ILogger<ConsoleBackgroundService> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Background service is running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken); // Chạy mỗi giây
        }
    }
}

// Program.cs

class A
{
    public string Name { get; set; }
}

class B
{
    public string Name { get; set; }
}

class Program
{
    public void print(dynamic a)
    {
        Console.WriteLine(a.Name);
    }
    static void Main(string[] args)
    {
        A a = new A();
        a.Name = "123";

        new Program().print(a);
    }
}