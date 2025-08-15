using AsciiService.Models.Alphabet;
using AsciiService.Repositories.AlphabetsRepository;
using AsciiService.Shared.Constants;
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
        try
        {
            var alphabets = await alphabetsRepository.GetAllAsync();

            return Accepted(alphabets.Select(AlphabetDetailsDto.FromEntity).ToList());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet(ApiRoutes.Alphabets.GetById)]
    public async Task<ActionResult<AlphabetDetailsDto>> GetAlphabetById([FromRoute] int id)
    {
        try
        {
            if (!await alphabetsRepository.Exists(id))
                return NotFound(ErrorMessages.AlphabetNotFound(id));

            var alphabet = await alphabetsRepository.GetAsync(id);

            return Ok(AlphabetDetailsDto.FromEntity(alphabet));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost(ApiRoutes.Alphabets.Create)]
    public async Task<ActionResult<AlphabetDetailsDto>> CreateAlphabet([FromBody] AlphabetCreateDto request)
    {
        try
        {
            if (request is null)
                return BadRequest(ErrorMessages.InvalidRequestBody);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // TODO: Get author ID from authentication context

            var now = DateTime.UtcNow;
            var alphabet = await alphabetsRepository.AddAsync(request.ToEntity(null, now, now));

            return CreatedAtAction(nameof(GetAlphabetById), new { id = alphabet.Id },
                AlphabetDetailsDto.FromEntity(alphabet));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut(ApiRoutes.Alphabets.Update)]
    public async Task<ActionResult<AlphabetDetailsDto>> UpdateAlphabet([FromRoute] int id,
        [FromBody] AlphabetUpdateDto request)
    {
        try
        {
            if (request is null)
                return BadRequest(ErrorMessages.InvalidRequestBody);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await alphabetsRepository.Exists(id))
                return NotFound(ErrorMessages.ArtworkNotFound(id));

            // TODO: Check the author is the same as the one who created the alphabet

            var alphabetUpdate = await alphabetsRepository.UpdateAsync(id, request);

            return Ok(AlphabetDetailsDto.FromEntity(alphabetUpdate));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete(ApiRoutes.Alphabets.Delete)]
    public async Task<ActionResult<AlphabetDeletedResponse>> DeleteAlphabet([FromRoute] int id)
    {
        // TODO: Check the author is the same as the one who created the alphabet

        try
        {
            if (!await alphabetsRepository.Exists(id))
                return NotFound(ErrorMessages.AlphabetNotFound(id));

            await alphabetsRepository.DeleteAsync(id);

            return Ok(AlphabetDeletedResponse.FromId(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}