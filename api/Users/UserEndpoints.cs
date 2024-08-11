using Microsoft.AspNetCore.Mvc;

namespace Chirp.Api.Users;

public static class UserEndpoints
{
    public static RouteGroupBuilder MapUserEndpoints(this RouteGroupBuilder g)
    {
        g.MapGet(
            "/",
            async ([FromServices] IUserRepository r) =>
            {
                return Results.Ok(await r.GetAll());
            }
        );

        g.MapGet(
            "/{id}",
            async (int id, [FromServices] IUserRepository r) =>
            {
                var u = await r.GetById(id);
                return u is not null ? Results.Ok(u) : Results.NotFound();
            }
        );

        g.MapPost(
            "/",
            async (UserEntity user, [FromServices] IUserRepository r) =>
            {
                var res = await r.Create(user);

                return res.IsSuccess
                    ? Results.Created()
                    : Results.UnprocessableEntity(res.Errors.FirstOrDefault()?.Message);
            }
        );

        g.MapPut(
            "/{id}",
            async (int id, UserEntity user, [FromServices] IUserRepository r) =>
            {
                if (id != user.Id)
                {
                    return Results.BadRequest(
                        $"Path parameter id: {id} does not match body parameter user.id:{user.Id}"
                    );
                }

                var res = await r.Update(user);

                return res.IsSuccess
                    ? Results.Accepted()
                    : Results.UnprocessableEntity(res.Errors.FirstOrDefault()?.Message);
            }
        );

        g.MapDelete(
            "/{id}",
            async (int id, [FromServices] IUserRepository r) =>
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
