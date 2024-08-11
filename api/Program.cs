using Chirp.Api.Posts;
using Chirp.Api.Users;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IPostRepository, PostRepository>();

var app = builder.Build();

app.MapGroup("/users").MapUserEndpoints();
app.MapGroup("/posts").MapPostEndpoints();

app.Run();
