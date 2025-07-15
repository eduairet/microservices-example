using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Routing;

namespace AsciiTypeGenerator.Common.Transformers;

public partial class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string TransformOutbound(object value)
    {
        if (value is null) return null;

        var str = value.ToString();

        return string.IsNullOrEmpty(str) ? null : SlugRegex().Replace(str, "$1-$2").ToLower();
    }

    [GeneratedRegex("([a-z])([A-Z])")]
    private static partial Regex SlugRegex();
}