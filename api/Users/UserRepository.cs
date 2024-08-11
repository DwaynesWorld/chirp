using FluentResults;

namespace Chirp.Api.Users;

public interface IUserRepository
{
    ValueTask<IEnumerable<UserEntity>> GetAll();
    ValueTask<UserEntity?> GetById(int id);
    ValueTask<Result> Create(UserEntity user);
    ValueTask<Result> Update(UserEntity user);
    ValueTask<Result> Delete(int id);
}

public class UserRepository : IUserRepository
{
    private readonly List<UserEntity> _users = [];

    public ValueTask<IEnumerable<UserEntity>> GetAll()
    {
        var u = _users.AsEnumerable();
        return ValueTask.FromResult(u);
    }

    public ValueTask<UserEntity?> GetById(int id)
    {
        var u = _users.SingleOrDefault(u => u.Id == id);
        return ValueTask.FromResult(u);
    }

    public ValueTask<Result> Create(UserEntity user)
    {
        _users.Add(user);
        return ValueTask.FromResult(Result.Ok());
    }

    public ValueTask<Result> Update(UserEntity user)
    {
        if (!_users.Any(u => u.Id == user.Id))
        {
            return ValueTask.FromResult(Result.Fail("Not Found"));
        }

        _users.RemoveAll(u => u.Id == user.Id);
        _users.Add(user);
        return ValueTask.FromResult(Result.Ok());
    }

    public ValueTask<Result> Delete(int id)
    {
        _users.RemoveAll(u => u.Id == id);
        return ValueTask.FromResult(Result.Ok());
    }
}
