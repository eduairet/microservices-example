using Microsoft.EntityFrameworkCore;

namespace AsciiService.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
}