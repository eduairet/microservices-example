namespace SearchService.Shared.Constants;

public static class RabbitMqEndpoints
{
    private const string _basePath = "search";

    public static class Alphabets
    {
        private const string _alphabetsBasePath = $"{_basePath}-alphabet";

        public const string Created = $"{_alphabetsBasePath}-created";
        public const string Updated = $"{_alphabetsBasePath}-updated";
        public const string Deleted = $"{_alphabetsBasePath}-deleted";
    }

    public static class Artworks
    {
        private const string _artworksBasePath = $"{_basePath}-artwork";

        public const string Created = $"{_artworksBasePath}-created";
        public const string Updated = $"{_artworksBasePath}-updated";
        public const string Deleted = $"{_artworksBasePath}-deleted";
    }
}