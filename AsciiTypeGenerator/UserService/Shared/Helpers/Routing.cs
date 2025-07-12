using System.Text.RegularExpressions;

namespace UserService.Shared.Helpers;

public static partial class Helpers
{
    public static partial class Routing
    {
        public partial class SlugifyParameterTransformer : IOutboundParameterTransformer
        {
            public string TransformOutbound(object value)
            {
                if (value == null)
                {
                    return null;
                }

                var str = value.ToString();

                return string.IsNullOrEmpty(str) ? null : SlugRegex().Replace(str, "$1-$2").ToLower();
            }

            [GeneratedRegex("([a-z])([A-Z])")]
            private static partial Regex SlugRegex();
        }
    }
}