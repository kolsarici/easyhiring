using EasyHiring.ApiContract.Request.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EasyHiring.ApiContract.Request.Query;

namespace EasyHiring.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class QuestionController: ControllerBase
{
    private readonly IMediator _mediator;

    public QuestionController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetQuestionListQuery());
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CreateQuestionCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}