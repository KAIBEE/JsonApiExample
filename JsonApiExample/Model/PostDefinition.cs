using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Resources;
using System;

namespace JsonApiExample.Model
{
    public class PostDefinition : JsonApiResourceDefinition<Post, int>
    {
        public PostDefinition(IResourceGraph resourceGraph)
        : base(resourceGraph)
        {
        }

        public override IDictionary<string, object?>? GetMeta(Post post)
        {
            return new Dictionary<string, object?>
                {
                    ["year"] = post.CreatedAt.Year
                };

        }
    }
}
