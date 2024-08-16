using Chirp.Api;
using Chirp.Api.Configuration;
using Chirp.Api.Database;
using Chirp.Api.Endpoints;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

builder
    .Services.AddOptions<CassandraOptions>()
    .BindConfiguration(CassandraOptions.SectionName)
    .ValidateOnStart();

builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IPostRepository, PostRepository>();
builder.Services.AddSingleton<ICassandraContext, CassandraContext>();
builder.Services.AddSingleton(p => p.GetRequiredService<ICassandraContext>().GetSession());

var app = builder.Build();

app.MapGroup("/users").MapUserEndpoints();
app.MapGroup("/posts").MapPostEndpoints();

await app.InitializeAsync();
await app.RunAsync();
