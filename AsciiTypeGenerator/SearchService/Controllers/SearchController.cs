using Microsoft.AspNetCore.Mvc;
using SearchService.Models;
using SearchService.Models.Virtualize;
using SearchService.Repositories.SearchRepository;
using SearchService.Shared.Constants;

namespace SearchService.Controllers;

[ApiController]
[Route($"{ApiRoutes.BasePath}/[controller]")]
public class SearchController(ISearchRepository searchRepository) : ControllerBase
{
    [HttpGet(ApiRoutes.Search.Alphabets)]
    public async Task<ActionResult<VirtualizeResponse<Alphabet>>> Alphabets(
        [FromQuery] VirtualizeRequest request)
    {
        try
        {
            var parameters = new VirtualizeQueryParameters();
            parameters.StartIndex = request.Page * parameters.PageSize;

            var alphabets = await searchRepository.SearchAsync(parameters, request.SearchText);

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
        [FromQuery] VirtualizeRequest request)
    {
        try
        {
            var parameters = new VirtualizeQueryParameters();
            parameters.StartIndex = request.Page * parameters.PageSize;

            var artworks = await searchRepository.SearchAsync(parameters, request.SearchText);

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