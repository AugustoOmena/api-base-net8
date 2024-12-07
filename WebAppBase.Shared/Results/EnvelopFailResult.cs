using Swashbuckle.AspNetCore.Annotations;
using WebAppBase.Shared.Notifications;
using WebAppBase.Shared.Swagger;

namespace WebAppBase.Shared.Results;

[SwaggerSchemaFilter(typeof(EnvelopFailResultExampleSchemaFilter))]
public class EnvelopFailResult : EnvelopResult
{
    public EnvelopFailResult()
    {
        Success = false;
    }
        
    public IEnumerable<string> Errors { get; set; }

    public static new EnvelopFailResult Fail() => new EnvelopFailResult {Success = false};

    public static new EnvelopFailResult Fail(IEnumerable<Notification> notifications) => new EnvelopFailResult
    {
        Errors = notifications.Select(x => x.Value),
        Success = false
    };
}