namespace Backend.Services;

public class EventUpdateService : BackgroundService
{
    private readonly ILogger<EventUpdateService> _logger;
    private readonly IServiceScopeFactory _scopeFactory;

    public EventUpdateService(ILogger<EventUpdateService> logger, IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {

                using (var scope = _scopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<Context>();
                    var events = await context.Dogadjaji
                                            .Where(e => e.Status == StatusDogadjaja.Active)
                                            .ToListAsync();

                    events.ForEach(e =>
                    {
                        if (e.Vreme < DateTime.Now)
                            e.Status = StatusDogadjaja.Passed;
                    });

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the status.");
            }

            await Task.Delay(TimeSpan.FromHours(2), stoppingToken);
        }
    }
}