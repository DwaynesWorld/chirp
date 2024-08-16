using Chirp.Api.Database;
using Chirp.Api.Domain;
using Chirp.Api.Protos.Questions;
using Chirp.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chirp.Api.Endpoints;

public static class QuestionEndpoints
{
    public static RouteGroupBuilder MapQuestionEndpoints(this RouteGroupBuilder g)
    {
        g.MapPost(
            "/",
            async (
                [FromBody] CreateQuestionRequest request,
                [FromServices] IQuestionService s,
                CancellationToken ct
            ) =>
            {
                var res = await s.Create(request, ct);

                return res.IsSuccess
                    ? Results.Created()
                    : Results.UnprocessableEntity(res.Errors.FirstOrDefault()?.Message);
            }
        );

        return g;
    }
}
