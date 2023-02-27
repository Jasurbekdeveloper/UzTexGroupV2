using Microsoft.AspNetCore.Mvc;
using UzTexGroupV2.Model;

namespace UzTexGroupV2.Extensions;

public static class ControllerExtensions
{
    public static async Task<ActionResult<ResponseModel>> MakeActionResult(this Controller controller, int statusCode, object data)
    {
        return new ActionResult<ResponseModel>(new ResponseModel(statusCode, data));
    }
    
    public static async Task<ActionResult<ResponseModel>> MakeActionResult(this Controller controller, int statusCode, Exception exception)
    {
        return new ActionResult<ResponseModel>(new ResponseModel(statusCode, exception));
    }
}