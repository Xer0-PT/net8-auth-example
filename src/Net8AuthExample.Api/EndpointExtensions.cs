using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Net8AuthExample.Api;

public static class EndpointExtensions
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapPost("/update",
                async Task<IResult> (ClaimsPrincipal claims, [FromBody] Request request,
                    [FromServices] IServiceProvider sp) =>
                {
                    var validator = new RequestValidator();
                    var validationResult = await validator.ValidateAsync(request);

                    if (!validationResult.IsValid)
                    {
                        return Results.BadRequest(validationResult.Errors.First().ErrorMessage);
                    }

                    var repository = sp.GetRequiredService<Repository>();
                    var user = await repository.GetUserAsync(claims.Identity!.Name!);

                    if (user is null)
                    {
                        return Results.BadRequest("User not found!");
                    }

                    user.SetMyPersonalId(request.PersonalId);
                    await repository.SaveChangesAsync();

                    return Results.Ok("Changes saved with success!");
                })
            .RequireAuthorization();
    }
}