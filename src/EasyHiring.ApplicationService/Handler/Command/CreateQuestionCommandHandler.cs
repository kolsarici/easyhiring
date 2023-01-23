using EasyHiring.ApiContract;
using EasyHiring.ApiContract.Request.Command;
using EasyHiring.Domain.Entities;
using EasyHiring.Repository.Abstract;
using MediatR;

namespace EasyHiring.ApplicationService.Handler.Command;

public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, ResponseBase<bool>>
{
    private readonly IQuestionRepository _questionRepository;

    public CreateQuestionCommandHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<ResponseBase<bool>> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = new Question()
        {
            Text = request.Text,
            Options = request.Options.Select(o => new Option { Text = o.Text, Selected = o.Selected }).ToList()
        };
        await _questionRepository.SaveAsync(question);
        return new ResponseBase<bool>()
        {
            Data = true,
            Success = true
        };
    }
}