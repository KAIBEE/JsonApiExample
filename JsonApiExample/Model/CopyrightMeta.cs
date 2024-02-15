using JsonApiDotNetCore.Serialization.Response;

namespace JsonApiExample.Model
{
    public sealed class CopyrightMeta : IResponseMeta
    {
        public IDictionary<string, object?>? GetMeta()
        {
            return new Dictionary<string, object?>
            {
                ["copyright"] = $"Copyright (C) {DateTime.Now.Year} Kaibee."
            };
        }
    }
}
