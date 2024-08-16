using Cassandra;
using Cassandra.Data.Linq;
using Chirp.Api.Domain;
using FluentResults;

namespace Chirp.Api.Database;

public interface IPostRepository
{
    ValueTask<IEnumerable<Post>> GetAll();
    ValueTask<Post?> GetById(int id);
    ValueTask<Result> Create(Post post);
    ValueTask<Result> Update(Post post);
    ValueTask<Result> Delete(int id);
}

public class PostRepository(Cassandra.ISession session) : IPostRepository
{
    private readonly Table<Post> posts = new(session);

    public async ValueTask<IEnumerable<Post>> GetAll()
    {
        return await posts.ExecuteAsync();
    }

    public async ValueTask<Post?> GetById(int id)
    {
        return await posts.FirstOrDefault(u => u.Id == id).ExecuteAsync();
    }

    public async ValueTask<Result> Create(Post post)
    {
        await posts.Insert(post).ExecuteAsync();
        return Result.Ok();
    }

    public ValueTask<Result> Update(Post post)
    {
        // if (!_posts.Any(p => p.Id == post.Id))
        // {
        //     return ValueTask.FromResult(Result.Fail("Not Found"));
        // }

        // _posts.RemoveAll(p => p.Id == post.Id);
        // _posts.Add(post);
        return ValueTask.FromResult(Result.Ok());
    }

    public async ValueTask<Result> Delete(int id)
    {
        await posts.Where(u => u.Id == id).Delete().ExecuteAsync();
        return Result.Ok();
    }
}
