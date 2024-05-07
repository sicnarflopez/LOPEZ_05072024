using Lopez_05072024.Application.File.Command.ProcessFile;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
    private ISender? _mediator;

    /// <summary>
    /// Mediator Sender Interface
    /// </summary>
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    /// <summary>
    /// File processing endpoint. (CSV)
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [ProducesResponseType(typeof(string), 200)]
    [HttpPost("process-file")]
    public async Task<IActionResult> CreateUsersFromPS([FromForm] ProcessFileCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(result);
    }
}
