using Microsoft.AspNetCore.Mvc;
using SearchService.Entities;
using SearchService.Models.Virtualize;
using SearchService.Repositories.SearchRepository;
using SearchService.Shared.Constants;

namespace SearchService.Controllers;

[ApiController]
[Route($"{ApiRoutes.BasePath}/[controller]")]
public class SearchController(
    ISearchRepository<Alphabet> searchAlphabetsRepository,
    ISearchRepository<Artwork> searchArtworksRepository
) : ControllerBase
{
    [HttpGet(ApiRoutes.Search.Alphabets)]
    public async Task<ActionResult<VirtualizeResponse<Alphabet>>> Alphabets(
        [FromQuery] VirtualizeQueryParameters request)
    {
        try
        {
            var alphabets = await searchAlphabetsRepository.SearchAsync(request);

            if (alphabets.TotalCount == 0)
                return NotFound(ErrorMessages.AlphabetsNotFound(request.SearchText));

            return Ok(alphabets);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet(ApiRoutes.Search.Artworks)]
    public async Task<ActionResult<VirtualizeResponse<Artwork>>> Search(
        [FromQuery] VirtualizeQueryParameters request)
    {
        try
        {
            var artworks = await searchArtworksRepository.SearchAsync(request);

            if (artworks.TotalCount == 0)
                return NotFound(ErrorMessages.ArtworksNotFound(request.SearchText));

            return Ok(artworks);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}