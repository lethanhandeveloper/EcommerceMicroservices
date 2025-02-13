//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Threading;
//using System.Threading.Tasks;

//public class MyBackgroundService : BackgroundService
//{
//    private readonly ILogger<MyBackgroundService> _logger;

//    public MyBackgroundService(ILogger<MyBackgroundService> logger)
//    {
//        _logger = logger;
//    }

//    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//    {
//        while (!stoppingToken.IsCancellationRequested)
//        {
//            _logger.LogInformation("Background service is running at: {time}", DateTimeOffset.Now);
//            await Task.Delay(5000, stoppingToken); // Chạy mỗi 5 giây
//        }
//    }
//}
