using AsciiService.Models.Artwork;
using AsciiService.Repositories.ArtworksRepository;
using AsciiService.Shared.Constants;
using AsciiService.Shared.Constants.Messages;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet(ApiRoutes.Artworks.UserArtworks)]
    public async Task<ActionResult<List<ArtworkDetailsDto>>> GetUserArtworks([FromRoute] string username)
    {
        var artworks = await artworksRepository.GetUserArtworksAsync(username);

        return Ok(artworks.Select(ArtworkDetailsDto.FromEntity).ToList());
    }

    [Authorize]
    [HttpGet(ApiRoutes.Artworks.UserPrivateArtworks)]
    public async Task<ActionResult<List<ArtworkDetailsDto>>> GetUserPrivateArtworks()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var artworks = await artworksRepository.GetUserPrivateArtworksAsync(userId);

        return Ok(artworks.Select(ArtworkDetailsDto.FromEntity).ToList());
    }

    [Authorize]
    [HttpPost(ApiRoutes.Artworks.Create)]
    public async Task<ActionResult<ArtworkDetailsDto>> CreateArtwork([FromBody] ArtworkUpsertDto request)
    {
        if (request is null)
            return BadRequest(Messages.Error.InvalidRequestBody);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var userName = User.Identity?.Name;
        var artwork = await artworksRepository.AddAsync(request.ToEntity(userId, userName));

        return CreatedAtAction(nameof(GetArtworkById), new { id = artwork.Id },
            ArtworkDetailsDto.FromEntity(artwork));
    }

    [Authorize]
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

        var artwork = await artworksRepository.GetAsync(id);

        if (artwork.AuthorId != User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value)
            return Forbid(Messages.Error.ForbiddenUpdateArtwork(id));

        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var userName = User.Identity?.Name;
        var artworkUpdate =
            await artworksRepository.UpdateAsync(request.ToEntity(id, userId, userName, artwork.CreatedAt));

        return Ok(ArtworkDetailsDto.FromEntity(artworkUpdate));
    }

    [Authorize]
    [HttpDelete(ApiRoutes.Artworks.Delete)]
    public async Task<IActionResult> DeleteArtwork([FromRoute] int id)
    {
        if (!await artworksRepository.Exists(id))
            return NotFound(Messages.Error.ArtworkNotFound(id));

        var artwork = await artworksRepository.GetAsync(id);

        if (artwork.AuthorId != User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value)
            return Forbid(Messages.Error.ForbiddenDeleteArtwork(id));

        await artworksRepository.DeleteAsync(id);

        return Ok(ArtworkDeletedResponse.FromId(id));
    }
}