using Chirp.Api.Database;
using Chirp.Api.Domain;
using Chirp.Api.Protos.Questions;
using FluentResults;
using FluentValidation;

namespace Chirp.Api.Services;

public interface IQuestionService
{
    Task<Result<Question>> Create(CreateQuestionRequest request, CancellationToken ct = default);
}

public class QuestionService(IPostRepository postRepository) : IQuestionService
{
    public async Task<Result<Question>> Create(
        CreateQuestionRequest request,
        CancellationToken ct = default
    )
    {
        var validator = new CreateQuestionRequestValidator();

        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return Result.Fail(validationResult.ToString());
        }

        Post post =
            new()
            {
                OwnerUserId = 1,
                OwnerDisplayName = "KT",
                PostType = PostType.Question,
                Title = request.Title,
                Body = request.Body,
                Tags = request.Tags,
                LastEditorUserId = 1,
                LastEditorDisplayName = "KT",
                LastEditDate = DateTimeOffset.UtcNow,
                LastActivityDate = DateTimeOffset.UtcNow,
                CreationDate = DateTimeOffset.UtcNow
            };

        var result = await postRepository.Create(post);
        if (result.IsFailed)
        {
            return result.ToResult<Question>();
        }

        return new Question() { };
    }
}

public class CreateQuestionRequestValidator : AbstractValidator<CreateQuestionRequest>
{
    public CreateQuestionRequestValidator()
    {
        RuleFor(r => r.Title).NotEmpty();
        RuleFor(r => r.Body).NotEmpty();
        RuleFor(r => r.Tags);
    }
}
