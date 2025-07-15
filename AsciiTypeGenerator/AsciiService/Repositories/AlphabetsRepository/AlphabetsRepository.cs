using AsciiService.Data;
using AsciiService.Entities;
using AsciiService.Repositories.RepositoryBase;

namespace AsciiService.Repositories.AlphabetsRepository;

public class AlphabetsRepository(AppDbContext context) : RepositoryBase<Alphabet>(context), IAlphabetsRepository
{
}