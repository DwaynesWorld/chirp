using Microsoft.AspNetCore.Mvc;

namespace Chirp.Api.Posts;

public static class PostEndpoints
{
    public static RouteGroupBuilder MapPostEndpoints(this RouteGroupBuilder g)
    {
        g.MapGet(
            "/",
            async ([FromServices] IPostRepository r) =>
            {
                return Results.Ok(await r.GetAll());
            }
        );

        g.MapGet(
            "/{id}",
            async (int id, [FromServices] IPostRepository r) =>
            {
                var p = await r.GetById(id);
                return p is not null ? Results.Ok(p) : Results.NotFound();
            }
        );

        g.MapPost(
            "/",
            async (PostEntity post, [FromServices] IPostRepository r) =>
            {
                var res = await r.Create(post);

                return res.IsSuccess
                    ? Results.Created()
                    : Results.UnprocessableEntity(res.Errors.FirstOrDefault()?.Message);
            }
        );

        g.MapPut(
            "/{id}",
            async (int id, PostEntity post, [FromServices] IPostRepository r) =>
            {
                if (id != post.Id)
                {
                    return Results.BadRequest(
                        $"Path parameter id: {id} does not match body parameter post.id:{post.Id}"
                    );
                }

                var res = await r.Update(post);

                return res.IsSuccess
                    ? Results.Accepted()
                    : Results.UnprocessableEntity(res.Errors.FirstOrDefault()?.Message);
            }
        );

        g.MapDelete(
            "/{id}",
            async (int id, [FromServices] IPostRepository r) =>
            {
                var res = await r.Delete(id);

                return res.IsSuccess
                    ? Results.Accepted()
                    : Results.UnprocessableEntity(res.Errors.FirstOrDefault()?.Message);
            }
        );

        return g;
    }
}
