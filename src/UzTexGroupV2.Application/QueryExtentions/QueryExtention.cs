using Microsoft.AspNetCore.Http;
using System.Text.Json;
using UzTexGroupV2.Model;

namespace UzTexGroupV2.Application.QueryExtentions;

public static class QueryExtention
{
    private static int maxPageSize = 100;
    private static string paginationKey = "Data-Pagination";
    public static IQueryable<T> PagedList<T>(
        this IQueryable<T> query,
        HttpContext httpContext,
        QueryParameter queryParameter
        )
    {
        ValidateQuery.VerifyQueryParametr(queryParameter);

        var pagenation = new Pagenation(
            totalPages: query.Count(),
            pageSize: queryParameter.Size,
            currentPage: queryParameter.Page);

        httpContext.Response.Headers[paginationKey] = JsonSerializer
            .Serialize( pagenation ); 

        return query
            .Skip((queryParameter.Page - 1) * queryParameter.Size)
            .Take(queryParameter.Size);
    }
}
