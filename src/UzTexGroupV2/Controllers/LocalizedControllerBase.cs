using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Controllers;

public class LocalizedControllerBase : Controller
{
    protected readonly LocalizedUnitOfWork localizedUnitOfWork;
    public LocalizedControllerBase(LocalizedUnitOfWork localizedUnitOfWork)
    {
        this.localizedUnitOfWork = localizedUnitOfWork;
    }
    public override async void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        // await this.localizedUnitOfWork.ChangeLocalization(new Language()
        // {
        //     Code = context.RouteData.Values["langCode"] as String ?? "uz"
        // });
    }
}