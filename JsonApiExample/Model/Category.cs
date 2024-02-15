using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace JsonApiExample.Model
{
    [Resource]
    public class Category : Identifiable<int>{

        [Attr]
        public string Title { get; set; }

        [Attr]
        public string Description { get; set; }

        [Attr]
        public DateTime CreatedAt { get; set; }

        [HasMany]
        public List<Post>? Posts { get; set; }
    }
}
