using AsciiService.Models.Artwork;
using AsciiService.Repositories.ArtworksRepository;
using AsciiService.Shared.Constants;
using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace AsciiService.Controllers;

[ApiController]
[Route($"{ApiRoutes.BasePath}/[controller]")]
public class ArtworksController(IArtworksRepository artworksRepository, IPublishEndpoint publishEndpoint)
    : ControllerBase
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
            return BadRequest(ex.Message);
        }
    }

    [HttpGet(ApiRoutes.Artworks.GetById)]
    public async Task<ActionResult<ArtworkDetailsDto>> GetArtworkById([FromRoute] int id)
    {
        try
        {
            if (!await artworksRepository.Exists(id))
                return NotFound(ErrorMessages.ArtworkNotFound(id));

            var artwork = await artworksRepository.GetAsync(id);
            return Ok(ArtworkDetailsDto.FromEntity(artwork));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost(ApiRoutes.Artworks.Create)]
    public async Task<ActionResult<ArtworkDetailsDto>> CreateArtwork([FromBody] ArtworkUpsertDto request)
    {
        try
        {
            if (request is null)
                return BadRequest(ErrorMessages.InvalidRequestBody);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // TODO: Get author ID from authentication context

            var now = DateTime.UtcNow;
            var artwork = await artworksRepository.AddAsync(request.ToEntity(null, now, now));
            var artworkCreated = ArtworkDetailsDto.FromEntity(artwork);

            await publishEndpoint.Publish(ArtworkDetailsDto.ToContractUpsert(artworkCreated));

            return CreatedAtAction(nameof(GetArtworkById), new { id = artwork.Id },
                artworkCreated);
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
        try
        {
            if (updateDto is null)
                return BadRequest(ErrorMessages.InvalidRequestBody);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await artworksRepository.Exists(id))
                return NotFound(ErrorMessages.ArtworkNotFound(id));

            // TODO: Check the author is the same as the one who created the artwork

            var artwork = await artworksRepository.GetAsync(id);
            var artworkUpdate = updateDto.ToEntity(id, artwork.AuthorId, artwork.CreatedAt, DateTime.UtcNow);

            await artworksRepository.UpdateAsync(artworkUpdate);
            await publishEndpoint.Publish(
                ArtworkDetailsDto.ToContractUpsert(ArtworkDetailsDto.FromEntity(artworkUpdate)));

            return Ok(artworkUpdate);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete(ApiRoutes.Artworks.Delete)]
    public async Task<IActionResult> DeleteArtwork([FromRoute] int id)
    {
        // TODO: Check the author is the same as the one who created the artwork

        try
        {
            if (!await artworksRepository.Exists(id))
                return NotFound(ErrorMessages.ArtworkNotFound(id));


            await artworksRepository.DeleteAsync(id);
            await publishEndpoint.Publish(new ArtworkDeleted { Id = id });

            return Ok(ArtworkDeletedResponse.FromId(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}