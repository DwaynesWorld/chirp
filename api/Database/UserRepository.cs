using Cassandra.Data.Linq;
using Chirp.Api.Domain;
using FluentResults;

namespace Chirp.Api.Database;

public interface IUserRepository
{
    ValueTask<IEnumerable<User>> GetAll();
    ValueTask<User?> GetById(int id);
    ValueTask<Result> Create(User user);
    ValueTask<Result> Update(User user);
    ValueTask<Result> Delete(int id);
}

public class UserRepository(Cassandra.ISession session) : IUserRepository
{
    private readonly Table<User> users = new(session);

    public async ValueTask<IEnumerable<User>> GetAll()
    {
        return await users.ExecuteAsync();
    }

    public async ValueTask<User?> GetById(int id)
    {
        return await users.FirstOrDefault(u => u.Id == id).ExecuteAsync();
    }

    public async ValueTask<Result> Create(User user)
    {
        await users.Insert(user).ExecuteAsync();
        return Result.Ok();
    }

    public async ValueTask<Result> Update(User user)
    {
        await users
            .Where(u => u.Id == user.Id)
            .Select(u => new User
            {
                AccountId = user.AccountId,
                Reputation = user.Reputation,
                DisplayName = user.DisplayName,
                AboutMe = user.AboutMe,
                Views = user.Views,
                UpVotes = user.UpVotes,
                DownVotes = user.DownVotes,
                WebsiteURL = user.WebsiteURL,
                Location = user.Location,
                CreationDate = user.CreationDate,
                LastAccessDate = user.LastAccessDate
            })
            .Update()
            .ExecuteAsync();
        return Result.Ok();
    }

    public async ValueTask<Result> Delete(int id)
    {
        await users.Where(u => u.Id == id).Delete().ExecuteAsync();
        return Result.Ok();
    }
}
