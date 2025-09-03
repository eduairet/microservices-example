using AsciiService.Entities;

namespace AsciiService.Data.SeedDataObjects;

public static class SeedDataAlphabets
{
    public static Alphabet Default() => new()
    {
        Title = "Default",
        Description = "Default alphabet with basic ASCII characters.",
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow,
        IsActive = true,
        Glyphs = DefaultAlphabetGlyphs()
    };

    private static List<Glyph> DefaultAlphabetGlyphs()
    {
        List<(string name, int unicode, string drawing)> glyphs =
        [
            ("Space", 0x0020, "____\n____\n____\n____\n____\n____\n____"),
            ("A", 0x0041, "_WWWW_\nWW__WW\nWW__WW\nWW__WW\nWWWWWW\nWW__WW\nWW__WW"),
            ("B", 0x0042, "WWWWW_\nWW__WW\nWW__WW\nWWWWW_\nWW__WW\nWW__WW\nWWWWW_"),
            ("C", 0x0043, "_WWWW_\nWW__WW\nWW____\nWW____\nWW____\nWW__WW\n_WWWW_"),
            ("D", 0x0044, "WWWWW_\nWW__WW\nWW__WW\nWW__WW\nWW__WW\nWW__WW\nWWWWW_"),
            ("E", 0x0045, "WWWWW\nWW___\nWW___\nWWWW_\nWW___\nWW___\nWWWWW"),
            ("F", 0x0046, "WWWWW\nWW___\nWW___\nWW___\nWWWW_\nWW___\nWW___"),
            ("G", 0x0047, "_WWWW_\nWW__WW\nWW____\nWW_WWW\nWW__WW\nWW__WW\n_WWWW_"),
            ("H", 0x0048, "WW__WW\nWW__WW\nWW__WW\nWWWWWW\nWW__WW\nWW__WW\nWW__WW"),
            ("I", 0x0049, "WW\nWW\nWW\nWW\nWW\nWW\nWW"),
            ("J", 0x004A, "___WW\n___WW\n___WW\n___WW\nWW_WW\nWW_WW\n_WWW_"),
            ("K", 0x004B, "WW__WW\nWW__WW\nWW_WW_\nWWWW__\nWW_WW_\nWW__WW\nWW__WW"),
            ("L", 0x004C, "WW__\nWW__\nWW__\nWW__\nWW__\nWW__\nWWWW"),
            ("M", 0x004D, "WW____WW\nWWW__WWW\nWWW__WWW\nWWWWWWWW\nWW_WW_WW\nWW_WW_WW\nWW____WW"),
            ("N", 0x004E, "WW___W\nWWW__W\nWWWW_W\nW_WW_W\nW_WWWW\nW__WWW\nW___WW"),
            ("O", 0x004F, "_WWWW_\nWW__WW\nWW__WW\nWW__WW\nWW__WW\nWW__WW\n_WWWW_"),
            ("P", 0x0050, "WWWWW_\nWW__WW\nWW__WW\nWW__WW\nWWWWW_\nWW____\nWW____"),
            ("Q", 0x0051, "_WWWW__\nWW__WW_\nWW__WW_\nWW__WW_\nWW__WW_\nWW__WW_\n_WWWWWW"),
            ("R", 0x0052, "WWWWW_\nWW__WW\nWW__WW\nWW__WW\nWWWWW_\nWW__WW\nWW__WW"),
            ("S", 0x0053, "_WWW_\nWW__W\nWWW__\n_WWW_\n__WWW\nW__WW\n_WWW_"),
            ("T", 0x0054, "WWWWWW\n__WW__\n__WW__\n__WW__\n__WW__\n__WW__\n__WW__"),
            ("U", 0x0055, "WW__WW\nWW__WW\nWW__WW\nWW__WW\nWW__WW\nWW__WW\n_WWWW_"),
            ("V", 0x0056, "WW__WW\nWW__WW\nWW__WW\nWW__WW\nWW__WW\n_WWWW_\n__WW__"),
            ("W", 0x0057, "WW_WW_WW\nWW_WW_WW\nWW_WW_WW\nWW_WW_WW\nWW_WW_WW\n_WWWWWW_\n__W__W__"),
            ("X", 0x0058, "WW___W\nWW___W\nWWW_W_\n__WW__\n_W_WWW\nW___WW\nW___WW"),
            ("Y", 0x0059, "WW__WW\nWW__WW\nWW__WW\n_WWWW_\n__WW__\n__WW__\n__WW__"),
            ("Z", 0x005A, "WWWWWW\n____WW\n___WWW\n_WWWW_\nWWW___\nWW____\nWWWWWW")
        ];

        return glyphs.Select(g => new Glyph
        {
            Name = g.name,
            Unicode = g.unicode,
            Drawing = g.drawing
        }).ToList();
    }
}