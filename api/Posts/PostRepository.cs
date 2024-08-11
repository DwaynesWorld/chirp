using FluentResults;

namespace Chirp.Api.Posts;

public interface IPostRepository
{
    ValueTask<IEnumerable<PostEntity>> GetAll();
    ValueTask<PostEntity?> GetById(int id);
    ValueTask<Result> Create(PostEntity post);
    ValueTask<Result> Update(PostEntity post);
    ValueTask<Result> Delete(int id);
}

public class PostRepository : IPostRepository
{
    private readonly List<PostEntity> _posts = [];

    public ValueTask<IEnumerable<PostEntity>> GetAll()
    {
        var p = _posts.AsEnumerable();
        return ValueTask.FromResult(p);
    }

    public ValueTask<PostEntity?> GetById(int id)
    {
        var p = _posts.SingleOrDefault(p => p.Id == id);
        return ValueTask.FromResult(p);
    }

    public ValueTask<Result> Create(PostEntity post)
    {
        _posts.Add(post);
        return ValueTask.FromResult(Result.Ok());
    }

    public ValueTask<Result> Update(PostEntity post)
    {
        if (!_posts.Any(p => p.Id == post.Id))
        {
            return ValueTask.FromResult(Result.Fail("Not Found"));
        }

        _posts.RemoveAll(p => p.Id == post.Id);
        _posts.Add(post);
        return ValueTask.FromResult(Result.Ok());
    }

    public ValueTask<Result> Delete(int id)
    {
        _posts.RemoveAll(p => p.Id == id);
        return ValueTask.FromResult(Result.Ok());
    }
}
