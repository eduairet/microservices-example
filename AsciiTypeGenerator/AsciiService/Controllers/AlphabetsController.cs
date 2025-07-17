using AsciiService.Models.Alphabets;
using AsciiService.Models.Virtualize;
using AsciiService.Repositories.AlphabetsRepository;
using AsciiService.Shared.Constants;
using Microsoft.AspNetCore.Mvc;

namespace AsciiService.Controllers;

[ApiController]
[Route($"{ApiRoutes.BasePath}/[controller]")]
public class AlphabetsController(IAlphabetsRepository alphabetsRepository) : ControllerBase
{
    [HttpGet(ApiRoutes.Alphabets.GetAll)]
    public async Task<ActionResult<VirtualizeResponse<AlphabetDetailsDto>>> GetAllAlphabets(
        [FromQuery] GetAllAlphabetsRequest request)
    {
        try
        {
            var parameters = new VirtualizeQueryParameters();
            parameters.StartIndex = request.Page * parameters.PageSize;

            var alphabets = await alphabetsRepository.GetAllAsync(parameters, request.SearchText);

            if (alphabets.TotalCount == 0)
                return NotFound(ErrorMessages.AlphabetsNotFound(request.SearchText));

            return Ok(alphabets.Items.Select(AlphabetDetailsDto.FromEntity));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet(ApiRoutes.Alphabets.GetById)]
    public async Task<ActionResult<AlphabetDetailsDto>> GetAlphabetById([FromRoute] string id)
    {
        try
        {
            var alphabet = await alphabetsRepository.GetAsync(id);

            if (alphabet is null)
                return NotFound(ErrorMessages.AlphabetNotFound(id));

            return Ok(AlphabetDetailsDto.FromEntity(alphabet));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost(ApiRoutes.Alphabets.Create)]
    public async Task<ActionResult<AlphabetDetailsDto>> CreateAlphabet([FromBody] AlphabetUpsertDto upsertDto)
    {
        if (upsertDto is null)
            return BadRequest(ErrorMessages.InvalidRequestBody);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            // TODO: Get author ID from authentication context
            const string authorId = "system";

            var alphabet = await alphabetsRepository.AddAsync(upsertDto.ToEntity(authorId));

            return CreatedAtAction(nameof(GetAlphabetById), new { id = alphabet.Id },
                AlphabetDetailsDto.FromEntity(alphabet));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPut(ApiRoutes.Alphabets.Update)]
    public async Task<ActionResult<AlphabetDetailsDto>> UpdateAlphabet([FromRoute] string id,
        [FromBody] AlphabetUpsertDto updateDto)
    {
        if (updateDto is null)
            return BadRequest(ErrorMessages.InvalidRequestBody);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        // TODO: Check the author is the same as the one who created the alphabet

        try
        {
            var alphabet = await alphabetsRepository.GetAsync(id);

            if (alphabet is null)
                return NotFound(ErrorMessages.AlphabetNotFound(id));

            await alphabetsRepository.UpdateAsync(updateDto.ToEntity(id, alphabet.AuthorId));

            return Ok(AlphabetDetailsDto.FromEntity(alphabet));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}