using MassTransit;
using NotificationService.Events;

namespace NotificationService.Consumers;

public sealed class OrderCreatedConsumer : IConsumer<OrderCreatedEvent>
{
    private readonly ILogger<OrderCreatedConsumer> _logger;

    public OrderCreatedConsumer(ILogger<OrderCreatedConsumer> logger)
        => _logger = logger;

    public Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        var e = context.Message;

        // Здесь была бы реальная отправка email/push.
        // Пока — лог, чтобы было видно, что событие дошло.
        _logger.LogInformation(
            "EMAIL SENT to customer {CustomerId} about order {OrderId} (total: {TotalAmount})",
            e.CustomerId, e.OrderId, e.TotalAmount);

        return Task.CompletedTask;
    }
}