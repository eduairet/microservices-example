using AsciiService.Models.Artwork;
using AsciiService.Repositories.ArtworksRepository;
using AsciiService.Shared.Constants;
using AsciiService.Shared.Constants.Messages;
using Microsoft.AspNetCore.Mvc;

namespace AsciiService.Controllers;

[ApiController]
[Route($"{ApiRoutes.BasePath}/[controller]")]
public class ArtworksController(IArtworksRepository artworksRepository)
    : ControllerBase
{
    [HttpGet(ApiRoutes.Artworks.GetAll)]
    public async Task<ActionResult<List<ArtworkDetailsDto>>> GetAll()
    {
        var artworks = await artworksRepository.GetAllAsync();

        return Accepted(artworks.Select(ArtworkDetailsDto.FromEntity).ToList());
    }

    [HttpGet(ApiRoutes.Artworks.GetById)]
    public async Task<ActionResult<ArtworkDetailsDto>> GetArtworkById([FromRoute] int id)
    {
        if (!await artworksRepository.Exists(id))
            return NotFound(Messages.Error.ArtworkNotFound(id));

        var artwork = await artworksRepository.GetAsync(id);

        return Ok(ArtworkDetailsDto.FromEntity(artwork));
    }

    [HttpPost(ApiRoutes.Artworks.Create)]
    public async Task<ActionResult<ArtworkDetailsDto>> CreateArtwork([FromBody] ArtworkUpsertDto request)
    {
        if (request is null)
            return BadRequest(Messages.Error.InvalidRequestBody);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // TODO: Get author ID from authentication context

        var now = DateTime.UtcNow;
        var artwork = await artworksRepository.AddAsync(request.ToEntity(null, now, now));

        return CreatedAtAction(nameof(GetArtworkById), new { id = artwork.Id },
            ArtworkDetailsDto.FromEntity(artwork));
    }

    [HttpPut(ApiRoutes.Artworks.Update)]
    public async Task<ActionResult<ArtworkDetailsDto>> UpdateArtwork([FromRoute] int id,
        [FromBody] ArtworkUpsertDto request)
    {
        if (request is null)
            return BadRequest(Messages.Error.InvalidRequestBody);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!await artworksRepository.Exists(id))
            return NotFound(Messages.Error.ArtworkNotFound(id));

        // TODO: Check the author is the same as the one who created the artwork

        var artwork = await artworksRepository.GetAsync(id);

        var artworkUpdate =
            await artworksRepository.UpdateAsync(request.ToEntity(id, artwork.AuthorId, artwork.CreatedAt,
                DateTime.UtcNow));

        return Ok(artworkUpdate);
    }

    [HttpDelete(ApiRoutes.Artworks.Delete)]
    public async Task<IActionResult> DeleteArtwork([FromRoute] int id)
    {
        if (!await artworksRepository.Exists(id))
            return NotFound(Messages.Error.ArtworkNotFound(id));

        // TODO: Check the author is the same as the one who created the artwork

        await artworksRepository.DeleteAsync(id);

        return Ok(ArtworkDeletedResponse.FromId(id));
    }
}