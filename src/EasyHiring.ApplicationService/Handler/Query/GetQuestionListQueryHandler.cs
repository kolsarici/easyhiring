using EasyHiring.ApiContract;
using EasyHiring.ApiContract.Contract;
using EasyHiring.ApiContract.Request.Query;
using EasyHiring.Repository.Abstract;
using MediatR;

namespace EasyHiring.ApplicationService.Handler.Query;

public class GetQuestionListQueryHandler : IRequestHandler<GetQuestionListQuery, ResponseBase<List<QuestionDto>>>
{
    private readonly IQuestionRepository _questionRepository;

    public GetQuestionListQueryHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<ResponseBase<List<QuestionDto>>> Handle(GetQuestionListQuery request,
        CancellationToken cancellationToken)
    {
        var questionList = await _questionRepository.AllAsync();
        
        return new ResponseBase<List<QuestionDto>>()
        {
            Success = true,
            Data = questionList.Select(q => new QuestionDto()
            {
                Text = q.Text,
                Options = q.Options.Select(o => new OptionDto() {Selected = o.Selected, Text = o.Text}).ToList()
            }).ToList()
        };
    }
}