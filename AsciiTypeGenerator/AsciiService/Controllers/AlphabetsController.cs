using AsciiService.Models.Alphabets;
using AsciiService.Repositories.AlphabetsRepository;
using AsciiService.Shared.Constants;
using Microsoft.AspNetCore.Mvc;

namespace AsciiService.Controllers;

[ApiController]
[Route($"{ApiRoutes.BasePath}/[controller]")]
public class AlphabetsController(IAlphabetsRepository alphabetsRepository) : ControllerBase
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
            Console.WriteLine(ex);
            throw;
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
            const int authorId = 0;

            var now = DateTime.UtcNow;
            var alphabet = await alphabetsRepository.AddAsync(upsertDto.ToEntity(authorId, now, now));

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
                return NotFound(ErrorMessages.AlphabetNotFound(id.ToString()));

            await alphabetsRepository.UpdateAsync(updateDto.ToEntity(id, alphabet.AuthorId, alphabet.CreatedAt,
                DateTime.UtcNow));

            return Ok(AlphabetDetailsDto.FromEntity(alphabet));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete(ApiRoutes.Alphabets.Delete)]
    public async Task<ActionResult<AlphabetDeletedResponse>> DeleteAlphabet([FromRoute] string id)
    {
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