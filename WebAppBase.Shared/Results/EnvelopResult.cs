using WebAppBase.Shared.Notifications;

namespace WebAppBase.Shared.Results;

public class EnvelopResult
{
    public bool Success { get; set; }

    public static EnvelopResult Ok() => new EnvelopResult();

    public static EnvelopDataResult<T> Ok<T>(T data) => EnvelopDataResult<T>.Ok(data);
        
    public static EnvelopFailResult Fail() => new EnvelopFailResult {Success = false};

    public static EnvelopFailResult Fail(IEnumerable<Notification> notifications) => new EnvelopFailResult
    {
        Errors = notifications.Select(x=> x.Value),
        Success = false
    };
}