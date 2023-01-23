using EasyHiring.ApiContract.Contract;
using MediatR;

namespace EasyHiring.ApiContract.Request.Query;

public class GetQuestionListQuery : IRequest<ResponseBase<List<QuestionDto>>>
{
}