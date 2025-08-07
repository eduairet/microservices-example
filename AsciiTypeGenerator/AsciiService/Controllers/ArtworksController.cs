using AsciiService.Models.Artwork;
using AsciiService.Repositories.ArtworksRepository;
using AsciiService.Shared.Constants;
using Microsoft.AspNetCore.Mvc;

namespace AsciiService.Controllers;

[ApiController]
[Route($"{ApiRoutes.BasePath}/[controller]")]
public class ArtworksController(IArtworksRepository artworksRepository) : ControllerBase
{
    [HttpGet(ApiRoutes.Artworks.GetAll)]
    public async Task<ActionResult<List<ArtworkDetailsDto>>> GetAll()
    {
        try
        {
            var artworks = await artworksRepository.GetAllAsync();
            return Accepted(artworks.Select(ArtworkDetailsDto.FromEntity).ToList());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    [HttpGet(ApiRoutes.Artworks.GetById)]
    public async Task<ActionResult<ArtworkDetailsDto>> GetArtworkById([FromRoute] string id)
    {
        try
        {
            var artwork = await artworksRepository.GetAsync(id);

            if (artwork is null)
                return NotFound(ErrorMessages.ArtworkNotFound(id));

            return Ok(ArtworkDetailsDto.FromEntity(artwork));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost(ApiRoutes.Artworks.Create)]
    public async Task<ActionResult<ArtworkDetailsDto>> CreateArtwork([FromBody] ArtworkUpsertDto upsertDto)
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
            var artwork = await artworksRepository.AddAsync(upsertDto.ToEntity(authorId, now, now));

            return CreatedAtAction(nameof(GetArtworkById), new { id = artwork.Id },
                ArtworkDetailsDto.FromEntity(artwork));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut(ApiRoutes.Artworks.Update)]
    public async Task<ActionResult<ArtworkDetailsDto>> UpdateArtwork([FromRoute] int id,
        [FromBody] ArtworkUpsertDto updateDto)
    {
        if (updateDto is null)
            return BadRequest(ErrorMessages.InvalidRequestBody);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // TODO: Check the author is the same as the one who created the artwork

        try
        {
            var artwork = await artworksRepository.GetAsync(id);

            if (artwork is null)
                return NotFound(ErrorMessages.ArtworkNotFound(id.ToString()));

            await artworksRepository.UpdateAsync(updateDto.ToEntity(id, artwork.AuthorId, artwork.CreatedAt,
                DateTime.UtcNow));

            return Ok(ArtworkDetailsDto.FromEntity(artwork));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete(ApiRoutes.Artworks.Delete)]
    public async Task<IActionResult> DeleteArtwork([FromRoute] string id)
    {
        try
        {
            if (!await artworksRepository.Exists(id))
                return NotFound(ErrorMessages.ArtworkNotFound(id));

            await artworksRepository.DeleteAsync(id);
            return Ok(ArtworkDeletedResponse.FromId(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}