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
    public async Task<IActionResult> GetAllAlphabets([FromQuery] GetAllAlphabetsRequest request)
    {
        try
        {
            var alphabets = await alphabetsRepository.GetAllAsync();

            if (alphabets is null || alphabets.Count == 0)
                return NotFound("No alphabets found.");

            if (!string.IsNullOrWhiteSpace(request.SearchText))
                alphabets = alphabets
                    .Where(a => a.Title.Contains(request.SearchText, StringComparison.OrdinalIgnoreCase) ||
                                a.Description.Contains(request.SearchText, StringComparison.OrdinalIgnoreCase))
                    .ToList();

            if (request.Take > alphabets.Count)
                request.Take = alphabets.Count;

            if (request.Skip < 0)
                request.Skip = 0;

            alphabets = alphabets
                .Skip(request.Skip)
                .Take(request.Take)
                .ToList();

            return Ok(alphabets);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}