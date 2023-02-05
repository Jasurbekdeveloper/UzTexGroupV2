using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Controllers;

public class LocalizedController : Controller
{
    protected readonly LocalizedUnitOfWork localizedUnitOfWork;
    public LocalizedController(LocalizedUnitOfWork localizedUnitOfWork)
    {
        this.localizedUnitOfWork = localizedUnitOfWork;
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        this.localizedUnitOfWork.ChangeLocalization(new Language()
        {
            Code = context.RouteData.Values["langCode"] as String ?? "uz"
        });
    }
}