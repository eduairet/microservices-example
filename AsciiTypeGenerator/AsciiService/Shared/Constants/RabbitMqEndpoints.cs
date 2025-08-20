namespace AsciiService.Shared.Constants;

public static class RabbitMqEndpoints
{
    public const string Prefix = "ascii";

    public static class Alphabets
    {
        private const string _alphabetsBasePath = $"{Prefix}-alphabet";

        public const string Created = $"{_alphabetsBasePath}-created";
        public const string Updated = $"{_alphabetsBasePath}-updated";
        public const string Deleted = $"{_alphabetsBasePath}-deleted";
    }

    public static class Artworks
    {
        private const string _artworksBasePath = $"{Prefix}-artwork";

        public const string Created = $"{_artworksBasePath}-created";
        public const string Updated = $"{_artworksBasePath}-updated";
        public const string Deleted = $"{_artworksBasePath}-deleted";
    }
}