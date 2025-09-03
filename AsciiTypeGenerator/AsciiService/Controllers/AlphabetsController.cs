using AsciiService.Models.Alphabet;
using AsciiService.Repositories.AlphabetsRepository;
using AsciiService.Shared.Constants;
using AsciiService.Shared.Constants.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AsciiService.Controllers;

[ApiController]
[Route($"{ApiRoutes.BasePath}/[controller]")]
public class AlphabetsController(IAlphabetsRepository alphabetsRepository)
    : ControllerBase
{
    [HttpGet(ApiRoutes.Alphabets.GetAll)]
    public async Task<ActionResult<List<AlphabetDetailsDto>>> GetAll()
    {
        var alphabets = await alphabetsRepository.GetAllAsync();

        return Accepted(alphabets.Select(AlphabetDetailsDto.FromEntity).ToList());
    }

    [HttpGet(ApiRoutes.Alphabets.GetById)]
    public async Task<ActionResult<AlphabetDetailsDto>> GetAlphabetById([FromRoute] int id)
    {
        if (!await alphabetsRepository.Exists(id))
            return NotFound(Messages.Error.AlphabetNotFound(id));

        var alphabet = await alphabetsRepository.GetAsync(id);

        return Ok(AlphabetDetailsDto.FromEntity(alphabet));
    }

    [HttpGet(ApiRoutes.Alphabets.UserAlphabets)]
    public async Task<ActionResult<List<AlphabetDetailsDto>>> GetUserAlphabets([FromRoute] string username)
    {
        var alphabets = await alphabetsRepository.GetUserAlphabetsAsync(username);

        return Ok(alphabets.Select(AlphabetDetailsDto.FromEntity).ToList());
    }

    [Authorize]
    [HttpGet(ApiRoutes.Alphabets.UserPrivateAlphabets)]
    public async Task<ActionResult<List<AlphabetDetailsDto>>> GetUserPrivateAlphabets()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var alphabets = await alphabetsRepository.GetUserPrivateAlphabetsAsync(userId);

        return Ok(alphabets.Select(AlphabetDetailsDto.FromEntity).ToList());
    }

    [Authorize]
    [HttpPost(ApiRoutes.Alphabets.Create)]
    public async Task<ActionResult<AlphabetDetailsDto>> CreateAlphabet([FromBody] AlphabetCreateDto request)
    {
        if (request is null)
            return BadRequest(Messages.Error.InvalidRequestBody);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var userName = User.Identity?.Name;
        var alphabet = await alphabetsRepository.AddAsync(request.ToEntity(userId, userName));

        return CreatedAtAction(nameof(GetAlphabetById), new { id = alphabet.Id },
            AlphabetDetailsDto.FromEntity(alphabet));
    }

    [Authorize]
    [HttpPut(ApiRoutes.Alphabets.Update)]
    public async Task<ActionResult<AlphabetDetailsDto>> UpdateAlphabet([FromRoute] int id,
        [FromBody] AlphabetUpdateDto request)
    {
        if (request is null)
            return BadRequest(Messages.Error.InvalidRequestBody);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!await alphabetsRepository.Exists(id))
            return NotFound(Messages.Error.AlphabetNotFound(id));

        var alphabet = await alphabetsRepository.GetAsync(id);

        if (alphabet.AuthorId != User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value)
            return Forbid(Messages.Error.ForbiddenUpdateAlphabet(id));

        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var userName = User.Identity?.Name;
        var alphabetUpdate = await alphabetsRepository.UpdateAsync(id, userId, userName, request);

        return Ok(AlphabetDetailsDto.FromEntity(alphabetUpdate));
    }

    [Authorize]
    [HttpDelete(ApiRoutes.Alphabets.Delete)]
    public async Task<ActionResult<AlphabetDeletedResponse>> DeleteAlphabet([FromRoute] int id)
    {
        if (!await alphabetsRepository.Exists(id))
            return NotFound(Messages.Error.AlphabetNotFound(id));

        var alphabet = await alphabetsRepository.GetAsync(id);

        if (alphabet.AuthorId != User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value)
            return Forbid(Messages.Error.ForbiddenDeleteAlphabet(id));

        await alphabetsRepository.DeleteAsync(id);

        return Ok(AlphabetDeletedResponse.FromId(id));
    }
}