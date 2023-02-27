using System.Buffers;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Filters;
using UzTexGroupV2.Model;

namespace UzTexGroupV2.Filters;

public class ResponeFilter : ResultFilterAttribute
{

    public override void OnResultExecuting(ResultExecutingContext context)
    {
        base.OnResultExecuting(context);
        Console.WriteLine("Filter");
    }

    public override void OnResultExecuted(ResultExecutedContext context)
    {
        base.OnResultExecuted(context);
    }
}