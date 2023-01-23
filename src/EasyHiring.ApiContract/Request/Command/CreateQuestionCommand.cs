using EasyHiring.ApiContract.Contract;
using MediatR;

namespace EasyHiring.ApiContract.Request.Command;

public class CreateQuestionCommand : IRequest<ResponseBase<bool>>
{
    public string Text { get; set; }
    public List<OptionDto> Options { get; set; }
}